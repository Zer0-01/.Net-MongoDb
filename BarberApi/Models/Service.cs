using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarberApi.Models;

public class Service
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Duration { get; set; }
}