namespace Project_19.Services;

/// <summary>
/// Предоставляет свойства API
/// </summary>
public interface IApi
{
	/// <summary>
	/// Адрес
	/// </summary>
	string Url { get; }

	/// <summary>
	/// Проверяет доступность сервиса
	/// </summary>
	/// <returns>Результат проверки</returns>
	Task<bool> IsAvailable();
}
