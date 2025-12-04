namespace AdventOfCode2025.Days.Day01;

public class Day01 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var position = 50;
        var zeroCount = 0;

        foreach (var line in lines)
        {
            var direction = line[0];
            var distance = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                position = (position - distance) % 100;
                if (position < 0) position += 100;
            }
            else
            {
                position = (position + distance) % 100;
            }

            if (position == 0)
            {
                zeroCount++;
            }
        }

        return zeroCount.ToString();
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var position = 50;
        var zeroCount = 0;

        foreach (var line in lines)
        {
            var direction = line[0];
            var distance = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                for (int i = 0; i < distance; i++)
                {
                    position = position - 1;
                    if (position < 0) position = 99;

                    if (position == 0)
                    {
                        zeroCount++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < distance; i++)
                {
                    position = position + 1;
                    if (position > 99) position = 0;

                    if (position == 0)
                    {
                        zeroCount++;
                    }
                }
            }
        }

        return zeroCount.ToString();
    }
}
