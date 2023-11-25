namespace Project_19.Models;

/// <summary>
/// Фабрика случайного числа элементов типа <see cref="Contact"/>
/// </summary>
public class RandomContactsFactory : IContactsFactory
{
    #region IContactsFactory

    /// <inheritdoc/>
    public IEnumerable<Contact> Get()
    {
        var result = new Random().Next(3) switch
        { 0 => GetThree(), 1 => GetFive(), _ => GetEight() };
        return result.SetAutoId().SetAutoDescription()
	        .SetCreatedBy($"[{nameof(RandomContactsFactory)}]");
    }

	#endregion

	/// <summary>
	/// Возвращает коллекцию из трех элементов типа <see cref="Contact"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Contact"/></returns>
	private static IEnumerable<Contact> GetThree()
    {
        return new Contact[]
        {
            new() { LastName = "Vasnetsov", FirstName = "Arkadiy", Patronymic = "Yurievich",
                MobileNumber = "+79228744090", Address = "Nizhniy Novgorod, Pokrovskaya 78-342" },
            new() { LastName = "Semenova", FirstName = "Darya", Patronymic = "Markovna",
                MobileNumber = "+79815467184", Address = "Ulan-Ude, Smolina 1c3-54" },
            new() { LastName = "Karpova", FirstName = "Elena", Patronymic = "Aleksandrovna",
                MobileNumber = "+79037036891", Address = "Taganrog, Chehova 66/2-3" },
        };
    }

	/// <summary>
	/// Возвращает коллекцию из пяти элементов типа <see cref="Contact"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Contact"/></returns>
	private static IEnumerable<Contact> GetFive()
    {
        return new Contact[]
		{
            new() { LastName = "Fedorov", FirstName = "Ilya", Patronymic = "Pavlovich",
                MobileNumber = "+79561782991", Address = "Novosibirsk, Vysotskogo 3-15" },
            new() { LastName = "Ivanova", FirstName = "Yulia", Patronymic = "Egorovna",
                MobileNumber = "+79137840329", Address = "Tomsk, Beringa 27-240" },
            new() { LastName = "Anisimov", FirstName = "Stanislav", Patronymic = "Glebovich",
                MobileNumber = "+79515896578", Address = "Ryazan, Lenina 4A-43" },
            new() { LastName = "Dibrov", FirstName = "Vlas", Patronymic = "Albertovich",
                MobileNumber = "+79771874107", Address = "Perm, Soldatova 1-29" },
            new() { LastName = "Nefedova", FirstName = "Mariya", Patronymic = "Yakovlevna",
                MobileNumber = "+79160945366", Address = "Samara, Gagarina 92-7" }
        };
    }

	/// <summary>
	/// Возвращает коллекцию из семи элементов типа <see cref="Contact"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Contact"/></returns>
	private static IEnumerable<Contact> GetEight() => GetThree().Join(GetFive());
}
