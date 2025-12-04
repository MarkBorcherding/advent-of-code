using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day13;

public class Day13 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var machines = ParseMachines(input);
        long totalTokens = 0;

        foreach (var m in machines)
        {
            var cost = SolveMachine(m.ax, m.ay, m.bx, m.by, m.px, m.py);
            if (cost.HasValue)
                totalTokens += cost.Value;
        }

        return totalTokens.ToString();
    }

    public string SolvePart2(string input)
    {
        var machines = ParseMachines(input);
        long totalTokens = 0;
        long offset = 10000000000000L;

        foreach (var m in machines)
        {
            var cost = SolveMachine(m.ax, m.ay, m.bx, m.by, m.px + offset, m.py + offset);
            if (cost.HasValue)
                totalTokens += cost.Value;
        }

        return totalTokens.ToString();
    }

    private List<(long ax, long ay, long bx, long by, long px, long py)> ParseMachines(string input)
    {
        var machines = new List<(long, long, long, long, long, long)>();
        var blocks = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (var block in blocks)
        {
            var lines = block.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var aMatch = Regex.Match(lines[0], @"X\+(\d+), Y\+(\d+)");
            var bMatch = Regex.Match(lines[1], @"X\+(\d+), Y\+(\d+)");
            var pMatch = Regex.Match(lines[2], @"X=(\d+), Y=(\d+)");

            machines.Add((
                long.Parse(aMatch.Groups[1].Value),
                long.Parse(aMatch.Groups[2].Value),
                long.Parse(bMatch.Groups[1].Value),
                long.Parse(bMatch.Groups[2].Value),
                long.Parse(pMatch.Groups[1].Value),
                long.Parse(pMatch.Groups[2].Value)
            ));
        }

        return machines;
    }

    private long? SolveMachine(long ax, long ay, long bx, long by, long px, long py)
    {
        // Solve system of linear equations:
        // ax * a + bx * b = px
        // ay * a + by * b = py
        // Using Cramer's rule

        long det = ax * by - ay * bx;
        if (det == 0) return null;

        long detA = px * by - py * bx;
        long detB = ax * py - ay * px;

        if (detA % det != 0 || detB % det != 0)
            return null;

        long a = detA / det;
        long b = detB / det;

        if (a < 0 || b < 0)
            return null;

        return a * 3 + b;
    }
}
