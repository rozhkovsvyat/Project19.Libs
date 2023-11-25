using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Форма создания <see cref="Role"/>
/// </summary>
public class CreateRoleForm : PropertyChangedNotifier
{
	/// <summary>
	/// Название роли
	/// </summary>
	[Required, MaxLength(15)]
	public string Name
	{
		get => _name;
		set
		{
			_name = value;
			OnPropertyChanged();
		}
	}
	private string _name = string.Empty;

	/// <inheritdoc cref="Name"/>
	public CreateRoleForm ForName(string name)
	{ Name = name; return this; }
}
