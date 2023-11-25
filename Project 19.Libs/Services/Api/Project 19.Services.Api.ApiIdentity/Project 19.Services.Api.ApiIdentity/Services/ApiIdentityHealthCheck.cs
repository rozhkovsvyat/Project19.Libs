using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Project_19.Services;

/// <summary>
/// Представляет проверку работоспособности <see cref="ApiIdentity"/>
/// </summary>
public class ApiIdentityHealthCheck : IHealthCheck
{
	/// <summary>
	/// Сервис <see cref="ApiIdentity"/>
	/// </summary>
	private readonly ApiIdentity _apiIdentity;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="url">Адрес сервиса</param>
	public ApiIdentityHealthCheck(string url) 
		=> _apiIdentity = new ApiIdentity(url);

	/// <summary>
	/// Проверяет работоспособность сервиса
	/// </summary>
	/// <returns>Результат проверки</returns>
	public async Task<HealthCheckResult> CheckHealthAsync
		(HealthCheckContext context, CancellationToken cancellationToken = default) 
		=> await _apiIdentity.IsAvailable() ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
}
