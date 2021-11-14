namespace NET6.Features.Models.Services;

public static class SmartCounter
{
	public static int Count<T>(IEnumerable<T> enumerable)
	{
		// Trying to count items without forcing an enumeration
		var canCount = enumerable.TryGetNonEnumeratedCount(out int count);

		if (!canCount)
			throw new InvalidOperationException("Can't count this collection without enumerating it.");

		return count;
	}
}