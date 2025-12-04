namespace AdventOfCode2024.Days.Day19;

public class Day19 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var (patterns, designs) = ParseInput(input);
        int count = 0;
        foreach (var design in designs)
        {
            if (CanMake(design, patterns, []) > 0)
                count++;
        }
        return count.ToString();
    }

    public string SolvePart2(string input)
    {
        var (patterns, designs) = ParseInput(input);
        long total = 0;
        foreach (var design in designs)
        {
            total += CanMake(design, patterns, []);
        }
        return total.ToString();
    }

    private (HashSet<string> patterns, List<string> designs) ParseInput(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var patterns = parts[0].Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(p => p.Trim())
                               .ToHashSet();
        var designs = parts[1].Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        return (patterns, designs);
    }

    private long CanMake(string design, HashSet<string> patterns, Dictionary<string, long> memo)
    {
        if (design.Length == 0)
            return 1;

        if (memo.TryGetValue(design, out long cached))
            return cached;

        long ways = 0;
        for (int len = 1; len <= design.Length; len++)
        {
            var prefix = design[..len];
            if (patterns.Contains(prefix))
            {
                ways += CanMake(design[len..], patterns, memo);
            }
        }

        memo[design] = ways;
        return ways;
    }
}
