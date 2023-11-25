namespace Project_19.Services;

/// <summary>
/// Содержит опции службы <see cref="SocialBar"/>
/// </summary>
public class SocialBarOptions : IUrlButtonService<UrlButton, UrlScript>
{
	#region IUrlButtonService

	/// <inheritdoc/>
	public IEnumerable<UrlScript> Scripts { get; set; } = Enumerable.Empty<UrlScript>();
	/// <inheritdoc/>
	public IEnumerable<UrlButton> Buttons { get; set; } = Enumerable.Empty<UrlButton>();

	#endregion
}
