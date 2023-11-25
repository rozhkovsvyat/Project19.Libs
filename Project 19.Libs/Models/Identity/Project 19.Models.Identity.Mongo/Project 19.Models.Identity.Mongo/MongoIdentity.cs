using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

using System.Text;

namespace Project_19.Models;

/// <summary>
/// Содержит методы и свойства идентификации Mongo
/// </summary>
public class MongoIdentity : IIdentity
{
	#region Identity

	///<inheritdoc/>
	public ChangePasswordForm ChangePasswordForm => new();
	///<inheritdoc/>	
	public CreateAccountForm CreateAccountForm => new();
	///<inheritdoc/>
	public SignInForm SignInForm => new();
	///<inheritdoc/>
	public ManageRolesForm ManageRolesForm => new();
	///<inheritdoc/>
	public CreateRoleForm CreateRoleForm => new();

	#region IIdentity [Account]

	/// <inheritdoc/>
	public async Task<IEnumerable<Account>> GetAsync()
		=> (await UserManager.Users.ToListAsyncSafe()).Cast();

	/// <inheritdoc/>
	public async Task<Account?> GetByIdAsync(string id)
		=> (await UserManager.FindByIdAsync(id))?.Cast();

	/// <inheritdoc/>
	public async Task<Account?> GetByLoginAsync(string login)
		=> (await UserManager.FindByNameAsync(login))?.Cast();

