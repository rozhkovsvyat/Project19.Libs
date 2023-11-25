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
/// Содержит методы и свойства работы с аккаунтами пользователей, предоставляемых через API
/// </summary>
public class ApiIdentity : IIdentity, IApi, IToken
{
	#region IToken

	/// <inheritdoc/>
	public void SetToken(string? token) => _token = token;

	#endregion

	#region IIdentity

	/// <inheritdoc/>
	public CreateAccountForm CreateAccountForm => new();
    /// <inheritdoc/>
    public ChangePasswordForm ChangePasswordForm => new();
    /// <inheritdoc/>
    public ManageRolesForm ManageRolesForm => new();
    /// <inheritdoc/>
    public CreateRoleForm CreateRoleForm => new();
    /// <inheritdoc/>
    public SignInForm SignInForm => new();

	#region Account

	/// <inheritdoc/>
	public async Task<string> SignInAsync(SignInForm form)
	{
		var response = await Client.PostAsJsonAsync(Url.Combine(form.Login), form);

		if (!response.IsSuccessStatusCode) throw new InvalidOperationException
			($"Wrong {nameof(form.Login)} or {nameof(form.Password)}.");

		return await response.Content.ReadAsStringAsync();
	}

	/// <inheritdoc/>
	public async Task AddAsync(CreateAccountForm form)
	{
		var response = await Client.PostAsJsonAsync(Url, form);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch 
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException
				($"{nameof(form.Password)} does not meet security requirements: " +
				 "\nlength {6}, symbol {1}, digit {1}, unique char {1}, uppercase, lowercase."),

			HttpStatusCode.Conflict => new InvalidOperationException
				($"{nameof(form.Login)} \"{form.Login}\" already exists.")
		};
	}

	/// <inheritdoc/>
	public async Task UpdatePasswordAsync(ChangePasswordForm form)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine(nameof(form.Password)).Combine(form.Login), form);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException
				($"Invalid {nameof(form.OldPassword)} or {nameof(form.Password)} does not meet security requirements: " + 
				 "\nlength {6}, symbol {1}, digit {1}, unique char {1}, uppercase, lowercase."),

			HttpStatusCode.Unauthorized => new UnauthorizedException(),	
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task SignOutAsync() 
		=> await Client.PostAsync(Url.Combine("LogOut"), null);

	/// <inheritdoc/>
	public async Task<IEnumerable<Account>> GetAsync()
	{
		try { return await Client.GetFromJsonAsync<IEnumerable<Account>>(Url) ?? throw new JsonException(); }
		catch (JsonException) { return Enumerable.Empty<Account>(); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task<Account?> GetByIdAsync(string id)
	{
		try { return await Client.GetFromJsonAsync<Account>(Url.Combine(id)); }
		catch (JsonException) { return null; }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task UpdateAsync(Account account)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine(account.Id), account);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException
				($"{nameof(account.Login)} \"{account.Login}\" already exists."),

			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task RemoveByIdAsync(string id)
	{
		var response = await Client.DeleteAsync(Url.Combine(id));

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	#region Additional

	/// <inheritdoc/>
	public async Task<Account?> GetByLoginAsync(string login)
	{
		try { return await Client.GetFromJsonAsync<Account>(Url.Combine(nameof(login).Combine(login))); }
		catch (JsonException) { return null; }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task RemoveByLoginAsync(string login)
	{
		var response = await Client.DeleteAsync(Url.Combine("Remove").Combine(login));

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetRolesAsync(string login)
	{
		try 
		{ 
			return await Client.GetFromJsonAsync<IEnumerable<Role>>
				(Url.Combine("Include").Combine(login)) ?? throw new JsonException();
		}
		catch (JsonException) { return Enumerable.Empty<Role>(); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetAvailableRolesAsync(string login)
	{
		try
		{
			return await Client.GetFromJsonAsync<IEnumerable<Role>>
				(Url.Combine("Exclude").Combine(login)) ?? throw new JsonException();
		}
		catch (JsonException) { return Enumerable.Empty<Role>(); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task AddToRoleAsync(string login, string roleName)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine("Include").Combine(login), roleName);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task AddToRolesAsync(string login, IEnumerable<string> roleNames)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine("IncludeAll").Combine(login), roleNames);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task RemoveFromRoleAsync(string login, string roleName)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine("Exclude").Combine(login), roleName);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task RemoveFromRolesAsync(string login, IEnumerable<string> roleNames)
	{
		var response = await Client.PutAsJsonAsync(Url.Combine("ExcludeAll").Combine(login), roleNames);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	#endregion

	#endregion

	#region Role

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetRolesAsync()
	{
		try { return await Client.GetFromJsonAsync<IEnumerable<Role>>(RoleUrl) ?? throw new JsonException(); }
		catch (JsonException) { return Enumerable.Empty<Role>(); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task<Role?> GetRoleByIdAsync(string id)
	{
		try { return await Client.GetFromJsonAsync<Role>(RoleUrl.Combine(id)); }
		catch (JsonException) { return null; }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task AddRoleAsync(CreateRoleForm form)
	{
		var response = await Client.PostAsJsonAsync(RoleUrl, form);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.Conflict => new InvalidOperationException
				($"{nameof(Role)} \"{form.Name}\" already exists.")
		};
	}

	/// <inheritdoc/>
	public async Task UpdateRoleAsync(Role role)
	{
		var response = await Client.PutAsJsonAsync(RoleUrl.Combine(role.Id), role);

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException
				($"{nameof(Role)} \"{role.Name}\" already exists."),

			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	/// <inheritdoc/>
	public async Task RemoveRoleByIdAsync(string id)
	{
		var response = await Client.DeleteAsync(RoleUrl.Combine(id));

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	#region Additional

	/// <inheritdoc/>
	public async Task<Role?> GetRoleByNameAsync(string name)
	{
		try { return await Client.GetFromJsonAsync<Role>(RoleUrl.Combine(nameof(name)).Combine(name)); }
		catch (Exception) { throw new UnauthorizedException(); }
	}

	/// <inheritdoc/>
	public async Task RemoveRoleByNameAsync(string name)
	{
		var response = await Client.DeleteAsync(RoleUrl.Combine("Remove").Combine(name));

		if (!response.IsSuccessStatusCode) throw response.StatusCode switch
		{
			HttpStatusCode.InternalServerError => new InvalidOperationException("Internal server error."),
			HttpStatusCode.Unauthorized => new UnauthorizedException(),
			HttpStatusCode.NotFound => new KeyNotFoundException(),
		};
	}

	#endregion

	#endregion

	#endregion

	#region IApi

	/// <inheritdoc/>
	public string Url { get; }

	/// <inheritdoc/>
	public async Task<bool> IsAvailable() 
		=> (await Client.GetAsync(Url.Combine(nameof(Ping))))
		.IsSuccessStatusCode;

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
	/// Адрес запросов ролей
	/// </summary>
	public string RoleUrl => string.Concat(Url,nameof(Role));

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции службы <see cref="ApiIdentity"/> из конфигурации</param>
	/// <param name="factory">Фабрика <see cref="HttpClient"/></param>
	public ApiIdentity(IOptions<ApiIdentityOptions> options, 
		IHttpClientFactory? factory = null) : this(options.Value.Url) => _factory = factory;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="url">Адрес сервиса</param>
	public ApiIdentity(string url) => Url = url;
}
