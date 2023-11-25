#pragma warning disable CS8509
using System.Net.NetworkInformation;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net;

using Project_19.Models;

namespace Project_19.Services;

/// <summary>
/// Содержит методы и свойства коллекции элементов типа <see cref="Contact"/>, предоставляемых через API
/// </summary>
public class ApiContacts : IContacts, IApi, IToken
{
	#region IToken

	/// <inheritdoc/>
	public void SetToken(string? token) => _token = token;

	#endregion

	#region IContacts

	/// <inheritdoc/>
	public async Task<IEnumerable<Contact>> GetAsync()
	{
		try { return await Client.GetFromJsonAsync<IEnumerable<Contact>>(Url) ?? throw new JsonException(); }
		catch (JsonException) { return Enumerable.Empty<Contact>(); }
	}

	/// <inheritdoc/>
	public async Task<Contact?> GetAsync(int id)
	{
		try { return await Client.GetFromJsonAsync<Contact>(Url.Combine(id)); }
		catch (JsonException) { return null; }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task AddAsync(Contact contact)
	{
		try { await Client.PostAsJsonAsync(Url, contact); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task UpdateAsync(Contact contact)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine(contact.Id), contact);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException(),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException()
		};
	}

	/// <inheritdoc/>
	public async Task RemoveAsync(int id)
	{
		var response = await Client.DeleteAsync(Url.Combine(id));

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException()
		};
	}

	#region Additional

	/// <inheritdoc/>
	public Task<Contact?> FindAsync(int id) => GetAsync(id);

	#endregion

	#endregion

	#region IApi

	/// <inheritdoc/>
	public string Url { get; }

	/// <inheritdoc/>
	public async Task<bool> IsAvailable() 
		=> (await Client.GetAsync(Url.Combine(nameof(Ping)))).IsSuccessStatusCode;

	#endregion

	/// <summary>
	/// Фабрика <see cref="HttpClient"/>
	/// </summary>
	private readonly IHttpClientFactory? _factory;
	/// <summary>
	/// Http-клиент
	/// </summary>
	private HttpClient Client
	{
		get
		{
			var client = _factory?.CreateClient(nameof(HttpClient)) ?? new HttpClient();

			if (!string.IsNullOrEmpty(_token))
				client.DefaultRequestHeaders.Authorization
					= new AuthenticationHeaderValue("Bearer", _token);

			return client;
		}
	}
	/// <summary>
	/// Токен аутентификации
	/// </summary>
	private string? _token;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции службы <see cref="ApiContacts"/> из конфигурации</param>
	/// <param name="factory">Фабрика <see cref="HttpClient"/></param>
	public ApiContacts(IOptions<ApiContactsOptions> options, 
		IHttpClientFactory? factory = null) : this(options.Value.Url) => _factory = factory;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="url">Адрес сервиса</param>
	public ApiContacts(string url) => Url = url;
}
