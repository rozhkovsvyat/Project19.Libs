namespace Project_19.Models;

/// <summary>
/// Содержит методы расширения <see cref="IIdentity"/>
/// </summary>
public static class IdentityExtensions
{
	/// <summary>
	/// Сериализует набор строк в строку разделяя символом переноса
	/// </summary>
	/// <param name="input">Входной набор строк</param>
	/// <returns>Сериализованная строка</returns>
	public static string Serialize(this IEnumerable<string> input)
	{
		var result = input.ToArray().Aggregate(string.Empty, 
			(current, s) => current + string.Concat(s, "\n"));
		return result[^1] == '\n' ? result[..^1] : result;
	}

	/// <summary>
	/// Десериализует строку в набор строк по символу переноса
	/// </summary>
	/// <param name="input">Входная строка</param>
	/// <returns>Десериализованный набор строк</returns>
	public static IEnumerable<string> Deserialize(this string input) 
		=> input.Split('\n');
}
