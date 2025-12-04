namespace AdventOfCode2024.Days.Day18;

public class Day18 : IPuzzle
{
    private static readonly (int dr, int dc)[] Dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public string SolvePart1(string input)
    {
        var bytes = ParseBytes(input);
        int size = bytes.Count <= 25 ? 7 : 71;
        int numBytes = bytes.Count <= 25 ? 12 : 1024;

        var corrupted = new HashSet<(int, int)>(bytes.Take(numBytes));
        int steps = BFS(corrupted, size);
        return steps.ToString();
    }

    public string SolvePart2(string input)
    {
        var bytes = ParseBytes(input);
        int size = bytes.Count <= 25 ? 7 : 71;

        // Binary search for the first byte that blocks the path
        int lo = 0, hi = bytes.Count - 1;
        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            var corrupted = new HashSet<(int, int)>(bytes.Take(mid + 1));
            if (BFS(corrupted, size) == -1)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }

        return $"{bytes[lo].x},{bytes[lo].y}";
    }

    private List<(int x, int y)> ParseBytes(string input)
    {
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(line =>
                    {
                        var parts = line.Split(',');
                        return (int.Parse(parts[0]), int.Parse(parts[1]));
                    }).ToList();
    }

    private int BFS(HashSet<(int, int)> corrupted, int size)
    {
        var start = (0, 0);
        var end = (size - 1, size - 1);

        if (corrupted.Contains(start) || corrupted.Contains(end))
            return -1;

        var visited = new HashSet<(int, int)> { start };
        var queue = new Queue<(int x, int y, int steps)>();
        queue.Enqueue((0, 0, 0));

        while (queue.Count > 0)
        {
            var (x, y, steps) = queue.Dequeue();

            if ((x, y) == end)
                return steps;

            foreach (var (dr, dc) in Dirs)
            {
                int nx = x + dc, ny = y + dr;
                if (nx >= 0 && nx < size && ny >= 0 && ny < size &&
                    !corrupted.Contains((nx, ny)) && visited.Add((nx, ny)))
                {
                    queue.Enqueue((nx, ny, steps + 1));
                }
            }
        }

        return -1;
    }
}
