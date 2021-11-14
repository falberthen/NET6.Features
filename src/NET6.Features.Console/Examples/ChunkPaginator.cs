namespace NET6.Features.ConsoleApp.Examples;

public class ChunkPaginator : IExample
{
	const int pageSize = 3;
	int pageNumber, totalPages;
	IEnumerable<Planet[]> chunks;

	public void StartExample()
	{
		bool continuePaging;

		// Chunked results
		chunks = SpaceService.GetPlanetsOfSolarSystem()
				.Chunk(pageSize);

		totalPages = chunks.Count();

		do
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\nEnter the page number between 0 and {totalPages} \n(-1 to quit)\n");

			int.TryParse(Console.ReadLine(), out pageNumber);
			continuePaging = pageNumber >= 0;
			if (!continuePaging)
				break;

			Paginate();
		}
		while (continuePaging);
	}

	private void Paginate()
	{
		// ElementAtOrDefault will return the Reference Type default value (null)
		// in case of the index is Out of Range
		var pageResults = chunks.ElementAtOrDefault(pageNumber);

		if (pageResults is not null)
		{
			PrintResult(pageResults);
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Page {pageNumber} is out of range!");
		}
	}

	private void PrintResult(Planet[] paginatedResult)
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"Page {pageNumber}");

		foreach (var planet in paginatedResult.OrderBy(e => e.ID))
		{
			Console.WriteLine($"{planet.ID} - {planet.Name}");
		}
	}
}