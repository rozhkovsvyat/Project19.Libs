namespace Project_19.Services;

/// <summary>
/// Содержит опции сервиса <see cref="IApi"/>
/// </summary>
public class ApiOptions : IApi
{
	#region IApi

	///<inheritdoc/>
	public string Url { get; set; } = string.Empty;

	///<inheritdoc/>
	public Task<bool> IsAvailable() => Task.FromResult(true);

	#endregion
}
