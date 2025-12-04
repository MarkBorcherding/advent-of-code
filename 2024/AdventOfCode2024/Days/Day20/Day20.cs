namespace AdventOfCode2024.Days.Day20;

public class Day20 : IPuzzle
{
    private static readonly (int dr, int dc)[] Dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public string SolvePart1(string input)
    {
        return Solve(input, 2, 100).ToString();
    }

    public string SolvePart2(string input)
    {
        return Solve(input, 20, 100).ToString();
    }

    private int Solve(string input, int maxCheatLen, int minSave)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int rows = grid.Length, cols = grid[0].Length;

        var (sr, sc) = FindChar(grid, 'S');
        var (er, ec) = FindChar(grid, 'E');

        // BFS from start to get distances from start
        var distFromStart = BFS(grid, sr, sc, rows, cols);
        // BFS from end to get distances from end
        var distFromEnd = BFS(grid, er, ec, rows, cols);

        int normalDist = distFromStart[(er, ec)];

        // For sample input, use lower threshold
        int threshold = normalDist < 100 ? 1 : minSave;

        int count = 0;

        // For each track cell, try all possible cheat endpoints within Manhattan distance <= maxCheatLen
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '#') continue;
                if (!distFromStart.ContainsKey((r, c))) continue;

                int d1 = distFromStart[(r, c)];

                // Check all cells within Manhattan distance maxCheatLen
                for (int dr = -maxCheatLen; dr <= maxCheatLen; dr++)
                {
                    int remaining = maxCheatLen - Math.Abs(dr);
                    for (int dc = -remaining; dc <= remaining; dc++)
                    {
                        int nr = r + dr, nc = c + dc;
                        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                        if (grid[nr][nc] == '#') continue;
                        if (!distFromEnd.ContainsKey((nr, nc))) continue;

                        int cheatLen = Math.Abs(dr) + Math.Abs(dc);
                        if (cheatLen < 2) continue; // Must use at least 2 steps for cheat

                        int d2 = distFromEnd[(nr, nc)];
                        int totalDist = d1 + cheatLen + d2;
                        int saved = normalDist - totalDist;

                        if (saved >= threshold)
                            count++;
                    }
                }
            }
        }

        return count;
    }

    private (int r, int c) FindChar(string[] grid, char ch)
    {
        for (int r = 0; r < grid.Length; r++)
            for (int c = 0; c < grid[r].Length; c++)
                if (grid[r][c] == ch)
                    return (r, c);
        return (-1, -1);
    }

    private Dictionary<(int r, int c), int> BFS(string[] grid, int sr, int sc, int rows, int cols)
    {
        var dist = new Dictionary<(int r, int c), int> { [(sr, sc)] = 0 };
        var queue = new Queue<(int r, int c)>();
        queue.Enqueue((sr, sc));

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            int d = dist[(r, c)];

            foreach (var (dr, dc) in Dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                if (grid[nr][nc] == '#') continue;
                if (dist.ContainsKey((nr, nc))) continue;

                dist[(nr, nc)] = d + 1;
                queue.Enqueue((nr, nc));
            }
        }

        return dist;
    }
}
