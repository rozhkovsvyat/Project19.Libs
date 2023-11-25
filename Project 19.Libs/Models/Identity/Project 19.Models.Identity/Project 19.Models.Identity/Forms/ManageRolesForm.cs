using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_19.Models;

/// <summary>
/// Форма коллекции <see cref="Role"/> элемента <see cref="Account"/>
/// </summary>
public class ManageRolesForm : PropertyChangedNotifier
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
	/// Коллекция <see cref="Role"/>
	/// </summary>
	[Required]
	public SelectList Roles { get; set; } = new (Enumerable.Empty<Role>());

	/// <summary>
	/// Имя выбранной <see cref="Role"/>
	/// </summary>
	[Required, MaxLength(15)]
	public string RoleName
	{
		get => _roleName;
		set
		{
			_roleName = value;
			OnPropertyChanged();
		}
	}
	private string _roleName = string.Empty;

	/// <inheritdoc cref="Login"/>
	public ManageRolesForm ForLogin(string login)
	{ Login = login; return this; }

	/// <inheritdoc cref="Roles"/>
	public ManageRolesForm ForRoles(IEnumerable<Role>? roles)
	{ Roles = new SelectList(roles); return this; }

	/// <inheritdoc cref="RoleName"/>
	public ManageRolesForm ForRoleName(string name)
	{ RoleName = name; return this; }
}
