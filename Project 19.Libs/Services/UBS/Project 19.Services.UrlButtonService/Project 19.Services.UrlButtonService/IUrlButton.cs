namespace Project_19.Services;

/// <summary>
/// Предоставляет свойства кнопки-ссылки
/// </summary>
public interface IUrlButton
{
	/// <summary>
	/// Имя ссылки
	/// </summary>
	string Title { get; }
	/// <summary>
	/// Цвет кнопки
	/// </summary>
	string Color { get; }
	/// <summary>
	/// Класс иконки
	/// </summary>
	string Icss { get; }
	/// <summary>
	/// Адрес ссылки
	/// </summary>
	string Url { get; }
}
