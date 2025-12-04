namespace AdventOfCode2024.Days.Day06;

public class Day06 : IPuzzle
{
    private static readonly (int dr, int dc)[] Directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]; // Up, Right, Down, Left

    public string SolvePart1(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => l.ToCharArray()).ToArray();

        var (startR, startC, startDir) = FindStart(grid);
        var visited = SimulateGuard(grid, startR, startC, startDir);

        return visited.Count.ToString();
    }

    public string SolvePart2(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => l.ToCharArray()).ToArray();

        var (startR, startC, startDir) = FindStart(grid);

        // First get all positions the guard visits
        var visited = SimulateGuard(grid, startR, startC, startDir);

        int loopCount = 0;

        // Try placing an obstruction at each visited position (except start)
        foreach (var (r, c) in visited)
        {
            if (r == startR && c == startC) continue;
            if (grid[r][c] == '#') continue;

            // Place obstruction
            grid[r][c] = '#';

            if (CausesLoop(grid, startR, startC, startDir))
                loopCount++;

            // Remove obstruction
            grid[r][c] = '.';
        }

        return loopCount.ToString();
    }

    private (int r, int c, int dir) FindStart(char[][] grid)
    {
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                int dir = grid[r][c] switch
                {
                    '^' => 0,
                    '>' => 1,
                    'v' => 2,
                    '<' => 3,
                    _ => -1
                };
                if (dir >= 0) return (r, c, dir);
            }
        }
        throw new Exception("No start found");
    }

    private HashSet<(int r, int c)> SimulateGuard(char[][] grid, int r, int c, int dir)
    {
        int rows = grid.Length, cols = grid[0].Length;
        var visited = new HashSet<(int, int)>();

        while (r >= 0 && r < rows && c >= 0 && c < cols)
        {
            visited.Add((r, c));

            int nr = r + Directions[dir].dr;
            int nc = c + Directions[dir].dc;

            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                break;

            if (grid[nr][nc] == '#')
            {
                dir = (dir + 1) % 4; // Turn right
            }
            else
            {
                r = nr;
                c = nc;
            }
        }

        return visited;
    }

    private bool CausesLoop(char[][] grid, int r, int c, int dir)
    {
        int rows = grid.Length, cols = grid[0].Length;
        var seen = new HashSet<(int, int, int)>();

        while (r >= 0 && r < rows && c >= 0 && c < cols)
        {
            if (!seen.Add((r, c, dir)))
                return true; // Loop detected

            int nr = r + Directions[dir].dr;
            int nc = c + Directions[dir].dc;

            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                return false; // Exited

            if (grid[nr][nc] == '#')
            {
                dir = (dir + 1) % 4;
            }
            else
            {
                r = nr;
                c = nc;
            }
        }

        return false;
    }
}
