namespace Project_19.Models;

/// <summary>
/// Простая фабрика элементов типа <see cref="CreateAccountWithRoleForm"/>
/// </summary>
public class SimpleIdentityFactory : IIdentityFactory
{
	#region IIdentityFactory

	/// <inheritdoc />
	public IEnumerable<CreateAccountWithRoleForm> Get() => new[] 
	{
		Form.ForLogin("admin")
			.ForEmail("example@gmail.com")
			.ForPassword("admin123+")
			.ForRole("admin"),

		Form.ForLogin("default")
			.ForEmail("default@gmail.com")
			.ForPassword("default321-")
	};

	#endregion

	private static CreateAccountWithRoleForm Form => new();
}
