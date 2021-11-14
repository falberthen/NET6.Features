using System.Text.Json;

namespace NET6.Features.Models.Services;

public static class DataDeserializer<T>
{
	public static T? Deserialize(string filePath, JsonSerializerOptions? options = null)
	{
		var jsonString = File.ReadAllText(filePath);
		var result = JsonSerializer.Deserialize<T>(jsonString, options);
		return result;
	}
}