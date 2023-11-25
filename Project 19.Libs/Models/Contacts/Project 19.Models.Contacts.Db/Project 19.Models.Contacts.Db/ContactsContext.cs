using Microsoft.EntityFrameworkCore;

namespace Project_19.Models;

/// <summary>
/// Контекст элементов типа <see cref="Contact"/>
/// </summary>
public class ContactsContext : DbContext
{
	/// <summary>
	/// Сущности типа <see cref="Contact"/>
	/// </summary>
	public DbSet<Contact> Contacts { get; set; } = default!;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции контекста элементов типа <see cref="Contact"/></param>
	public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options) { }
}
