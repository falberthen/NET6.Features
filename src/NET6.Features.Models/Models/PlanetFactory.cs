using NET6.Features.Models.Services;

namespace NET6.Features.Models;

public static class PlanetFactory
{
	public static Planet Build(int planetID, string planetName, IEnumerable<string>? moons = null)
	{
		return new Planet(planetID, planetName, moons);
	}

	public static IReadOnlyList<Planet> BuildPlanetsOfSolarSystem()
	{
		var solarSystem = DataDeserializer<List<Planet>>
				.Deserialize(@"data\planets.json");

		return solarSystem ?? new List<Planet>();
	}

	public static IEnumerable<string> BuildMoonsForUnknownPlanet()
	{
		yield return "Unknown Moon 1";
		yield return "Unknown Moon 2";
		yield return "Unknown Moon 3";
	}
}