namespace NET6.Features.ConsoleApp.Examples;

public class ByOperators : IExample
{
	public void StartExample()
	{
		var planets = SpaceService.GetPlanetsOfSolarSystem();
		var gasGiantPlanets = SpaceService.GetGasGiantPlanets();

		Console.ForegroundColor = ConsoleColor.Yellow;

		// MinBy
		PrintLabel("MinBy");
		PrintResult(planets.MinBy(p => p.ID));

		// MaxBy
		PrintLabel("MaxBy");
		PrintResult(planets.MaxBy(p => p.ID));

		// DistinctBy
		var unifiedList = planets.Union(gasGiantPlanets);
		var distinctList = unifiedList.DistinctBy(p => p.Name);
		PrintLabel("DistinctBy");
		PrintResult(distinctList);

		// ExceptBy
		var rockyPlanets = planets.ExceptBy(gasGiantPlanets
			.Select(pUE => pUE.Name), p => p.Name);
		PrintLabel("ExceptBy");
		PrintResult(rockyPlanets);

		// IntersectBy
		var intersectedByName = gasGiantPlanets.IntersectBy(planets
			.Select(c2 => c2.Name), c => c.Name);
		PrintLabel("IntersectBy");
		PrintResult(intersectedByName);

		// UnionBy
		var unifiedByName = gasGiantPlanets.UnionBy(planets,
			x => x.Name).OrderBy(e => e.ID);
		PrintLabel("UnionBy");
		PrintResult(unifiedByName);
	}

	private void PrintResult(IEnumerable<Planet> planets)
	{
		foreach (var planet in planets)
		{
			PrintResult(planet);
		}
	}

	private void PrintResult(Planet planet)
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"{planet.ID} - {planet.Name}");
	}

	private void PrintLabel(string label)
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine($"\n{label}:");
	}
}