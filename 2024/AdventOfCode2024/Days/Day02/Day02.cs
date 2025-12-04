namespace AdventOfCode2024.Days.Day02;

public class Day02 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int safeCount = 0;

        foreach (var line in lines)
        {
            var levels = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            if (IsSafe(levels))
                safeCount++;
        }

        return safeCount.ToString();
    }

    private bool IsSafe(int[] levels)
    {
        if (levels.Length < 2) return true;

        bool? increasing = null;

        for (int i = 1; i < levels.Length; i++)
        {
            int diff = levels[i] - levels[i - 1];

            // Check if difference is between 1 and 3 (absolute)
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            // Determine direction
            bool currentIncreasing = diff > 0;

            if (increasing == null)
            {
                increasing = currentIncreasing;
            }
            else if (increasing != currentIncreasing)
            {
                return false;
            }
        }

        return true;
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int safeCount = 0;

        foreach (var line in lines)
        {
            var levels = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            if (IsSafe(levels) || IsSafeWithDampener(levels))
                safeCount++;
        }

        return safeCount.ToString();
    }

    private bool IsSafeWithDampener(int[] levels)
    {
        // Try removing each level one at a time
        for (int i = 0; i < levels.Length; i++)
        {
            var modified = levels.Where((_, index) => index != i).ToArray();
            if (IsSafe(modified))
                return true;
        }
        return false;
    }
}
