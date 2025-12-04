namespace AdventOfCode2024.Days.Day05;

public class Day05 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var (rules, updates) = ParseInput(input);

        int sum = 0;
        foreach (var update in updates)
        {
            if (IsValidOrder(update, rules))
            {
                sum += update[update.Length / 2];
            }
        }

        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        var (rules, updates) = ParseInput(input);

        int sum = 0;
        foreach (var update in updates)
        {
            if (!IsValidOrder(update, rules))
            {
                var sorted = SortUpdate(update, rules);
                sum += sorted[sorted.Length / 2];
            }
        }

        return sum.ToString();
    }

    private (HashSet<(int, int)> rules, int[][] updates) ParseInput(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        var rules = new HashSet<(int, int)>();
        foreach (var line in parts[0].Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var nums = line.Split('|');
            rules.Add((int.Parse(nums[0]), int.Parse(nums[1])));
        }

        var updates = parts[1]
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(',').Select(int.Parse).ToArray())
            .ToArray();

        return (rules, updates);
    }

    private bool IsValidOrder(int[] update, HashSet<(int, int)> rules)
    {
        for (int i = 0; i < update.Length; i++)
        {
            for (int j = i + 1; j < update.Length; j++)
            {
                // If there's a rule saying update[j] must come before update[i], it's invalid
                if (rules.Contains((update[j], update[i])))
                    return false;
            }
        }
        return true;
    }

    private int[] SortUpdate(int[] update, HashSet<(int, int)> rules)
    {
        var list = update.ToList();
        list.Sort((a, b) =>
        {
            if (rules.Contains((a, b))) return -1;
            if (rules.Contains((b, a))) return 1;
            return 0;
        });
        return list.ToArray();
    }
}
