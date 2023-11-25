namespace Project_19.Models;

/// <summary>
/// Предоставляет методы и свойства коллекции элементов типа <see cref="Contact"/>
/// </summary>
public interface IContacts
{
	/// <summary>
	/// Запрашивает коллекцию элементов типа <see cref="Contact"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Contact"/> (может быть пустой)</returns>
	Task<IEnumerable<Contact>> GetAsync();

	/// <summary>
	/// Запрашивает <see cref="Contact"/> по идентификатору
	/// </summary>
	/// <param name="id">Идентификатор</param>
	/// <returns><see cref="Contact"/>?</returns>
	Task<Contact?> GetAsync(int id);

	/// <summary>
	/// Производит поиск <see cref="Contact"/> по идентификатору
	/// </summary>
	/// <param name="id">Идентификатор</param>
	/// <returns><see cref="Contact"/>?</returns>
	Task<Contact?> FindAsync(int id);

	/// <summary>
	/// Добавляет новый <see cref="Contact"/>
	/// </summary>
	/// <param name="contact">Контакт</param>
	Task AddAsync(Contact contact);

	/// <summary>
	/// Обновляет существующий <see cref="Contact"/>
	/// </summary>
	/// <param name="contact">Контакт</param>
	/// <exception cref="KeyNotFoundException"/>
	Task UpdateAsync(Contact contact);

	/// <summary>
	/// Удаляет существующий <see cref="Contact"/>
	/// </summary>
	/// <param name="id">Идентификатор</param>
	/// <exception cref="KeyNotFoundException"/>
	Task RemoveAsync(int id);
}
