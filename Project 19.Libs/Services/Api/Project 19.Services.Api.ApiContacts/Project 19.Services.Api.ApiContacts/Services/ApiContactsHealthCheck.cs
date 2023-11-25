using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Project_19.Services;

/// <summary>
/// Представляет проверку работоспособности <see cref="ApiContacts"/>
/// </summary>
public class ApiContactsHealthCheck : IHealthCheck
{
	/// <summary>
	/// Сервис <see cref="ApiContacts"/>
	/// </summary>
	private readonly ApiContacts _apiContacts;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="url">Адрес сервиса</param>
	public ApiContactsHealthCheck(string url) 
		=> _apiContacts = new ApiContacts(url);

	/// <summary>
	/// Проверяет работоспособность сервиса
	/// </summary>
	/// <returns>Результат проверки</returns>
	public async Task<HealthCheckResult> CheckHealthAsync
		(HealthCheckContext context, CancellationToken cancellationToken = default) 
		=> await _apiContacts.IsAvailable() ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
}
