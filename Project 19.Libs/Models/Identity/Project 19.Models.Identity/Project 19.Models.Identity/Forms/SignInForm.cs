using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Форма входа в <see cref="Account"/>
/// </summary>
public class SignInForm : PropertyChangedNotifier
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
	public SignInForm ForLogin(string login)
	{ Login = login; return this; }

	/// <inheritdoc cref="Password"/>
	public SignInForm ForPassword(string password)
	{ Password = password; return this; }

	/// <inheritdoc cref="ReturnUrl"/>
	public SignInForm ForReturnUrl(string? url)
	{ ReturnUrl = url; return this; }
}
