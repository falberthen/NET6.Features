namespace NET6.Features.ConsoleApp.Examples;

public class Records : IExample
{
	public void StartExample()
	{
		// Both record class and record struct follows value-based equality semantics

		var gaia = PlanetFactory.Build(1, "Gaia");
		var earth = gaia with { Name = "Earth" }; // a copy with a change

		Console.Write($"\n{gaia.Name} == {earth.Name}: ");
		PrintEqualityResult(earth == gaia);
		PrintObjectCategory(earth.GetType());

		var moonProbe = ProbeFactory.Build(earth.ID, "Luna 1", new DateOnly(1959, 01, 02));
		var luna = moonProbe with { }; // a full-copy

		// Yes, now structs can be printed!
		Console.Write($"\n{luna} == {moonProbe}: ");
		PrintEqualityResult(luna == moonProbe); // == operator with structs!
		PrintObjectCategory(luna.GetType());
	}

	private void PrintEqualityResult(bool areEqual)
	{
		Console.ForegroundColor = areEqual
				? ConsoleColor.Green
				: ConsoleColor.Red;

		Console.Write($"{areEqual}");
	}

	private void PrintObjectCategory(Type spaceObject)
	{
		Console.ForegroundColor = ConsoleColor.White;
		var objectTypeDescription = spaceObject
				.IsValueType
				? "Value"
				: "Reference";

		Console.WriteLine($"\nand it is a {objectTypeDescription} type");
	}
}