namespace AdventOfCode2024.Days.Day04;

public class Day04 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var grid = lines.Select(l => l.ToCharArray()).ToArray();
        int rows = grid.Length;
        int cols = grid[0].Length;

        // All 8 directions: right, left, down, up, and 4 diagonals
        int[][] directions = [
            [0, 1],   // right
            [0, -1],  // left
            [1, 0],   // down
            [-1, 0],  // up
            [1, 1],   // down-right
            [1, -1],  // down-left
            [-1, 1],  // up-right
            [-1, -1]  // up-left
        ];

        string target = "XMAS";
        int count = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                foreach (var dir in directions)
                {
                    if (CheckWord(grid, r, c, dir[0], dir[1], target, rows, cols))
                        count++;
                }
            }
        }

        return count.ToString();
    }

    private bool CheckWord(char[][] grid, int startR, int startC, int dr, int dc, string word, int rows, int cols)
    {
        for (int i = 0; i < word.Length; i++)
        {
            int r = startR + i * dr;
            int c = startC + i * dc;

            if (r < 0 || r >= rows || c < 0 || c >= cols)
                return false;

            if (grid[r][c] != word[i])
                return false;
        }
        return true;
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var grid = lines.Select(l => l.ToCharArray()).ToArray();
        int rows = grid.Length;
        int cols = grid[0].Length;

        int count = 0;

        // Look for X-MAS pattern: two MAS crossing at the center 'A'
        // The center must be 'A', and we check the diagonals for M and S
        for (int r = 1; r < rows - 1; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                if (grid[r][c] == 'A')
                {
                    // Check both diagonals form MAS or SAM
                    char topLeft = grid[r - 1][c - 1];
                    char topRight = grid[r - 1][c + 1];
                    char bottomLeft = grid[r + 1][c - 1];
                    char bottomRight = grid[r + 1][c + 1];

                    // Diagonal 1: top-left to bottom-right (must be MAS or SAM)
                    bool diag1 = (topLeft == 'M' && bottomRight == 'S') ||
                                 (topLeft == 'S' && bottomRight == 'M');

                    // Diagonal 2: top-right to bottom-left (must be MAS or SAM)
                    bool diag2 = (topRight == 'M' && bottomLeft == 'S') ||
                                 (topRight == 'S' && bottomLeft == 'M');

                    if (diag1 && diag2)
                        count++;
                }
            }
        }

        return count.ToString();
    }
}
