using BarberApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarberApi.Services;

public class UsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(IOptions<BarberShopDatabaseSettings> barberShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(barberShopDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(barberShopDatabaseSettings.Value.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(barberShopDatabaseSettings.Value.UsersCollectionName);
    }

    public async Task<List<User>> GetAsync() =>
    await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
    await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
    await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
    await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
    await _usersCollection.DeleteOneAsync(x => x.Id == id);
}