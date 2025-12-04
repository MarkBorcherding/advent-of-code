namespace AdventOfCode2024.Days.Day21;

public class Day21 : IPuzzle
{
    // Numeric keypad layout:
    // 7 8 9
    // 4 5 6
    // 1 2 3
    //   0 A
    private static readonly Dictionary<char, (int r, int c)> NumPad = new()
    {
        ['7'] = (0, 0),
        ['8'] = (0, 1),
        ['9'] = (0, 2),
        ['4'] = (1, 0),
        ['5'] = (1, 1),
        ['6'] = (1, 2),
        ['1'] = (2, 0),
        ['2'] = (2, 1),
        ['3'] = (2, 2),
        ['0'] = (3, 1),
        ['A'] = (3, 2)
    };
    private static readonly (int r, int c) NumPadGap = (3, 0);

    // Directional keypad layout:
    //   ^ A
    // < v >
    private static readonly Dictionary<char, (int r, int c)> DirPad = new()
    {
        ['^'] = (0, 1),
        ['A'] = (0, 2),
        ['<'] = (1, 0),
        ['v'] = (1, 1),
        ['>'] = (1, 2)
    };
    private static readonly (int r, int c) DirPadGap = (0, 0);

    private readonly Dictionary<(char from, char to, int depth, bool isNumPad), long> _memo = [];

    public string SolvePart1(string input)
    {
        return Solve(input, 2).ToString();
    }

    public string SolvePart2(string input)
    {
        return Solve(input, 25).ToString();
    }

    private long Solve(string input, int numDirRobots)
    {
        _memo.Clear();
        var codes = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long total = 0;

        foreach (var code in codes)
        {
            // We type on a directional keypad, which controls numDirRobots directional keypads,
            // and the last one controls the numeric keypad
            long length = GetMinPresses(code, numDirRobots + 1, true);
            int numericPart = int.Parse(code[..^1]);
            total += length * numericPart;
        }

        return total;
    }

    private long GetMinPresses(string sequence, int depth, bool isNumPad)
    {
        // depth == 0 means we're typing directly (no more indirection)
        if (depth == 0)
            return sequence.Length;

        var pad = isNumPad ? NumPad : DirPad;
        var gap = isNumPad ? NumPadGap : DirPadGap;

        long total = 0;
        char current = 'A';

        foreach (char target in sequence)
        {
            total += GetMinPressesForMove(current, target, depth, pad, gap, isNumPad);
            current = target;
        }

        return total;
    }

    private long GetMinPressesForMove(char from, char to, int depth, Dictionary<char, (int r, int c)> pad, (int r, int c) gap, bool isNumPad)
    {
        if (_memo.TryGetValue((from, to, depth, isNumPad), out long cached))
            return cached;

        var (fr, fc) = pad[from];
        var (tr, tc) = pad[to];

        int dr = tr - fr;
        int dc = tc - fc;

        string vertical = dr > 0 ? new string('v', dr) : new string('^', -dr);
        string horizontal = dc > 0 ? new string('>', dc) : new string('<', -dc);

        long result = long.MaxValue;

        // Try horizontal first, then vertical
        if (!(fr == gap.r && tc == gap.c)) // Don't pass through gap
        {
            string seq = horizontal + vertical + "A";
            result = Math.Min(result, GetMinPresses(seq, depth - 1, false));
        }

        // Try vertical first, then horizontal
        if (!(tr == gap.r && fc == gap.c)) // Don't pass through gap
        {
            string seq = vertical + horizontal + "A";
            result = Math.Min(result, GetMinPresses(seq, depth - 1, false));
        }

        _memo[(from, to, depth, isNumPad)] = result;
        return result;
    }
}
