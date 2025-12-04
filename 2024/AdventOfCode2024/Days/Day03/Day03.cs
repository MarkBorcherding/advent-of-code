using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day03;

public class Day03 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        var matches = regex.Matches(input);

        long sum = 0;
        foreach (Match match in matches)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }

        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        // Match mul(X,Y), do(), and don't() instructions
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
        var matches = regex.Matches(input);

        long sum = 0;
        bool enabled = true;

        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                enabled = true;
            }
            else if (match.Value == "don't()")
            {
                enabled = false;
            }
            else if (enabled)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sum += x * y;
            }
        }

        return sum.ToString();
    }
}
