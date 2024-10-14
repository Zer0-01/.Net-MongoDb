using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarberApi.Models;

public class Appointment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string CustomerId { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string BarberId { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string ServiceId { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalCost { get; set; }

    public string Notes { get; set; } = null!;

}