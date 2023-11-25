using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Форма создания <see cref="Account"/>
/// </summary>
/// <remarks>С подтверждением пароля</remarks>
public class CreateAccountForm : PropertyChangedNotifier
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

	/// <summary>
	/// Адрес страницы возврата
	/// </summary>
	[ValidateNever]
    public string? ReturnUrl
	{
		get => _returnUrl;
		set
		{
			_returnUrl = value;
			OnPropertyChanged();
		}
	}
	private string? _returnUrl;

	/// <inheritdoc cref="Login"/>
	public CreateAccountForm ForLogin(string login)
	{ Login = login; return this; }

	/// <inheritdoc cref="Email"/>
	public CreateAccountForm ForEmail(string email)
	{ Email = email; return this; }

	/// <inheritdoc cref="Password"/>
	public CreateAccountForm ForPassword(string password)
	{ Password = ConfirmPassword = password; return this; }

    /// <inheritdoc cref="ReturnUrl"/>
    public CreateAccountForm ForReturnUrl(string? url)
    { ReturnUrl = url; return this; }
}
