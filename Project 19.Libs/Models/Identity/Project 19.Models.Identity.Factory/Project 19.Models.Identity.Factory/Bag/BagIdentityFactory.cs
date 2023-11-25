using Microsoft.Extensions.Options;

namespace Project_19.Models;

/// <summary>
/// Фабрика элементов типа <see cref="CreateAccountWithRoleForm"/>, конфигурируемая <see cref="IOptions{TOptions}"/>
/// </summary>
/// <remarks>TOptions : <see cref="BagIdentityFactoryOptions"/></remarks>
public class BagIdentityFactory : IIdentityFactory
{
	#region IIdentityFactory

	/// <inheritdoc/>
	public IEnumerable<CreateAccountWithRoleForm> Get() => _accounts;

	#endregion

	/// <summary>
	/// Закрытая коллекция элементов типа <see cref="CreateAccountWithRoleForm"/>
	/// </summary>
	private readonly IEnumerable<CreateAccountWithRoleForm> _accounts;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="options">Опции службы <see cref="BagIdentityFactory"/> из конфигурации</param>
	public BagIdentityFactory(IOptions<BagIdentityFactoryOptions> options)
		=> _accounts = options.Value.Get();
}
