using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Форма создания <see cref="Account"/>
/// </summary>
/// <remarks>Без подтверждения пароля, с возможностью указания названия роли</remarks>
public class CreateAccountWithRoleForm : PropertyChangedNotifier
{
	/// <summary>
	/// Логин
	/// </summary>
	[Required, MaxLength(25)]
	public string Login
	{
		get => _login;
		set
		{
			_login = value;
			OnPropertyChanged();
		}
	}
	private string _login = string.Empty;

	/// <summary>
	/// Электронная почта
	/// </summary>
	[Required, MaxLength(25)]
	[EmailAddress(ErrorMessage = $"Invalid {nameof(Email)}.")]
	public string Email
	{
		get => _email;
		set
		{
			_email = value;
			OnPropertyChanged();
		}
	}
	private string _email = string.Empty;

	/// <summary>
	/// Пароль
	/// </summary>
	[Required, MaxLength(15), DataType(DataType.Password)]
	public string Password
	{
		get => _password;
		set
		{
			_password = value;
			OnPropertyChanged();
		}
	}
	private string _password = string.Empty;

	/// <summary>
	/// Название роли
	/// </summary>
	[ValidateNever]
	public string? RoleName
	{
		get => _roleName;
		set
		{
			_roleName = value;
			OnPropertyChanged();
		}
	}
	private string? _roleName;

	/// <inheritdoc cref="Login"/>
	public CreateAccountWithRoleForm ForLogin(string login)
	{ Login = login; return this; }

	/// <inheritdoc cref="Email"/>
	public CreateAccountWithRoleForm ForEmail(string email)
	{ Email = email; return this; }

	/// <inheritdoc cref="Password"/>
	public CreateAccountWithRoleForm ForPassword(string password)
	{ Password = password; return this; }

	/// <inheritdoc cref="RoleName"/>
	public CreateAccountWithRoleForm ForRole(string? roleName)
	{ RoleName = roleName; return this; }
}
