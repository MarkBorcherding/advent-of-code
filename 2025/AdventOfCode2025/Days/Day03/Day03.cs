namespace AdventOfCode2025.Days.Day03;

public class Day03 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long totalJoltage = 0;

        foreach (var line in lines)
        {
            var maxJoltage = FindMaxJoltage(line);
            totalJoltage += maxJoltage;
        }

        return totalJoltage.ToString();
    }

    private int FindMaxJoltage(string bank)
    {
        int maxJoltage = 0;

        for (int i = 0; i < bank.Length - 1; i++)
        {
            for (int j = i + 1; j < bank.Length; j++)
            {
                int digit1 = bank[i] - '0';
                int digit2 = bank[j] - '0';
                int joltage = digit1 * 10 + digit2;
                maxJoltage = Math.Max(maxJoltage, joltage);
            }
        }

        return maxJoltage;
    }

    private long FindMaxJoltageWithNBatteries(string bank, int n)
    {
        var digits = bank.Select(c => c - '0').ToList();
        int toRemove = digits.Count - n;

        var result = new List<int>(digits);

        for (int removed = 0; removed < toRemove; removed++)
        {
            int removeIndex = -1;

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] < result[i + 1])
                {
                    removeIndex = i;
                    break;
                }
            }

            if (removeIndex == -1)
            {
                removeIndex = result.Count - 1;
            }

            result.RemoveAt(removeIndex);
        }

        long joltage = 0;
        foreach (var digit in result)
        {
            joltage = joltage * 10 + digit;
        }

        return joltage;
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long totalJoltage = 0;

        foreach (var line in lines)
        {
            var maxJoltage = FindMaxJoltageWithNBatteries(line, 12);
            totalJoltage += maxJoltage;
        }

        return totalJoltage.ToString();
    }
}
