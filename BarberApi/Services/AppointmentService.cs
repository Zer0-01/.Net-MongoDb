using BarberApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarberApi.Services;

public class AppointmentService
{
    private readonly IMongoCollection<Appointment> _appointmentsCollection;

    public AppointmentService(IOptions<BarberShopDatabaseSettings> barberShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(barberShopDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(barberShopDatabaseSettings.Value.DatabaseName);
        _appointmentsCollection = mongoDatabase.GetCollection<Appointment>(barberShopDatabaseSettings.Value.AppointmentsCollectionName);
    }

    public async Task<List<Appointment>> GetAsync() =>
    await _appointmentsCollection.Find(_ => true).ToListAsync();

    public async Task<Appointment?> GetAsync(string id) =>
    await _appointmentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Appointment newAppointment) =>
    await _appointmentsCollection.InsertOneAsync(newAppointment);

    public async Task UpdateAsync(string id, Appointment updatedAppointment) =>
    await _appointmentsCollection.ReplaceOneAsync(x => x.Id == id, updatedAppointment);

    public async Task RemoveAsync(string id) =>
    await _appointmentsCollection.DeleteOneAsync(x => x.Id == id);
}