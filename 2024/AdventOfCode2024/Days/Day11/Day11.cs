namespace AdventOfCode2024.Days.Day11;

public class Day11 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var stones = input.Trim().Split(' ').Select(long.Parse).ToList();
        return CountStones(stones, 25).ToString();
    }

    public string SolvePart2(string input)
    {
        var stones = input.Trim().Split(' ').Select(long.Parse).ToList();
        return CountStones(stones, 75).ToString();
    }

    private long CountStones(List<long> initialStones, int blinks)
    {
        // Use memoization: count stones by value, not position
        var stoneCounts = new Dictionary<long, long>();

        foreach (var stone in initialStones)
        {
            stoneCounts[stone] = stoneCounts.GetValueOrDefault(stone) + 1;
        }

        for (int i = 0; i < blinks; i++)
        {
            var newCounts = new Dictionary<long, long>();

            foreach (var (stone, count) in stoneCounts)
            {
                foreach (var newStone in Transform(stone))
                {
                    newCounts[newStone] = newCounts.GetValueOrDefault(newStone) + count;
                }
            }

            stoneCounts = newCounts;
        }

        return stoneCounts.Values.Sum();
    }

    private IEnumerable<long> Transform(long stone)
    {
        if (stone == 0)
        {
            yield return 1;
        }
        else
        {
            int digits = CountDigits(stone);
            if (digits % 2 == 0)
            {
                long divisor = (long)Math.Pow(10, digits / 2);
                yield return stone / divisor;
                yield return stone % divisor;
            }
            else
            {
                yield return stone * 2024;
            }
        }
    }

    private int CountDigits(long n)
    {
        if (n == 0) return 1;
        int count = 0;
        while (n > 0)
        {
            count++;
            n /= 10;
        }
        return count;
    }
}
