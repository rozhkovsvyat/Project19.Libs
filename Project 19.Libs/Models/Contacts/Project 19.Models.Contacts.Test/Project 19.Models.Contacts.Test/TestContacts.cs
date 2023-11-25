namespace Project_19.Models;

/// <summary>
/// Содержит методы и свойства тестовой коллекции элементов типа <see cref="Contact"/>
/// </summary>
public class TestContacts : IContacts
{
	#region IContacts

    /// <inheritdoc cref="IContacts.GetAsync()"/>
	public async Task<IEnumerable<Contact>> GetAsync()
    {
        await Task.Delay(RandomDelay);
        return Contacts;
    }

    /// <inheritdoc cref="IContacts.GetAsync(int)"/>
	public async Task<Contact?> GetAsync(int id)
    {
        await Task.Delay(RandomDelay);
        return Contacts.FirstOrDefault(m => m.Id == id);
    }

    /// <inheritdoc cref="IContacts.FindAsync(int)"/>
	public async Task<Contact?> FindAsync(int id) => await GetAsync(id);

    /// <inheritdoc cref="IContacts.AddAsync(Contact)"/>
	public async Task AddAsync(Contact contact)
    {
        await Task.Delay(RandomDelay);

        contact.Id = NextId++;

        Contacts.Add(contact);
    }

    /// <inheritdoc cref="IContacts.UpdateAsync(Contact)"/>
	public async Task UpdateAsync(Contact contact)
    {
	    await Task.Delay(RandomDelay);

		var selected = Contacts.FirstOrDefault
		    (c => c.Id == contact.Id);

	    if (selected != null)
	    {
		    selected.LastName = contact.LastName;
		    selected.FirstName = contact.FirstName;
		    selected.Address = contact.Address;
		    selected.MobileNumber = contact.MobileNumber;
		    selected.Description = contact.Description;
		    selected.Patronymic = contact.Patronymic;
	    }
	    else { throw new KeyNotFoundException(); }
    }

    /// <inheritdoc cref="IContacts.RemoveAsync(int)"/>
	public async Task RemoveAsync(int id)
    {
	    var contact = await FindAsync(id) ??
			throw new KeyNotFoundException();

        Contacts.Remove(contact);

        await Task.Delay(RandomDelay);
	}

	#endregion

    /// <summary>
    /// Максимальное время задержки в миллисекундах
    /// </summary>
    protected int DelayMaxMs = 1000;

	/// <summary>
	/// Случайная задержка в миллисекундах
	/// </summary>
	protected int RandomDelay => new Random().Next(DelayMaxMs);

	/// <summary>
	/// Коллекция элементов типа <see cref="Contact"/>
	/// </summary>
	protected readonly List<Contact> Contacts = new();

    /// <summary>
    /// Значение идентификатора для нового (следующего) элемента
    /// </summary>
    protected int NextId = 1;

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public TestContacts() { }

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="delayMaxMs">Максимальное время задержки в миллисекундах</param>
	public TestContacts(int delayMaxMs) 
	    => DelayMaxMs = delayMaxMs;
}
