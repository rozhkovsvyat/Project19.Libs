using Microsoft.EntityFrameworkCore;

namespace Project_19.Models;

/// <summary>
/// Содержит методы и свойства коллекции элементов типа <see cref="Contact"/> из базы данных
/// </summary>
public class DbContacts : IContacts
{
	#region IContacts

	/// <inheritdoc cref="IContacts.GetAsync()"/>
	public async Task<IEnumerable<Contact>> GetAsync()
        => await Context.Contacts.ToListAsync();

	/// <inheritdoc cref="IContacts.GetAsync(int)"/>
	public async Task<Contact?> GetAsync(int id)
        => await Context.Contacts.FirstOrDefaultAsync
            (m => m.Id == id);

	/// <inheritdoc cref="IContacts.FindAsync(int)"/>
	public Task<Contact?> FindAsync(int id)
	    => Context.Contacts.FindAsync(id).AsTask();

	/// <inheritdoc cref="IContacts.AddAsync(Contact)"/>
	public async Task AddAsync(Contact contact)
	{
		Context.Add(contact);
		await Context.SaveChangesAsync();
	}

	/// <inheritdoc cref="IContacts.UpdateAsync(Contact)"/>
	public async Task UpdateAsync(Contact contact)
	{
		try
		{
			Context.Update(contact);
			await Context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException e)
		{
			throw Context.Contacts.Any(c => c.Id == contact.Id) ?
				new Exception(e.Message) :
				new KeyNotFoundException();
		}
	}

	/// <inheritdoc cref="IContacts.RemoveAsync(int)"/>
	public async Task RemoveAsync(int id)
	{
		var contact = await FindAsync(id) ?? 
			throw new KeyNotFoundException();

		Context.Remove(contact);

		await Context.SaveChangesAsync();
	}

	#endregion

    /// <summary>
    /// Контекст элементов типа <see cref="Contact"/>
    /// </summary>
    protected readonly ContactsContext Context;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="context">Контекст контактов</param>
    public DbContacts(ContactsContext context) 
	    => Context = context;
}
