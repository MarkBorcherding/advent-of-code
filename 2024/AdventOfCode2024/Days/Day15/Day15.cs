namespace AdventOfCode2024.Days.Day15;

public class Day15 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var (grid, moves) = ParseInput(input);
        var (robotR, robotC) = FindRobot(grid);

        foreach (var move in moves)
        {
            (robotR, robotC) = TryMove(grid, robotR, robotC, move);
        }

        return CalculateGPS(grid, 'O').ToString();
    }

    public string SolvePart2(string input)
    {
        var (grid, moves) = ParseInput(input);
        var wideGrid = ExpandGrid(grid);
        var (robotR, robotC) = FindRobot(wideGrid);

        foreach (var move in moves)
        {
            (robotR, robotC) = TryMoveWide(wideGrid, robotR, robotC, move);
        }

        return CalculateGPS(wideGrid, '[').ToString();
    }

    private (char[][] grid, string moves) ParseInput(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var grid = parts[0].Split('\n', StringSplitOptions.RemoveEmptyEntries)
                          .Select(l => l.ToCharArray()).ToArray();
        var moves = string.Join("", parts[1].Split('\n'));
        return (grid, moves);
    }

    private (int r, int c) FindRobot(char[][] grid)
    {
        for (int r = 0; r < grid.Length; r++)
            for (int c = 0; c < grid[r].Length; c++)
                if (grid[r][c] == '@')
                    return (r, c);
        return (-1, -1);
    }

    private (int dr, int dc) GetDirection(char move) => move switch
    {
        '^' => (-1, 0),
        'v' => (1, 0),
        '<' => (0, -1),
        '>' => (0, 1),
        _ => (0, 0)
    };

    private (int r, int c) TryMove(char[][] grid, int robotR, int robotC, char move)
    {
        var (dr, dc) = GetDirection(move);
        int nr = robotR + dr, nc = robotC + dc;

        if (grid[nr][nc] == '#') return (robotR, robotC);

        if (grid[nr][nc] == '.')
        {
            grid[robotR][robotC] = '.';
            grid[nr][nc] = '@';
            return (nr, nc);
        }

        // Find end of box chain
        int endR = nr, endC = nc;
        while (grid[endR][endC] == 'O')
        {
            endR += dr;
            endC += dc;
        }

        if (grid[endR][endC] == '#') return (robotR, robotC);

        // Push boxes
        grid[endR][endC] = 'O';
        grid[nr][nc] = '@';
        grid[robotR][robotC] = '.';
        return (nr, nc);
    }

    private char[][] ExpandGrid(char[][] grid)
    {
        var wide = new char[grid.Length][];
        for (int r = 0; r < grid.Length; r++)
        {
            wide[r] = new char[grid[r].Length * 2];
            for (int c = 0; c < grid[r].Length; c++)
            {
                switch (grid[r][c])
                {
                    case '#':
                        wide[r][c * 2] = '#';
                        wide[r][c * 2 + 1] = '#';
                        break;
                    case 'O':
                        wide[r][c * 2] = '[';
                        wide[r][c * 2 + 1] = ']';
                        break;
                    case '.':
                        wide[r][c * 2] = '.';
                        wide[r][c * 2 + 1] = '.';
                        break;
                    case '@':
                        wide[r][c * 2] = '@';
                        wide[r][c * 2 + 1] = '.';
                        break;
                }
            }
        }
        return wide;
    }

    private (int r, int c) TryMoveWide(char[][] grid, int robotR, int robotC, char move)
    {
        var (dr, dc) = GetDirection(move);
        int nr = robotR + dr, nc = robotC + dc;

        if (grid[nr][nc] == '#') return (robotR, robotC);

        if (grid[nr][nc] == '.')
        {
            grid[robotR][robotC] = '.';
            grid[nr][nc] = '@';
            return (nr, nc);
        }

        // Handle wide boxes
        if (move == '<' || move == '>')
        {
            return TryMoveHorizontal(grid, robotR, robotC, dc);
        }
        else
        {
            return TryMoveVertical(grid, robotR, robotC, dr);
        }
    }

    private (int r, int c) TryMoveHorizontal(char[][] grid, int robotR, int robotC, int dc)
    {
        int nc = robotC + dc;
        var boxes = new List<int>();

        while (grid[robotR][nc] == '[' || grid[robotR][nc] == ']')
        {
            boxes.Add(nc);
            nc += dc;
        }

        if (grid[robotR][nc] == '#') return (robotR, robotC);

        // Move boxes
        for (int i = boxes.Count - 1; i >= 0; i--)
        {
            grid[robotR][boxes[i] + dc] = grid[robotR][boxes[i]];
        }

        grid[robotR][robotC] = '.';
        grid[robotR][robotC + dc] = '@';
        return (robotR, robotC + dc);
    }

    private (int r, int c) TryMoveVertical(char[][] grid, int robotR, int robotC, int dr)
    {
        // Collect all boxes that need to move
        var toMove = new HashSet<(int r, int c)>();
        var frontier = new Queue<(int r, int c)>();

        int nr = robotR + dr;
        if (grid[nr][robotC] == '[')
        {
            frontier.Enqueue((nr, robotC));
            frontier.Enqueue((nr, robotC + 1));
        }
        else if (grid[nr][robotC] == ']')
        {
            frontier.Enqueue((nr, robotC - 1));
            frontier.Enqueue((nr, robotC));
        }

        while (frontier.Count > 0)
        {
            var (r, c) = frontier.Dequeue();
            if (toMove.Contains((r, c))) continue;

            if (grid[r][c] == '#') return (robotR, robotC);
            if (grid[r][c] == '.') continue;

            toMove.Add((r, c));

            int nextR = r + dr;
            if (grid[nextR][c] == '[')
            {
                frontier.Enqueue((nextR, c));
                frontier.Enqueue((nextR, c + 1));
            }
            else if (grid[nextR][c] == ']')
            {
                frontier.Enqueue((nextR, c - 1));
                frontier.Enqueue((nextR, c));
            }
            else if (grid[nextR][c] == '#')
            {
                return (robotR, robotC);
            }
        }

        // Move all boxes
        var sorted = toMove.OrderBy(p => dr > 0 ? -p.r : p.r).ToList();
        foreach (var (r, c) in sorted)
        {
            grid[r + dr][c] = grid[r][c];
            grid[r][c] = '.';
        }

        grid[robotR][robotC] = '.';
        grid[robotR + dr][robotC] = '@';
        return (robotR + dr, robotC);
    }

    private long CalculateGPS(char[][] grid, char boxChar)
    {
        long sum = 0;
        for (int r = 0; r < grid.Length; r++)
            for (int c = 0; c < grid[r].Length; c++)
                if (grid[r][c] == boxChar)
                    sum += 100 * r + c;
        return sum;
    }
}
