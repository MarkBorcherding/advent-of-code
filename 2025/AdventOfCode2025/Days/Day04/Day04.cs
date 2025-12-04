namespace AdventOfCode2025.Days.Day04;

public class Day04 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var grid = lines.Select(line => line.ToCharArray()).ToArray();
        int rows = grid.Length;
        int cols = grid[0].Length;

        int accessibleCount = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == '@' && IsAccessible(grid, row, col, rows, cols))
                {
                    accessibleCount++;
                }
            }
        }

        return accessibleCount.ToString();
    }

    private bool IsAccessible(char[][] grid, int row, int col, int rows, int cols)
    {
        int adjacentPaperCount = 0;

        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dx[i];
            int newCol = col + dy[i];

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
            {
                if (grid[newRow][newCol] == '@')
                {
                    adjacentPaperCount++;
                }
            }
        }

        return adjacentPaperCount < 4;
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var grid = lines.Select(line => line.ToCharArray()).ToArray();
        int rows = grid.Length;
        int cols = grid[0].Length;

        int totalRemoved = 0;

        while (true)
        {
            // Find all accessible rolls in current state
            var toRemove = new List<(int row, int col)>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '@' && IsAccessible(grid, row, col, rows, cols))
                    {
                        toRemove.Add((row, col));
                    }
                }
            }

            if (toRemove.Count == 0)
                break;

            // Remove all accessible rolls
            foreach (var (row, col) in toRemove)
            {
                grid[row][col] = '.';
            }

            totalRemoved += toRemove.Count;
        }

        return totalRemoved.ToString();
    }
}
