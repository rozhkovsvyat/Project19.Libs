using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Форма смены пароля <see cref="Account"/>
/// </summary>
public class ChangePasswordForm : PropertyChangedNotifier
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
	/// Старый пароль
	/// </summary>
	[Required, MaxLength(15), DataType(DataType.Password)]
	public string OldPassword
	{
		get => _oldPassword;
		set
		{
			_oldPassword = value;
			OnPropertyChanged();
		}
	}
	private string _oldPassword = string.Empty;

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
	/// Подтверждение пароля
	/// </summary>
	[Required, MaxLength(15), DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessage = $"{nameof(Password)} mismatch.")]
	public string ConfirmPassword
	{
		get => _confirmPassword;
		set
		{
			_confirmPassword = value;
			OnPropertyChanged();
		}
	}
	private string _confirmPassword = string.Empty;

	/// <inheritdoc cref="Login"/>
	public ChangePasswordForm ForLogin(string login)
	{ Login = login; return this; }

	/// <inheritdoc cref="OldPassword"/>
	public ChangePasswordForm ForOldPassword(string password)
	{ OldPassword = password; return this; }

	/// <inheritdoc cref="Password"/>
	public ChangePasswordForm ForNewPassword(string password)
	{ Password = ConfirmPassword = password; return this; }
}
