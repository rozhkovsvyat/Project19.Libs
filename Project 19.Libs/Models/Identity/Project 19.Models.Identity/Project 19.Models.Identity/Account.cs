using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Содержит свойства аккаунта
/// </summary>
public class Account : PropertyChangedNotifier
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
	/// Идентификатор
	/// </summary>
	[Required]
	public string Id
	{
		get => _id;
		set
		{
			_id = value;
			OnPropertyChanged();
		}
	}
	private string _id = string.Empty;
}
