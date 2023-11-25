using System.ComponentModel.DataAnnotations;

namespace Project_19.Models;

/// <summary>
/// Содержит свойства роли
/// </summary>
public class Role
{
	/// <summary>
	/// Название
	/// </summary>
	[Required, MaxLength(15)]
	public string Name { get; set; } = string.Empty;
	/// <summary>
	/// Идентификатор
	/// </summary>
	[Required]
	public string Id { get; set; } = string.Empty;

	/// <inheritdoc/>
	public override string ToString() => Name;
}
