using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarberApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public BarberDetails BarberDetails { get; set; } = null!;
}

public class BarberDetails
{
    public string BarberId { get; set; } = null!;

    public int Experience { get; set; }

    public List<string> Specialties { get; set; } = null!;
}