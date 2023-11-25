using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Project_19.Models;

/// <summary>
/// Аккаунт Mongo
/// </summary>
[CollectionName("Accounts")]
public class MongoAccount : MongoIdentityUser<Guid> { }