	/// <inheritdoc/>
	public async Task AddAsync(CreateAccountForm form)
	{
		var mongo = new MongoAccount().Edit(form);

		var result = await UserManager.CreateAsync
			(mongo, form.Password);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task UpdateAsync(Account account)
	{
		var mongo = await UserManager
			.FindByNameAsync(account.Login);

		if (mongo != null && mongo.Id.ToString() != account.Id)
			throw new InvalidOperationException("Login already exists.");

		mongo = await UserManager.FindByIdAsync(account.Id) ??
					  throw new KeyNotFoundException();

		var result = await UserManager.UpdateAsync(mongo.Edit(account));

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task UpdatePasswordAsync(ChangePasswordForm form)
	{
		var mongo = await UserManager.FindByNameAsync(form.Login) ??
					  throw new KeyNotFoundException();

		var result = await UserManager.ChangePasswordAsync
			(mongo, form.OldPassword, form.Password);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveByIdAsync(string id)
	{
		var mongo = await UserManager.FindByIdAsync(id) ??
					  throw new KeyNotFoundException();

		var result = await UserManager.DeleteAsync(mongo);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveByLoginAsync(string login)
	{
		var mongo = await UserManager.FindByNameAsync(login) ??
					  throw new KeyNotFoundException();

		var result = await UserManager.DeleteAsync(mongo);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task<string> SignInAsync(SignInForm form)
	{
		var result = await SignInManager.PasswordSignInAsync(form.Login, form.Password, true, false);

		if (!result.Succeeded) throw new InvalidOperationException();

		List<Claim> claims;
		try
		{
			var acc = await GetByLoginAsync(form.Login) ?? throw new KeyNotFoundException();
			var roles = await GetRolesAsync(acc.Login);

			claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, acc.Id),
				new Claim(ClaimTypes.Name, acc.Login),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, acc.Id)
			};

			claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));
		}
		catch (KeyNotFoundException) { throw new InvalidOperationException(); }

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenOptions.Key));

		var token = new JwtSecurityToken(
			issuer: TokenOptions.Issuer,
			audience: TokenOptions.Audience,
			claims: claims,
			expires: DateTime.Now.AddMinutes(30),
			signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	/// <inheritdoc/>
	public async Task SignOutAsync()
		=> await SignInManager.SignOutAsync();

	#endregion

	#region IIdentity [Roles]

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetRolesAsync()
		=> (await RoleManager.Roles.ToListAsyncSafe()).Cast();

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetRolesAsync(string login)
	{
		var mongoAcc = await UserManager.FindByNameAsync(login) ??
				  throw new KeyNotFoundException();

		var mongoRoleAccNames = await UserManager.GetRolesAsync(mongoAcc);
		var mongoRoles = await RoleManager.Roles.ToListAsyncSafe();

		return mongoRoles.Where(role => mongoRoleAccNames.FirstOrDefault
			(n => n == role.Name) != null).Cast();
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<Role>> GetAvailableRolesAsync(string login)
	{
		var mongoAcc = await UserManager.FindByNameAsync(login) ??
				  throw new KeyNotFoundException();

		var mongoRoleAccNames = await UserManager.GetRolesAsync(mongoAcc);
		var mongoRoles = await RoleManager.Roles.ToListAsyncSafe();

		return mongoRoles.Where(role => mongoRoleAccNames.FirstOrDefault
			(n => n == role.Name) == null).Cast();
	}

	/// <inheritdoc/>
	public async Task<Role?> GetRoleByNameAsync(string name)
		=> (await RoleManager.Roles.ToListAsyncSafe())
			.FirstOrDefault(r => r.Name == name)?
			.Cast();

	/// <inheritdoc/>
	public async Task<Role?> GetRoleByIdAsync(string id)
		=> (await RoleManager.Roles.ToListAsyncSafe())
			.FirstOrDefault(r => r.Id.ToString() == id)?
			.Cast();

	/// <inheritdoc/>
	public async Task AddRoleAsync(CreateRoleForm form)
	{
		if (await RoleManager.RoleExistsAsync(form.Name))
			throw new InvalidOperationException($"Role \"{form.Name}\" already exists.");

		var result = await RoleManager.CreateAsync(new MongoRole().Edit(form));

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task UpdateRoleAsync(Role role)
	{
		var mongo = await RoleManager
			.FindByNameAsync(role.Name);

		if (mongo != null && mongo.Id.ToString() != role.Id)
			throw new InvalidOperationException("Role already exists.");

		mongo = (await RoleManager.Roles.ToListAsyncSafe())
				.FirstOrDefault(r => r.Id.ToString() == role.Id) ??
				throw new KeyNotFoundException();

		var result = await RoleManager.UpdateAsync(mongo.Edit(role));

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveRoleByNameAsync(string name)
	{
		var mongo = (await RoleManager.Roles.ToListAsyncSafe())
			.FirstOrDefault(r => r.Name == name) ??
			throw new KeyNotFoundException();

		var result = await RoleManager.DeleteAsync(mongo);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveRoleByIdAsync(string id)
	{
		var mongo = (await RoleManager.Roles.ToListAsyncSafe())
			.FirstOrDefault(r => r.Id.ToString() == id) ??
			throw new KeyNotFoundException();

		var result = await RoleManager.DeleteAsync(mongo);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task AddToRoleAsync(string login, string roleName)
	{
		var account = await UserManager.FindByNameAsync(login) ??
					  throw new KeyNotFoundException(nameof(login));

		var result = await UserManager.AddToRoleAsync(account, roleName);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task AddToRolesAsync(string login, IEnumerable<string> roleNames)
	{
		var account = await UserManager.FindByNameAsync(login) ??
					  throw new KeyNotFoundException(nameof(login));

		var result = await UserManager.AddToRolesAsync(account, roleNames);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveFromRoleAsync(string login, string roleName)
	{
		var account = await UserManager.FindByNameAsync(login) ??
				  throw new KeyNotFoundException(nameof(login));

		var result = await UserManager.RemoveFromRoleAsync(account, roleName);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	/// <inheritdoc/>
	public async Task RemoveFromRolesAsync(string login, IEnumerable<string> roleNames)
	{
		var mongoAcc = await UserManager.FindByNameAsync(login) ??
				  throw new KeyNotFoundException();

		var result = await UserManager.RemoveFromRolesAsync(mongoAcc, roleNames);

		if (!result.Succeeded) throw new InvalidOperationException
			(result.Errors.Select(error => error.Description).Serialize());
	}

	#endregion

	#endregion

	/// <summary>
	/// Менеджер авторизации
	/// </summary>
	protected readonly SignInManager<MongoAccount> SignInManager;
	/// <summary>
	/// Менеджер пользователей
	/// </summary>
	protected readonly UserManager<MongoAccount> UserManager;
	/// <summary>
	/// Менеджер ролей
	/// </summary>
	protected readonly RoleManager<MongoRole> RoleManager;
	/// <summary>
	/// Опции токена аутентификации
	/// </summary>
	protected readonly IdentityTokenOptions TokenOptions;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="signInManager">Менеджер авторизации</param>
	/// <param name="userManager">Менеджер пользователей</param>
	/// <param name="roleManager">Менеджер ролей</param>
	/// <param name="tokenOptions">Опции токена аутентификации</param>
	public MongoIdentity(SignInManager<MongoAccount> signInManager, 
		UserManager<MongoAccount> userManager, RoleManager<MongoRole> roleManager, 
		IOptions<IdentityTokenOptions> tokenOptions)
	{
		SignInManager = signInManager;
		UserManager = userManager;
		RoleManager = roleManager;
		TokenOptions = tokenOptions.Value;
	}
}
