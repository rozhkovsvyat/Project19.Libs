namespace Project_19.Services;

/// <summary>
/// Содержит свойства кнопки-ссылки
/// </summary>
public class UrlButton : IUrlButton
{
	#region IUrlButton

	/// <inheritdoc/>
	public string Title { get; set; } = string.Empty;
	/// <inheritdoc/>
	public string Color { get; set; } = string.Empty;
	/// <inheritdoc/>
	public string Icss { get; set; } = string.Empty;
	/// <inheritdoc/>
	public string Url { get; set; } = string.Empty;

	#endregion
}
