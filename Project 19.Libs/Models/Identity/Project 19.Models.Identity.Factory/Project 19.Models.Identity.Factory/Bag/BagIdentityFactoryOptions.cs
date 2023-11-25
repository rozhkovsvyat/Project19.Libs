namespace Project_19.Models;

/// <summary>
/// Содержит конфигурацию фабрики <see cref="BagIdentityFactory"/>
/// </summary>
public class BagIdentityFactoryOptions : IIdentityFactory<CreateAccountWithRoleForm>
{
	#region IIdentityFactory

	/// <inheritdoc/>
	public IEnumerable<CreateAccountWithRoleForm> Get() => Accounts;

	#endregion

	/// <summary>
	/// Коллекция элементов типа <see cref="CreateAccountWithRoleForm"/>
	/// </summary>
	public IEnumerable<CreateAccountWithRoleForm> Accounts { get; set; }
		= Enumerable.Empty<CreateAccountWithRoleForm>();
}
