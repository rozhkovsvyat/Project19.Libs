namespace Project_19.Models;

/// <summary>
/// Предоставляет методы и свойства работы с аккаунтами пользователей
/// </summary>
public interface IIdentity
{
	#region Forms

	/// <inheritdoc cref="Models.CreateAccountForm"/>
	CreateAccountForm CreateAccountForm { get; }

	/// <inheritdoc cref="Models.ChangePasswordForm"/>
	ChangePasswordForm ChangePasswordForm { get; }

	/// <inheritdoc cref="Models.SignInForm"/>
	SignInForm SignInForm { get; }

	/// <inheritdoc cref="Models.ManageRolesForm"/>
	ManageRolesForm ManageRolesForm { get; }

	/// <inheritdoc cref="Models.CreateRoleForm"/>
	CreateRoleForm CreateRoleForm { get; }

	#endregion

	#region SignIn

	/// <summary>
	/// Обновляет пароль <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="form">Форма создания пароля <see cref="Account"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task UpdatePasswordAsync(ChangePasswordForm form);

	/// <summary>
	/// Выполняет вход в <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="form">Форма входа в <see cref="Account"/></param>
	/// <returns>Токен аутентификации</returns>
	/// <exception cref="InvalidOperationException"></exception>
	Task<string> SignInAsync(SignInForm form);

	/// <summary>
	/// Выполняет выход из <see cref="Account"/>
	/// </summary>
	Task SignOutAsync();

	#endregion

	#region Account

	/// <summary>
	/// Запрашивает коллекцию элементов типа <see cref="Account"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Account"/> (может быть пустой)</returns>
	Task<IEnumerable<Account>> GetAsync();

	/// <summary>
	/// Запрашивает <see cref="Account"/> по идентификатору
	/// </summary>
	/// <param name="id">Идентификатор</param>
	/// <returns><see cref="Account"/>?</returns>
	Task<Account?> GetByIdAsync(string id);

	/// <summary>
	/// Запрашивает <see cref="Account"/> по логину
	/// </summary>
	/// <param name="login">Логин</param>
	/// <returns><see cref="Account"/>?</returns>
	Task<Account?> GetByLoginAsync(string login);

	/// <summary>
	/// Выполняет создание <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="form">Форма создания <see cref="Account"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	Task AddAsync(CreateAccountForm form);

	/// <summary>
	/// Обновляет <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="account">Обновленный <see cref="Account"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task UpdateAsync(Account account);

	/// <summary>
	/// Удаляет <see cref="Account"/> по идентификатору
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="id">Идентификатор</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveByIdAsync(string id);

	/// <summary>
	/// Удаляет <see cref="Account"/> по логину
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="login">Идентификатор</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveByLoginAsync(string login);

	#endregion

	#region Role

	/// <summary>
	/// Запрашивает коллекцию элементов типа <see cref="Role"/>
	/// </summary>
	/// <returns>Коллекция элементов типа <see cref="Role"/> (может быть пустой)</returns>
	Task<IEnumerable<Role>> GetRolesAsync();

	/// <summary>
	/// Запрашивает коллекцию <see cref="Role"/> у <see cref="Account"/>
	/// </summary>
	/// <param name="login">Логин</param>
	/// <returns>Коллекция элементов типа <see cref="Role"/> (может быть пустой)</returns>
	/// <exception cref="KeyNotFoundException"></exception>
	Task<IEnumerable<Role>> GetRolesAsync(string login);

	/// <summary>
	/// Запрашивает коллекцию <see cref="Role"/>, доступных для добавления <see cref="Account"/>
	/// </summary>
	/// <param name="login">Логин</param>
	/// <returns>Коллекция элементов типа <see cref="Role"/> (может быть пустой)</returns>
	/// <exception cref="KeyNotFoundException"></exception>
	Task<IEnumerable<Role>> GetAvailableRolesAsync(string login);

	/// <summary>
	/// Запрашивает <see cref="Role"/> по названию
	/// </summary>
	/// <param name="name">Название</param>
	/// <returns><see cref="Role"/>?</returns>
	Task<Role?> GetRoleByNameAsync(string name);

	/// <summary>
	/// Запрашивает <see cref="Role"/> по идентификатору
	/// </summary>
	/// <param name="id">Идентификатор</param>
	/// <returns><see cref="Role"/>?</returns>
	Task<Role?> GetRoleByIdAsync(string id);

	/// <summary>
	/// Выполняет создание <see cref="Role"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="form">Форма создания <see cref="Role"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	Task AddRoleAsync(CreateRoleForm form);

	/// <summary>
	/// Обновляет <see cref="Role"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="role">Обновленная <see cref="Role"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task UpdateRoleAsync(Role role);

	/// <summary>
	/// Удаляет <see cref="Role"/> по названию
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="name">Название</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveRoleByNameAsync(string name);

	/// <summary>
	/// Удаляет <see cref="Role"/> по идентификатору
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="id">Идентификатор</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveRoleByIdAsync(string id);

	/// <summary>
	/// Добавляет <see cref="Role"/> указанному <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="login">Логин</param>
	/// <param name="roleName">Название роли</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task AddToRoleAsync(string login, string roleName);

	/// <summary>
	/// Добавляет коллекцию <see cref="Role"/> указанному <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="login"><see cref="Account"/></param>
	/// <param name="roleNames">Коллекция названий <see cref="Role"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task AddToRolesAsync(string login, IEnumerable<string> roleNames);

	/// <summary>
	/// Удаляет <see cref="Role"/> у указанного <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="login">Логин</param>
	/// <param name="roleName">Название роли</param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveFromRoleAsync(string login, string roleName);

	/// <summary>
	/// Удаляет коллекцию <see cref="Role"/> у указанного <see cref="Account"/>
	/// </summary>
	/// <remarks>При возникновении <see cref="InvalidOperationException"/> для получения
	/// списка ошибок используйте <see cref="IdentityExtensions.Deserialize"/></remarks>
	/// <param name="login"><see cref="Account"/></param>
	/// <param name="roleNames">Коллекция названий <see cref="Role"/></param>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="KeyNotFoundException"></exception>
	Task RemoveFromRolesAsync(string login, IEnumerable<string> roleNames);

	#endregion
}
