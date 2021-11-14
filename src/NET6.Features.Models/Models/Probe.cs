namespace NET6.Features.Models;

// Positional record structs are immutable with readonly
public readonly record struct Probe(int PlanetID, string Name, DateOnly FlybyDate);