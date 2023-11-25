namespace Project_19.Models;

/// <summary>
/// Предоставляет методы работы с токеном
/// </summary>
public interface IToken
{
	/// <summary>
	/// Устанавливает токен
	/// </summary>
	/// <param name="token">Токен</param>
	void SetToken(string? token);
}
