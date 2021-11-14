using NET6.Features.Models.Services;
using System.Text.Json;

namespace NET6.Features.Models;

public static class ProbeFactory
{
	public static Probe Build(int planetID, string probeName, DateOnly flybyDate)
	{
		return new Probe(planetID, probeName, flybyDate);
	}

	public static IReadOnlyList<Probe> BuildProbesForPlanets()
	{
		var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
		options.Converters.Add(new DateOnlyConverter());

		var probes = DataDeserializer<List<Probe>>
			.Deserialize(@"data\probes.json", options);

		return probes ?? new List<Probe>();
	}
}