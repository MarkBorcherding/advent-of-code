namespace AdventOfCode2024.Days.Day08;

public class Day08 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int rows = grid.Length, cols = grid[0].Length;

        // Group antennas by frequency
        var antennas = new Dictionary<char, List<(int r, int c)>>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                char ch = grid[r][c];
                if (ch != '.')
                {
                    if (!antennas.ContainsKey(ch))
                        antennas[ch] = new List<(int, int)>();
                    antennas[ch].Add((r, c));
                }
            }
        }

        var antinodes = new HashSet<(int, int)>();

        foreach (var freq in antennas.Keys)
        {
            var positions = antennas[freq];
            for (int i = 0; i < positions.Count; i++)
            {
                for (int j = i + 1; j < positions.Count; j++)
                {
                    var (r1, c1) = positions[i];
                    var (r2, c2) = positions[j];

                    int dr = r2 - r1;
                    int dc = c2 - c1;

                    // Antinode on one side: r1 - dr, c1 - dc
                    int ar1 = r1 - dr, ac1 = c1 - dc;
                    if (ar1 >= 0 && ar1 < rows && ac1 >= 0 && ac1 < cols)
                        antinodes.Add((ar1, ac1));

                    // Antinode on other side: r2 + dr, c2 + dc
                    int ar2 = r2 + dr, ac2 = c2 + dc;
                    if (ar2 >= 0 && ar2 < rows && ac2 >= 0 && ac2 < cols)
                        antinodes.Add((ar2, ac2));
                }
            }
        }

        return antinodes.Count.ToString();
    }

    public string SolvePart2(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int rows = grid.Length, cols = grid[0].Length;

        var antennas = new Dictionary<char, List<(int r, int c)>>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                char ch = grid[r][c];
                if (ch != '.')
                {
                    if (!antennas.ContainsKey(ch))
                        antennas[ch] = new List<(int, int)>();
                    antennas[ch].Add((r, c));
                }
            }
        }

        var antinodes = new HashSet<(int, int)>();

        foreach (var freq in antennas.Keys)
        {
            var positions = antennas[freq];
            for (int i = 0; i < positions.Count; i++)
            {
                for (int j = i + 1; j < positions.Count; j++)
                {
                    var (r1, c1) = positions[i];
                    var (r2, c2) = positions[j];

                    int dr = r2 - r1;
                    int dc = c2 - c1;

                    // Reduce to smallest step
                    int g = GCD(Math.Abs(dr), Math.Abs(dc));
                    dr /= g;
                    dc /= g;

                    // Extend in both directions from r1,c1
                    int r = r1, c = c1;
                    while (r >= 0 && r < rows && c >= 0 && c < cols)
                    {
                        antinodes.Add((r, c));
                        r -= dr;
                        c -= dc;
                    }

                    r = r1 + dr;
                    c = c1 + dc;
                    while (r >= 0 && r < rows && c >= 0 && c < cols)
                    {
                        antinodes.Add((r, c));
                        r += dr;
                        c += dc;
                    }
                }
            }
        }

        return antinodes.Count.ToString();
    }

    private int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}
