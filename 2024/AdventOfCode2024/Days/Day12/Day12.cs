namespace AdventOfCode2024.Days.Day12;

public class Day12 : IPuzzle
{
    private static readonly (int dr, int dc)[] Dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public string SolvePart1(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int rows = grid.Length, cols = grid[0].Length;
        var visited = new bool[rows, cols];
        long totalPrice = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (!visited[r, c])
                {
                    var (area, perimeter) = FloodFill(grid, visited, r, c, rows, cols);
                    totalPrice += (long)area * perimeter;
                }
            }
        }

        return totalPrice.ToString();
    }

    public string SolvePart2(string input)
    {
        var grid = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int rows = grid.Length, cols = grid[0].Length;
        var visited = new bool[rows, cols];
        long totalPrice = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (!visited[r, c])
                {
                    var (area, sides) = FloodFillWithSides(grid, visited, r, c, rows, cols);
                    totalPrice += (long)area * sides;
                }
            }
        }

        return totalPrice.ToString();
    }

    private (int area, int perimeter) FloodFill(string[] grid, bool[,] visited, int startR, int startC, int rows, int cols)
    {
        char plant = grid[startR][startC];
        var queue = new Queue<(int r, int c)>();
        queue.Enqueue((startR, startC));
        visited[startR, startC] = true;

        int area = 0, perimeter = 0;

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            area++;

            foreach (var (dr, dc) in Dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || grid[nr][nc] != plant)
                {
                    perimeter++;
                }
                else if (!visited[nr, nc])
                {
                    visited[nr, nc] = true;
                    queue.Enqueue((nr, nc));
                }
            }
        }

        return (area, perimeter);
    }

    private (int area, int sides) FloodFillWithSides(string[] grid, bool[,] visited, int startR, int startC, int rows, int cols)
    {
        char plant = grid[startR][startC];
        var queue = new Queue<(int r, int c)>();
        var region = new HashSet<(int r, int c)>();

        queue.Enqueue((startR, startC));
        visited[startR, startC] = true;
        region.Add((startR, startC));

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            foreach (var (dr, dc) in Dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == plant && !visited[nr, nc])
                {
                    visited[nr, nc] = true;
                    queue.Enqueue((nr, nc));
                    region.Add((nr, nc));
                }
            }
        }

        int sides = CountSides(region);
        return (region.Count, sides);
    }

    private int CountSides(HashSet<(int r, int c)> region)
    {
        // Count corners - each corner = one side
        int corners = 0;

        foreach (var (r, c) in region)
        {
            // Check all 4 corner types
            // Outer corners: when two adjacent sides are outside
            // Inner corners: when two adjacent sides are inside but diagonal is outside

            bool up = region.Contains((r - 1, c));
            bool down = region.Contains((r + 1, c));
            bool left = region.Contains((r, c - 1));
            bool right = region.Contains((r, c + 1));
            bool upLeft = region.Contains((r - 1, c - 1));
            bool upRight = region.Contains((r - 1, c + 1));
            bool downLeft = region.Contains((r + 1, c - 1));
            bool downRight = region.Contains((r + 1, c + 1));

            // Outer corners (convex)
            if (!up && !left) corners++;
            if (!up && !right) corners++;
            if (!down && !left) corners++;
            if (!down && !right) corners++;

            // Inner corners (concave)
            if (up && left && !upLeft) corners++;
            if (up && right && !upRight) corners++;
            if (down && left && !downLeft) corners++;
            if (down && right && !downRight) corners++;
        }

        return corners;
    }
}
