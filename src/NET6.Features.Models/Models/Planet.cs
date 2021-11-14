namespace NET6.Features.Models;

// Positional records are immutable
public record class Planet(int ID, string Name, IEnumerable<string>? Moons = null);