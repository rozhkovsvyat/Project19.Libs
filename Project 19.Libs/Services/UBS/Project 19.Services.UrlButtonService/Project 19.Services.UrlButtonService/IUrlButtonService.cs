﻿namespace Project_19.Services;

/// <summary>
/// Предоставляет свойства сервиса коллекции элементов <see cref="IUrlButton"/> и <see cref="IUrlScript"/>
/// </summary>
public interface IUrlButtonService 
	: IUrlButtonService<IUrlButton, IUrlScript> { }

/// <summary>
/// Предоставляет свойства сервиса коллекции элементов <see cref="IUrlButton"/> и <see cref="IUrlScript"/>
/// </summary>
/// <typeparam name="T1">Тип элемента коллекции <see cref="IUrlButton"/></typeparam>
/// <typeparam name="T2">Тип элемента коллекции <see cref="IUrlScript"/></typeparam>
public interface IUrlButtonService<out T1, out T2> 
	where T1: IUrlButton where T2: IUrlScript
{
	/// <summary>
	/// Элементы коллекции
	/// </summary>
	public IEnumerable<T1> Buttons { get; }
	/// <summary>
	/// Используемые скрипты
	/// </summary>
	public IEnumerable<T2> Scripts { get; }
}
