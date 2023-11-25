using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Project_19.Models;

/// <summary>
/// Роль Mongo
/// </summary>
[CollectionName("Roles")]
public class MongoRole : MongoIdentityRole<Guid> { }
