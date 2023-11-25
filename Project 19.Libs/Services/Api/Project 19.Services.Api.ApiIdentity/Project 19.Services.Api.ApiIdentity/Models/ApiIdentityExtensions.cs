namespace Project_19.Models;

/// <summary>
/// Содержит методы расширения <see cref="IIdentity"/>
/// </summary>
public static class ApiIdentityExtensions
{
	/// <summary>
	/// Устанавливает токен
	/// </summary>
	/// <param name="identity">Идентификация</param>
	/// <param name="token">Токен</param>
	/// <returns></returns>
	public static IIdentity AddToken(this IIdentity identity, string? token)
	{
		if (identity is IToken t) t.SetToken(token); 
		return identity;
	}
}
