namespace Project_19.Services;

/// <summary>
/// Содержит свойства ссылки на скрипт
/// </summary>
public class UrlScript : IUrlScript
{
	#region IUrlScript

	/// <inheritdoc/>
	public string CrossOrigin { get; set; } = string.Empty;
	/// <inheritdoc/>
	public string Url { get; set; } = string.Empty;

	#endregion
}
