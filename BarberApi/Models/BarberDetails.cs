namespace BarberApi.Models;

public class BarberDetails
{
    public string BarberId { get; set; } = null!;

    public int Experience { get; set; }

    public List<string> Specialties { get; set; } = null!;
}