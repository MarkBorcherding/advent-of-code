namespace AdventOfCode2024.Days.Day22;

public class Day22 : IPuzzle
{
    private const long MOD = 16777216;

    public string SolvePart1(string input)
    {
        var secrets = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                          .Select(long.Parse)
                          .ToList();

        long sum = 0;
        foreach (var secret in secrets)
        {
            long s = secret;
            for (int i = 0; i < 2000; i++)
            {
                s = NextSecret(s);
            }
            sum += s;
        }

        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        var secrets = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                          .Select(long.Parse)
                          .ToList();

        // For each sequence of 4 price changes, track total bananas we'd get
        var sequenceTotals = new Dictionary<(int, int, int, int), long>();

        foreach (var secret in secrets)
        {
            var prices = new List<int>();
            long s = secret;
            prices.Add((int)(s % 10));

            for (int i = 0; i < 2000; i++)
            {
                s = NextSecret(s);
                prices.Add((int)(s % 10));
            }

            // Calculate changes
            var changes = new int[prices.Count - 1];
            for (int i = 0; i < changes.Length; i++)
            {
                changes[i] = prices[i + 1] - prices[i];
            }

            // For this buyer, find first occurrence of each 4-change sequence
            var seenSequences = new HashSet<(int, int, int, int)>();
            for (int i = 0; i <= changes.Length - 4; i++)
            {
                var seq = (changes[i], changes[i + 1], changes[i + 2], changes[i + 3]);
                if (seenSequences.Add(seq))
                {
                    // First time seeing this sequence for this buyer
                    int price = prices[i + 4];
                    if (!sequenceTotals.ContainsKey(seq))
                        sequenceTotals[seq] = 0;
                    sequenceTotals[seq] += price;
                }
            }
        }

        return sequenceTotals.Values.Max().ToString();
    }

    private long NextSecret(long secret)
    {
        // Step 1: multiply by 64, mix, prune
        secret ^= (secret * 64);
        secret %= MOD;

        // Step 2: divide by 32, mix, prune
        secret ^= (secret / 32);
        secret %= MOD;

        // Step 3: multiply by 2048, mix, prune
        secret ^= (secret * 2048);
        secret %= MOD;

        return secret;
    }
}
