namespace NET6.Features.Models.Services;

public static class SpaceService
{
	public static List<Planet> GetPlanetsOfSolarSystem() =>
			PlanetFactory.BuildPlanetsOfSolarSystem()
			.ToList();

	public static List<Planet> GetGasGiantPlanets() =>
			GetPlanetsOfSolarSystem()
			.Where(p => _gasGiants.Contains(p.Name))
			.ToList();

	public static Planet GetPlanetById(int planetID)
	{
		var planet = PlanetFactory.BuildPlanetsOfSolarSystem()?
				.FirstOrDefault(p => p.ID == planetID);

		return planet ??
				PlanetFactory.Build(planetID, "Unknown planet", PlanetFactory.BuildMoonsForUnknownPlanet());
	}

	public static List<Probe> GetProbesForPlanets(IEnumerable<Planet> planets)
	{
		var planetIds = planets.Select(p => p.ID);
		return ProbeFactory.BuildProbesForPlanets()
				.Where(probe => planetIds.Contains(probe.PlanetID))
				.ToList();
	}

	public static List<int> CountMoonsOfPlanets(IEnumerable<Planet> planets)
	{
		var result = new List<int>();
		foreach (var planet in planets)
		{
			var enumerable = planet.Moons ?? new string[] { };
			var count = SmartCounter.Count(enumerable);
			result.Add(count);
		}

		return result;
	}

	private static string[] _gasGiants = {
				"Jupiter",
				"Saturn",
				"Uranus",
				"Neptune"
		};
}