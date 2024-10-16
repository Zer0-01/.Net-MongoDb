using BarberApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarberApi.Services;

public class BarberAvailabilityService
{
    private readonly IMongoCollection<BarberAvailability> _barberAvailabilityCollection;

    public BarberAvailabilityService(IOptions<BarberShopDatabaseSettings> barberShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(barberShopDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(barberShopDatabaseSettings.Value.DatabaseName);
        _barberAvailabilityCollection = mongoDatabase.GetCollection<BarberAvailability>(barberShopDatabaseSettings.Value.BarberAvailabilityCollectionName);
    }

    public async Task<List<BarberAvailability>> GetAsync() =>
    await _barberAvailabilityCollection.Find(_ => true).ToListAsync();

    public async Task<BarberAvailability?> GetAsync(string id) =>
    await _barberAvailabilityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(BarberAvailability newBarberAvailability) =>
    await _barberAvailabilityCollection.InsertOneAsync(newBarberAvailability);

    public async Task UpdateAsync(string id, BarberAvailability updatedBarberAvailability) =>
    await _barberAvailabilityCollection.ReplaceOneAsync(x => x.Id == id, updatedBarberAvailability);

    public async Task RemoveAsync(string id) =>
    await _barberAvailabilityCollection.DeleteOneAsync(x => x.Id == id);
}