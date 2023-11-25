using Microsoft.Extensions.Logging;

namespace Project_19.Services;

/// <summary>
/// Предоставляет возможность инициализации
/// </summary>
/// <typeparam name="T">Тип аргумента инициализации</typeparam>
public interface IInitializator<in T>
{
	/// <summary>
	/// Производит инициализацию
	/// </summary>
	/// <param name="arg">Аргумент инициализации</param>
	/// <param name="log">Логгер</param>
	void Initialize(T arg, ILogger? log = null);
}

/// <summary>
/// Предоставляет возможность инициализации
/// </summary>
/// <typeparam name="T1">Тип аргумента инициализации</typeparam>
/// <typeparam name="T2">Тип аргумента инициализации</typeparam>
public interface IInitializator<in T1, in T2>
{
	/// <summary>
	/// Производит инициализацию
	/// </summary>
	/// <param name="argA">Аргумент инициализации</param>
	/// <param name="argB">Аргумент инициализации</param>
	/// <param name="log">Логгер</param>
	void Initialize(T1 argA, T2 argB, ILogger? log = null);
}
