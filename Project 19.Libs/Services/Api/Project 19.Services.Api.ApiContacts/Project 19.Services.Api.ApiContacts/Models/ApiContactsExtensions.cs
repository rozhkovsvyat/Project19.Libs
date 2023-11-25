namespace Project_19.Models;

/// <summary>
/// Содержит методы расширения <see cref="IContacts"/>
/// </summary>
public static class ApiContactsExtensions
{
	/// <summary>
	/// Устанавливает токен
	/// </summary>
	/// <param name="contacts">Контакты</param>
	/// <param name="token">Токен</param>
	/// <returns></returns>
	public static IContacts AddToken(this IContacts contacts, string? token)
	{
		if (contacts is IToken t) t.SetToken(token); 
		return contacts;
	}
}
