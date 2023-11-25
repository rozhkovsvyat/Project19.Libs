namespace Project_19.Services;

/// <summary>
/// Предоставляет свойства ссылки на скрипт
/// </summary>
public interface IUrlScript
{
	/// <summary>
	/// Аттрибут обработки запроса стороннего источника
	/// </summary>
	string CrossOrigin { get; }
	/// <summary>
	/// Адрес ссылки
	/// </summary>
	string Url { get; }
}
