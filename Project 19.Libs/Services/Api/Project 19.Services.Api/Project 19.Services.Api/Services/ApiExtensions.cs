namespace Project_19.Services;

/// <summary>
/// Содержит методы расширения <see cref="IApi"/>
/// </summary>
public static class ApiExtensions
{
	/// <summary>
	/// Возвращает путь в результате слияния двух строк
	/// </summary>
	/// <param name="source">Исходная строка</param>
	/// <param name="target">Добавочная строка</param>
	/// <returns>Результат слияния</returns>
	public static string Combine(this string source, string target)
		=> Path.Combine(source, target);

	/// <summary>
	/// Возвращает путь в результате слияния строки с числом
	/// </summary>
	/// <param name="source">Исходная строка</param>
	/// <param name="target">Добавочное число</param>
	/// <returns>Результат слияния</returns>
	public static string Combine(this string source, int target)
		=> source.Combine(target.ToString());
}
