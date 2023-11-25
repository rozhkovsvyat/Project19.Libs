namespace Project_19.Models;

/// <summary>
/// Содержит методы расширения <see cref="IContactsFactory"/>
/// </summary>
public static class ContactsFactoryExtensions
{
	/// <summary>
	/// Присваивает элементам коллекции типа <see cref="Contact"/> создателя
	/// </summary>
	/// <param name="contacts">Коллекция элементов типа <see cref="Contact"/></param>
	/// <param name="createdBy">Создатель</param>
	public static IEnumerable<Contact> SetCreatedBy(this IEnumerable<Contact> contacts, string createdBy)
	{
		var result = contacts as Contact[] ?? contacts.ToArray();
		foreach (var c in result) c.CreatedBy = createdBy;
		return result;
	}

	/// <summary>
	/// Присваивает элементам коллекции типа <see cref="Contact"/> идентификатор {0-n} по-возрастанию
	/// </summary>
	/// <param name="contacts">Коллекция элементов типа <see cref="Contact"/></param>
	public static IEnumerable<Contact> SetAutoId(this IEnumerable<Contact> contacts)
    {
        var next = 0;
        var result = contacts as Contact[] ?? contacts.ToArray();
        foreach (var c in result) c.Id = ++next;
        return result;
    }

	/// <summary>
	/// Присваивает элементам коллекции типа <see cref="Contact"/> описание "Description #{0-n}" по-возрастанию
	/// </summary>
	/// <param name="contacts">Коллекция элементов типа <see cref="Contact"/></param>
	public static IEnumerable<Contact> SetAutoDescription(this IEnumerable<Contact> contacts)
    {
        var next = 0;
        var result = contacts as Contact[] ?? contacts.ToArray();
        foreach (var c in result) c.Description = $"{nameof(c.Description)} #{++next}";
        return result;
    }

	/// <summary>
	/// Объединяет коллекции элементов типа <see cref="Contact"/>
	/// </summary>
	/// <param name="source">Коллекция элементов типа <see cref="Contact"/></param>
	/// <param name="target">Коллекция элементов типа <see cref="Contact"/></param>
	/// <returns>Коллекция элементов типа <see cref="Contact"/></returns>
	public static IEnumerable<Contact> Join(this IEnumerable<Contact> source, IEnumerable<Contact> target)
	{
		var result = source.ToList();
		result.AddRange(target);
        return result;
    }
}
