namespace AdventOfCode2025.Days.Day02;

public class Day02 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var ranges = input.Trim().Split(',');
        long totalInvalidIds = 0;

        foreach (var range in ranges)
        {
            var parts = range.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);

            for (long id = start; id <= end; id++)
            {
                if (IsInvalidId(id))
                {
                    totalInvalidIds += id;
                }
            }
        }

        return totalInvalidIds.ToString();
    }

    private bool IsInvalidId(long id)
    {
        var idStr = id.ToString();

        if (idStr.Length % 2 != 0)
            return false;

        int halfLen = idStr.Length / 2;
        var firstHalf = idStr.Substring(0, halfLen);
        var secondHalf = idStr.Substring(halfLen);

        return firstHalf == secondHalf;
    }

    private bool IsInvalidIdPart2(long id)
    {
        var idStr = id.ToString();

        for (int patternLen = 1; patternLen <= idStr.Length / 2; patternLen++)
        {
            if (idStr.Length % patternLen != 0)
                continue;

            var pattern = idStr.Substring(0, patternLen);
            var isRepeated = true;

            for (int i = patternLen; i < idStr.Length; i += patternLen)
            {
                if (idStr.Substring(i, patternLen) != pattern)
                {
                    isRepeated = false;
                    break;
                }
            }

            if (isRepeated)
                return true;
        }

        return false;
    }

    public string SolvePart2(string input)
    {
        var ranges = input.Trim().Split(',');
        long totalInvalidIds = 0;

        foreach (var range in ranges)
        {
            var parts = range.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);

            for (long id = start; id <= end; id++)
            {
                if (IsInvalidIdPart2(id))
                {
                    totalInvalidIds += id;
                }
            }
        }

        return totalInvalidIds.ToString();
    }
}
