using System.Security.Authentication;

namespace Project_19.Services;

/// <summary>
/// <inheritdoc cref="AuthenticationException"/>
/// </summary>
/// <remarks>Invokes action if exists.</remarks>
public class UnauthorizedException : AuthenticationException
{
	/// <inheritdoc cref="AuthenticationException()"/>
	public UnauthorizedException(Action? action = null) => action?.Invoke();
}
