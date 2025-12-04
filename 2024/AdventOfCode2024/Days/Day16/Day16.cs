namespace AdventOfCode2024.Days.Day16;

public class Day16 : IPuzzle
{
    private static readonly (int dr, int dc)[] Dirs = [(0, 1), (1, 0), (0, -1), (-1, 0)]; // E, S, W, N

    public string SolvePart1(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var (startR, startC) = FindChar(grid, 'S');
        var (endR, endC) = FindChar(grid, 'E');

        return Dijkstra(grid, startR, startC, endR, endC).minCost.ToString();
    }

    public string SolvePart2(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var (startR, startC) = FindChar(grid, 'S');
        var (endR, endC) = FindChar(grid, 'E');

        return Dijkstra(grid, startR, startC, endR, endC).tilesOnBestPaths.ToString();
    }

    private (int r, int c) FindChar(string[] grid, char ch)
    {
        for (int r = 0; r < grid.Length; r++)
            for (int c = 0; c < grid[r].Length; c++)
                if (grid[r][c] == ch)
                    return (r, c);
        return (-1, -1);
    }

    private (long minCost, int tilesOnBestPaths) Dijkstra(string[] grid, int startR, int startC, int endR, int endC)
    {
        int rows = grid.Length, cols = grid[0].Length;
        var dist = new Dictionary<(int r, int c, int dir), long>();
        var prev = new Dictionary<(int r, int c, int dir), List<(int r, int c, int dir)>>();
        var pq = new PriorityQueue<(int r, int c, int dir), long>();

        var start = (startR, startC, 0); // Start facing East
        dist[start] = 0;
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            var (r, c, dir) = pq.Dequeue();
            long currentDist = dist.GetValueOrDefault((r, c, dir), long.MaxValue);

            // Move forward
            var (dr, dc) = Dirs[dir];
            int nr = r + dr, nc = c + dc;
            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] != '#')
            {
                long newDist = currentDist + 1;
                var next = (nr, nc, dir);
                if (newDist < dist.GetValueOrDefault(next, long.MaxValue))
                {
                    dist[next] = newDist;
                    prev[next] = [(r, c, dir)];
                    pq.Enqueue(next, newDist);
                }
                else if (newDist == dist.GetValueOrDefault(next, long.MaxValue))
                {
                    if (!prev.ContainsKey(next)) prev[next] = [];
                    prev[next].Add((r, c, dir));
                }
            }

            // Turn left and right
            foreach (int turn in new[] { -1, 1 })
            {
                int newDir = (dir + turn + 4) % 4;
                long newDist = currentDist + 1000;
                var next = (r, c, newDir);
                if (newDist < dist.GetValueOrDefault(next, long.MaxValue))
                {
                    dist[next] = newDist;
                    prev[next] = [(r, c, dir)];
                    pq.Enqueue(next, newDist);
                }
                else if (newDist == dist.GetValueOrDefault(next, long.MaxValue))
                {
                    if (!prev.ContainsKey(next)) prev[next] = [];
                    prev[next].Add((r, c, dir));
                }
            }
        }

        // Find minimum cost to reach end in any direction
        long minCost = long.MaxValue;
        var endStates = new List<(int r, int c, int dir)>();
        for (int d = 0; d < 4; d++)
        {
            var state = (endR, endC, d);
            if (dist.TryGetValue(state, out long cost))
            {
                if (cost < minCost)
                {
                    minCost = cost;
                    endStates = [state];
                }
                else if (cost == minCost)
                {
                    endStates.Add(state);
                }
            }
        }

        // Backtrack to find all tiles on best paths
        var tilesOnPath = new HashSet<(int r, int c)>();
        var visited = new HashSet<(int r, int c, int dir)>();
        var queue = new Queue<(int r, int c, int dir)>();

        foreach (var state in endStates)
        {
            queue.Enqueue(state);
            visited.Add(state);
        }

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();
            tilesOnPath.Add((state.r, state.c));

            if (prev.TryGetValue(state, out var parents))
            {
                foreach (var parent in parents)
                {
                    if (visited.Add(parent))
                    {
                        queue.Enqueue(parent);
                    }
                }
            }
        }

        return (minCost, tilesOnPath.Count);
    }
}
