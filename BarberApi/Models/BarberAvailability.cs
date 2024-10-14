using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarberApi.Models;

public class BarberAvailability
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonRepresentation(BsonType.ObjectId)]
    public string BarberId { get; set; } = null!;

    public string Day { get; set; } = null!;

    public List<string> AvailableSlots { get; set; } = null!;

}