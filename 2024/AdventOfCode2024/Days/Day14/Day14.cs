using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day14;

public class Day14 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var robots = ParseRobots(input);
        int width = 101, height = 103;

        // Detect sample input (smaller grid)
        if (robots.Count <= 12)
        {
            width = 11;
            height = 7;
        }

        // Simulate 100 seconds
        var finalPositions = robots.Select(r => SimulateRobot(r, 100, width, height)).ToList();

        return CalculateSafetyFactor(finalPositions, width, height).ToString();
    }

    public string SolvePart2(string input)
    {
        var robots = ParseRobots(input);
        int width = 101, height = 103;

        // Find the time when robots form a Christmas tree pattern
        // Heuristic: look for a time when many robots are clustered together
        // The tree pattern likely has low variance or forms a connected component

        for (int t = 1; t <= 10000; t++)
        {
            var positions = robots.Select(r => SimulateRobot(r, t, width, height)).ToList();

            // Check if robots form a pattern (many in same row/column or clustered)
            // A Christmas tree would have many robots in a small area
            if (HasPattern(positions, width, height))
            {
                return t.ToString();
            }
        }

        return "0";
    }

    private List<(int px, int py, int vx, int vy)> ParseRobots(string input)
    {
        var robots = new List<(int, int, int, int)>();
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var match = Regex.Match(line, @"p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)");
            robots.Add((
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value),
                int.Parse(match.Groups[4].Value)
            ));
        }

        return robots;
    }

    private (int x, int y) SimulateRobot((int px, int py, int vx, int vy) robot, int seconds, int width, int height)
    {
        int x = ((robot.px + robot.vx * seconds) % width + width) % width;
        int y = ((robot.py + robot.vy * seconds) % height + height) % height;
        return (x, y);
    }

    private long CalculateSafetyFactor(List<(int x, int y)> positions, int width, int height)
    {
        int midX = width / 2;
        int midY = height / 2;

        long q1 = 0, q2 = 0, q3 = 0, q4 = 0;

        foreach (var (x, y) in positions)
        {
            if (x == midX || y == midY) continue;

            if (x < midX && y < midY) q1++;
            else if (x > midX && y < midY) q2++;
            else if (x < midX && y > midY) q3++;
            else if (x > midX && y > midY) q4++;
        }

        return q1 * q2 * q3 * q4;
    }

    private bool HasPattern(List<(int x, int y)> positions, int width, int height)
    {
        // Look for a pattern where many robots are adjacent to each other
        // A Christmas tree would have many connected robots
        var posSet = new HashSet<(int, int)>(positions);

        int adjacentCount = 0;
        foreach (var (x, y) in positions)
        {
            // Count neighbors
            if (posSet.Contains((x + 1, y))) adjacentCount++;
            if (posSet.Contains((x, y + 1))) adjacentCount++;
        }

        // If many robots have neighbors, likely a pattern
        return adjacentCount > positions.Count / 2;
    }
}
