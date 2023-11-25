namespace Project_19.Models;

/// <summary>
/// Простая фабрика элементов типа <see cref="Contact"/>
/// </summary>
public class SimpleContactsFactory : IContactsFactory
{
    #region IContactsFactory

    /// <inheritdoc/>
    public IEnumerable<Contact> Get()
    {
        return new Contact[]
        {
            new() { Id = 1, LastName = "Bekmambetov", FirstName = "Dmitriy", Patronymic = "Alexeevich",
                MobileNumber = "+79867860639", Address = "Moscow, Altufievskoe sh. 131-335", Description = "CEO" },
            new() { Id = 2, LastName = "Trofimova", FirstName = "Viktoriya", Patronymic = "Nikolaevna",
                MobileNumber = "+79191498166", Address = "Saint-Petersburg, Nevskiy pr. 71-12", Description = "Senior C#-developer" },
            new() { Id = 3, LastName = "Agutin", FirstName = "Efim", Patronymic = "Stanislavovich",
                MobileNumber = "+79457900301", Address = "Kazan, Baumana 2B-99", Description = "HR" }
        }.SetCreatedBy($"[{nameof(SimpleContactsFactory)}]");
    }

    #endregion

}
