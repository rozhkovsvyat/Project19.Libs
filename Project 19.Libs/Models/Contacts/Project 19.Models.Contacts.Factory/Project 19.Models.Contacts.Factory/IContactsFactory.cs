namespace Project_19.Models;

/// <summary>
/// Представляет фабрику элементов типа <see cref="Contact"/>
/// </summary>
public interface IContactsFactory
{
	/// <summary>
	/// Возвращает коллекцию элементов типа <see cref="Contact"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Contact"/></returns>
	IEnumerable<Contact> Get();
}
