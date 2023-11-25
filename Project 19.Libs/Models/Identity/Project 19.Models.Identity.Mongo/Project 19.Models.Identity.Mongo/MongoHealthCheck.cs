using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Project_19.Models;

/// <summary>
/// Представляет проверку работоспособности MongoDB
/// </summary>
public class MongoDbHealthCheck : IHealthCheck
{
	/// <summary>
	/// Строка подключения к базе данных идентификации
	/// </summary>
	private readonly string _conStr;

	/// <summary>
	/// Список названий проверяемых баз данных
	/// </summary>
	private readonly string[] _dbNames = { "local", "admin", "config" };

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="conStr">Строка подключения к базе данных идентификации</param>
	public MongoDbHealthCheck(string conStr) => _conStr = conStr;

	/// <summary>
	/// Проверяет работоспособность сервиса
	/// </summary>
	/// <returns>Результат проверки</returns>
	public async Task<HealthCheckResult> CheckHealthAsync
		(HealthCheckContext context, CancellationToken cancellationToken = default)
	{
		foreach (var dbName in _dbNames)
		{
			try
			{
				await CheckMongoHealth(dbName);
				return HealthCheckResult.Healthy();
			}
			catch (Exception) { /*ignored*/ }
		}
		return HealthCheckResult.Unhealthy();
	}

	/// <summary>
	/// Проверяет соединение с <see cref="MongoDB"/>
	/// </summary>
	/// <param name="dbName">Имя базы данных</param>
	/// <returns>Результат проверки</returns>
	private async Task CheckMongoHealth(string dbName)
	{
		var url = new MongoUrl(_conStr);

		var dbInstance = new MongoClient(url).GetDatabase(dbName)	
			.WithReadPreference(new ReadPreference(ReadPreferenceMode.Secondary));

		_ = await dbInstance.RunCommandAsync<BsonDocument>
			(new BsonDocument { { "ping", 1 } });
	}
}
