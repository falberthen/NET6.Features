using System.Diagnostics;

namespace NET6.Features.ConsoleApp.Examples;

public class Counter : IExample
{
	public void StartExample()
	{
		bool continueCounting;
		var watch = new Stopwatch();

		do
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\nEnter the ID of the planet you want to count moons \n(-1 to quit)\n");

			int.TryParse(Console.ReadLine(), out int planetID);
			continueCounting = planetID >= 0;
			if (!continueCounting)
				break;

			var planet = SpaceService.GetPlanetById(planetID);

			try
			{
				watch.Start();
				var count = SmartCounter.Count(planet.Moons);
				PrintWatchResult($"Elapsed time with TryGetNonEnumeratedCount", watch.Elapsed);

				watch.Start();
				count = planet.Moons.Count();
				PrintWatchResult($"Elapsed time with Count():", watch.Elapsed);

				PrintResult(planet.Name, count);
			}
			catch (InvalidOperationException ex)
			{
				PrintErrorResult($"{planet.Name}: {ex.Message}");
			}
		}
		while (continueCounting);
	}

	private void PrintWatchResult(string message, TimeSpan elapsedTime)
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write($"\n{message} ");

		Console.ForegroundColor = ConsoleColor.Blue;
		Console.Write($"{elapsedTime}");
	}

	private void PrintResult(string name, int moons)
	{
		var moonWord = moons == 1 ? "moon" : "moons";

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write($"\n{name} ");

		Console.ForegroundColor = ConsoleColor.White;
		Console.Write($"has {moons} {moonWord}\n");
	}

	private void PrintErrorResult(string errorMessage)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.Write($"{errorMessage}\n");
	}
}