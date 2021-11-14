global using System;
global using System.Linq;
global using System.Collections.Generic;
global using NET6.Features.Models;
global using NET6.Features.ConsoleApp.Examples;
global using NET6.Features.Models.Services;

namespace NET6.Features.ConsoleApp;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("\tChoose an option:");
		Console.WriteLine("\t---------------------------\n");
		Console.WriteLine("\t 1) Chunk Paginator \n");
		Console.WriteLine("\t 2) ByOperators \n");
		Console.WriteLine("\t 3) Records \n");
		Console.WriteLine("\t 4) Three-way Zip \n");
		Console.WriteLine("\t 5) TryGetNonEnumeratedCount \n");

		int choice = int.Parse(Console.ReadLine().ToString());

		IExample output = choice switch
		{
			1 => new ChunkPaginator(),
			2 => new ByOperators(),
			3 => new Records(),
			4 => new Zipper(),
			5 => new Counter(),
			_ => throw new ArgumentException("Invalid option."),
		};

		output.StartExample();
	}
}