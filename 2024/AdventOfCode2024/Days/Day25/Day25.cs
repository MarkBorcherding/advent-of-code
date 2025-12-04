namespace AdventOfCode2024.Days.Day25;

public class Day25 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var blocks = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var locks = new List<int[]>();
        var keys = new List<int[]>();

        foreach (var block in blocks)
        {
            var lines = block.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var heights = new int[5];

            // Lock: top row is all #, key: top row is all .
            bool isLock = lines[0][0] == '#';

            for (int col = 0; col < 5; col++)
            {
                int count = 0;
                for (int row = 0; row < lines.Length; row++)
                {
                    if (lines[row][col] == '#')
                        count++;
                }
                // Subtract 1 because we don't count the solid row (top for locks, bottom for keys)
                heights[col] = count - 1;
            }

            if (isLock)
                locks.Add(heights);
            else
                keys.Add(heights);
        }

        int fitCount = 0;
        foreach (var lockHeights in locks)
        {
            foreach (var keyHeights in keys)
            {
                bool fits = true;
                for (int i = 0; i < 5; i++)
                {
                    // Available space is 5 (7 rows - 2 for top/bottom)
                    if (lockHeights[i] + keyHeights[i] > 5)
                    {
                        fits = false;
                        break;
                    }
                }
                if (fits)
                    fitCount++;
            }
        }

        return fitCount.ToString();
    }

    public string SolvePart2(string input)
    {
        // Day 25 Part 2 is typically just collecting all 49 stars
        return "Merry Christmas!";
    }
}
