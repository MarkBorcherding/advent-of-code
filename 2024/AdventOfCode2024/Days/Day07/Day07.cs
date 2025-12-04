namespace AdventOfCode2024.Days.Day07;

public class Day07 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long total = 0;

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            long target = long.Parse(parts[0]);
            var nums = parts[1].Trim().Split(' ').Select(long.Parse).ToArray();

            if (CanMakeTarget(target, nums, false))
                total += target;
        }

        return total.ToString();
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long total = 0;

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            long target = long.Parse(parts[0]);
            var nums = parts[1].Trim().Split(' ').Select(long.Parse).ToArray();

            if (CanMakeTarget(target, nums, true))
                total += target;
        }

        return total.ToString();
    }

    private bool CanMakeTarget(long target, long[] nums, bool allowConcat)
    {
        return TryOperators(target, nums, 1, nums[0], allowConcat);
    }

    private bool TryOperators(long target, long[] nums, int idx, long current, bool allowConcat)
    {
        if (idx == nums.Length)
            return current == target;

        // Prune: if current already exceeds target and we can only add/multiply, no point continuing
        // (only valid for positive numbers)
        if (current > target)
            return false;

        // Try addition
        if (TryOperators(target, nums, idx + 1, current + nums[idx], allowConcat))
            return true;

        // Try multiplication
        if (TryOperators(target, nums, idx + 1, current * nums[idx], allowConcat))
            return true;

        // Try concatenation (Part 2)
        if (allowConcat)
        {
            long concat = Concat(current, nums[idx]);
            if (TryOperators(target, nums, idx + 1, concat, allowConcat))
                return true;
        }

        return false;
    }

    private long Concat(long a, long b)
    {
        // Concatenate digits: 12 || 34 = 1234
        long mult = 1;
        long temp = b;
        while (temp > 0)
        {
            mult *= 10;
            temp /= 10;
        }
        if (b == 0) mult = 10; // Handle b=0 case
        return a * mult + b;
    }
}
