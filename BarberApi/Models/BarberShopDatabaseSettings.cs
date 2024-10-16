namespace BarberApi.Models;

public class BarberShopDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UsersCollectionName { get; set; } = null!;
    public string ServicesCollectionName { get; set; } = null!;
    public string AppointmentsCollectionName { get; set; } = null!;
    public string BarberAvailabilityCollectionName { get; set; } = null!;
}