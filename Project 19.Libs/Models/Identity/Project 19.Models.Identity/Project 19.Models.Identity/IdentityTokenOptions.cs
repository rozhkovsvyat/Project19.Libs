namespace Project_19.Models;

/// <summary>
/// Содержит опции токена аутентификации
/// </summary>
public class IdentityTokenOptions
{
	/// <summary>
	/// Издатель
	/// </summary>
	public string Issuer { get; set; } = string.Empty;
	/// <summary>
	/// Клиент
	/// </summary>
	public string Audience { get; set; } = string.Empty;
	/// <summary>
	/// Ключ
	/// </summary>
	public string Key { get; set; } = string.Empty;
}
