namespace Project_19.Models;

/// <summary>
/// Предоставляет свойства фабрики элементов типа <see cref="CreateAccountWithRoleForm"/>
/// </summary>
public interface IIdentityFactory : IIdentityFactory<CreateAccountWithRoleForm> { }

/// <summary>
/// Предоставляет свойства фабрики элементов типа <see cref="CreateAccountWithRoleForm"/>
/// </summary>
public interface IIdentityFactory<out T> where T : CreateAccountWithRoleForm
{
	/// <summary>
	/// Возвращает коллекцию элементов типа <see cref="CreateAccountWithRoleForm"/>
	/// </summary>
	IEnumerable<T> Get();
}
