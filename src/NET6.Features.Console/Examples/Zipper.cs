namespace NET6.Features.ConsoleApp.Examples;

public class Zipper : IExample
{
	public void StartExample()
	{
		var planets = SpaceService.GetPlanetsOfSolarSystem();
		var planetsNames = planets.Select(planet => planet.Name).ToList();
		var planetsProbes = SpaceService.GetProbesForPlanets(planets);
		var planetsMoons = SpaceService.CountMoonsOfPlanets(planets);

		foreach ((string first, int second, Probe third) in planetsNames.Zip(planetsMoons, planetsProbes))
		{
			PrintResult(first, second, third);
		}
	}

	private void PrintResult(string name, int moons, Probe probe)
	{
		var moonWord = moons == 1 ? "moon" : "moons";

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write($"{name} ");

		Console.ForegroundColor = ConsoleColor.White;
		Console.Write($"has {moons} {moonWord} and was flown over for the first time by ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write($"{probe.Name} in {probe.FlybyDate}\n");
	}
}
