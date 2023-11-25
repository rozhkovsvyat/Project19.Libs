using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Project_19.Services;

/// <summary>
/// Содержит методы расширения <see cref="IInitializator{T}"/> и <see cref="IInitializator{T1,T2}"/>
/// </summary>
public static class InitializatorExtensions
{
	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArg">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArg>
	(this IServiceScope scope, ILogger? log = null) where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ??
		              throw new ArgumentNullException(typeof(TService).Name);

		if (service is not IInitializator<TArg> initializable)
			throw new InvalidOperationException($"{nameof(service)} " +
			                                    $"is not initializable by {nameof(TArg)}.");

		var arg = scope.ServiceProvider.GetService<TArg>() ??
		          throw new ArgumentNullException(typeof(TArg).Name);

		initializable.Initialize(arg, log);

		return scope;
	}

	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArg">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="argFunc">Функция получения аргумента инициализации из <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArg>(this IServiceScope scope,
		Func<IServiceScope, TArg> argFunc, ILogger? log = null) where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ?? 
		              throw new ArgumentNullException(typeof(TService).Name);

		if (service is not IInitializator<TArg> initializable) 
			throw new InvalidOperationException($"{nameof(service)} " +
										$"is not initializable by {nameof(TArg)}.");

		initializable.Initialize(argFunc.Invoke(scope), log);

		return scope;
	}

	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArgA">Тип аргумента инициализации</typeparam>
	/// <typeparam name="TArgB">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArgA, TArgB>
	(this IServiceScope scope, ILogger? log = null) where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ??
		              throw new ArgumentNullException(typeof(TService).Name);
	
		if (service is not IInitializator<TArgA, TArgB> initializable)
			throw new InvalidOperationException($"{nameof(service)} " +
				$"is not initializable by {nameof(TArgA)} and/or {nameof(TArgB)}.");

		var argA = scope.ServiceProvider.GetService<TArgA>() ??
		           throw new ArgumentNullException(typeof(TArgA).Name);

		var argB = scope.ServiceProvider.GetService<TArgB>() ??
		           throw new ArgumentNullException(typeof(TArgB).Name);

		initializable.Initialize(argA, argB, log);
	
		return scope;
	}

	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArgA">Тип аргумента инициализации</typeparam>
	/// <typeparam name="TArgB">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="argFuncB">Функция получения аргумента инициализации из <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArgA, TArgB>(this IServiceScope scope,
		Func<IServiceScope, TArgB> argFuncB, ILogger? log = null) where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ??
		              throw new ArgumentNullException(typeof(TService).Name);

		if (service is not IInitializator<TArgA, TArgB> initializable)
			throw new InvalidOperationException($"{nameof(service)} " +
				$"is not initializable by {nameof(TArgA)} and/or {nameof(TArgB)}.");

		var argA = scope.ServiceProvider.GetService<TArgA>() ??
		           throw new ArgumentNullException(typeof(TArgA).Name);

		initializable.Initialize(argA, argFuncB.Invoke(scope), log);

		return scope;
	}

	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArgA">Тип аргумента инициализации</typeparam>
	/// <typeparam name="TArgB">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="argFuncA">Функция получения аргумента инициализации из <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArgA, TArgB>(this IServiceScope scope,
		Func<IServiceScope, TArgA> argFuncA, ILogger? log = null) where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ??
		              throw new ArgumentNullException(typeof(TService).Name);

		if (service is not IInitializator<TArgA, TArgB> initializable)
			throw new InvalidOperationException($"{nameof(service)} " +
				$"is not initializable by {nameof(TArgA)} and/or {nameof(TArgB)}.");

		var argB = scope.ServiceProvider.GetService<TArgB>() ??
		           throw new ArgumentNullException(typeof(TArgB).Name);

		initializable.Initialize(argFuncA.Invoke(scope), argB, log);

		return scope;
	}

	/// <summary>
	/// Производит инициализацию службы из <see cref="IServiceScope"/>
	/// </summary>
	/// <typeparam name="TService">Тип службы</typeparam>
	/// <typeparam name="TArgA">Тип аргумента инициализации</typeparam>
	/// <typeparam name="TArgB">Тип аргумента инициализации</typeparam>
	/// <param name="scope">Службы <see cref="IServiceScope"/></param>
	/// <param name="argFuncA">Функция получения аргумента инициализации из <see cref="IServiceScope"/></param>
	/// <param name="argFuncB">Функция получения аргумента инициализации из <see cref="IServiceScope"/></param>
	/// <param name="log">Логгер</param>
	/// <returns><see cref="IServiceScope"/></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	public static IServiceScope Initialize<TService, TArgA, TArgB>(this IServiceScope scope,
		Func<IServiceScope, TArgA> argFuncA, Func<IServiceScope, TArgB> argFuncB, ILogger? log = null)
		where TService : notnull
	{
		var service = scope.ServiceProvider.GetService<TService>() ??
		              throw new ArgumentNullException(typeof(TService).Name);

		if (service is not IInitializator<TArgA, TArgB> initializable)
			throw new InvalidOperationException($"{nameof(service)} " +
				$"is not initializable by {nameof(TArgA)} and/or {nameof(TArgB)}.");

		initializable.Initialize(argFuncA.Invoke(scope), argFuncB.Invoke(scope), log);

		return scope;
	}
}
