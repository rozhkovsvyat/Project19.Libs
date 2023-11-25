using Microsoft.EntityFrameworkCore;

namespace Project_19.Models;

/// <summary>
/// Содержит методы расширения <see cref="MongoIdentity"/>
/// </summary>
public static class MongoIdentityExtensions
{
	/// <inheritdoc cref="EntityFrameworkQueryableExtensions.ToListAsync{TSource}"/>
	public static Task<List<TSource>> ToListAsyncSafe<TSource>(this IQueryable<TSource> source)
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		return source is not IAsyncEnumerable<TSource> 
			? Task.FromResult(source.ToList()) 
			: source.ToListAsync();
	}

	/// <summary>
	/// Приводит <see cref="MongoAccount"/> к типу <see cref="Account"/>
	/// </summary>
	/// <returns><see cref="Account"/></returns>
	public static Account Cast(this MongoAccount mongo) => new () 
	{
		Id = mongo.Id.ToString(),
		Login = mongo.UserName ?? string.Empty,
		Email = mongo.Email ?? string.Empty
	};

	/// <summary>
	/// Редактирует <see cref="MongoAccount"/> используя <see cref="CreateAccountForm"/>
	/// </summary>
	/// <param name="mongo"><see cref="MongoAccount"/></param>
	/// <param name="form">Форма редактирования <see cref="Account"/></param>
	/// <returns><see cref="MongoAccount"/></returns>
	public static MongoAccount Edit(this MongoAccount mongo, CreateAccountForm form)
	{
		mongo.UserName = form.Login;
		mongo.Email = form.Email;
		return mongo;
	}

	/// <summary>
	/// Редактирует <see cref="MongoAccount"/> используя <see cref="Account"/>
	/// </summary>
	/// <param name="mongo"><see cref="MongoAccount"/></param>
	/// <param name="account"><see cref="Account"/></param>
	/// <returns><see cref="MongoAccount"/></returns>
	public static MongoAccount Edit(this MongoAccount mongo, Account account)
	{
		mongo.UserName = account.Login;
		mongo.Email = account.Email;
		return mongo;
	}

	/// <summary>
	/// Приводит коллекцию <see cref="MongoAccount"/> к коллекции типа <see cref="Account"/>
	/// </summary>
	/// <param name="accounts">Коллекция <see cref="MongoAccount"/></param>
	/// <returns>Коллекция <see cref="Account"/> (может быть пустой)</returns>
	public static IEnumerable<Account> Cast(this IEnumerable<MongoAccount> accounts) 
		=> accounts.Select(account => account.Cast());

	/// <summary>
	/// Приводит <see cref="MongoRole"/> к типу <see cref="Role"/>
	/// </summary>
	/// <returns><see cref="Role"/></returns>
	public static Role Cast(this MongoRole mongo) => new()
	{
		Id = mongo.Id.ToString(),
		Name = mongo.Name ?? string.Empty
	};

	/// <summary>
	/// Редактирует <see cref="MongoRole"/> используя <see cref="Role"/>
	/// </summary>
	/// <param name="mongo"><see cref="MongoRole"/></param>
	/// <param name="role"><see cref="Role"/></param>
	/// <returns><see cref="MongoRole"/></returns>
	public static MongoRole Edit(this MongoRole mongo, Role role)
	{
		mongo.Name = role.Name;
		return mongo;
	}

	/// <summary>
	/// Редактирует <see cref="MongoRole"/> используя <see cref="CreateRoleForm"/>
	/// </summary>
	/// <param name="mongo"><see cref="MongoRole"/></param>
	/// <param name="role">Форма создания <see cref="Role"/></param>
	/// <returns><see cref="MongoRole"/></returns>
	public static MongoRole Edit(this MongoRole mongo, CreateRoleForm role)
	{
		mongo.Name = role.Name;
		return mongo;
	}

	/// <summary>
	/// Приводит коллекцию <see cref="MongoRole"/> к коллекции типа <see cref="Role"/>
	/// </summary>
	/// <param name="roles">Коллекция <see cref="MongoRole"/></param>
	/// <returns>Коллекция <see cref="Role"/> (может быть пустой)</returns>
	public static IEnumerable<Role> Cast(this IEnumerable<MongoRole> roles)
		=> roles.Select(role => role.Cast());
}
