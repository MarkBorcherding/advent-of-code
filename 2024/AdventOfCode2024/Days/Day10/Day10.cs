namespace AdventOfCode2024.Days.Day10;

public class Day10 : IPuzzle
{
    private static readonly (int dr, int dc)[] Dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public string SolvePart1(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => l.ToCharArray()).ToArray();
        int rows = grid.Length, cols = grid[0].Length;

        int totalScore = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '0')
                {
                    totalScore += CountReachableNines(grid, r, c, rows, cols);
                }
            }
        }

        return totalScore.ToString();
    }

    public string SolvePart2(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => l.ToCharArray()).ToArray();
        int rows = grid.Length, cols = grid[0].Length;

        int totalRating = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '0')
                {
                    totalRating += CountDistinctPaths(grid, r, c, rows, cols);
                }
            }
        }

        return totalRating.ToString();
    }

    private int CountReachableNines(char[][] grid, int startR, int startC, int rows, int cols)
    {
        var reachableNines = new HashSet<(int, int)>();
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int r, int c)>();

        queue.Enqueue((startR, startC));
        visited.Add((startR, startC));

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            int currentHeight = grid[r][c] - '0';

            if (currentHeight == 9)
            {
                reachableNines.Add((r, c));
                continue;
            }

            foreach (var (dr, dc) in Dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !visited.Contains((nr, nc)))
                {
                    int nextHeight = grid[nr][nc] - '0';
                    if (nextHeight == currentHeight + 1)
                    {
                        visited.Add((nr, nc));
                        queue.Enqueue((nr, nc));
                    }
                }
            }
        }

        return reachableNines.Count;
    }

    private int CountDistinctPaths(char[][] grid, int startR, int startC, int rows, int cols)
    {
        // DFS to count all distinct paths from start to any 9
        return DFS(grid, startR, startC, rows, cols);
    }

    private int DFS(char[][] grid, int r, int c, int rows, int cols)
    {
        int currentHeight = grid[r][c] - '0';

        if (currentHeight == 9)
            return 1;

        int pathCount = 0;

        foreach (var (dr, dc) in Dirs)
        {
            int nr = r + dr, nc = c + dc;
            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
            {
                int nextHeight = grid[nr][nc] - '0';
                if (nextHeight == currentHeight + 1)
                {
                    pathCount += DFS(grid, nr, nc, rows, cols);
                }
            }
        }

        return pathCount;
    }
}
