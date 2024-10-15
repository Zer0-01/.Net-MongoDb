using BarberApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarberApi.Services;

public class ServicesService
{
    private readonly IMongoCollection<Service> _servicesCollection;

    public ServicesService(IOptions<BarberShopDatabaseSettings> barberShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(barberShopDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(barberShopDatabaseSettings.Value.DatabaseName);
        _servicesCollection = mongoDatabase.GetCollection<Service>(barberShopDatabaseSettings.Value.ServicesCollectionName);
    }

    public async Task<List<Service>> GetAsync() =>
    await _servicesCollection.Find(_ => true).ToListAsync();

    public async Task<Service?> GetAsync(string id) =>
    await _servicesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Service newUser) =>
    await _servicesCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, Service updatedUser) =>
    await _servicesCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
    await _servicesCollection.DeleteOneAsync(x => x.Id == id);
}