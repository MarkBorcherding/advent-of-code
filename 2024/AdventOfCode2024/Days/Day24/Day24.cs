namespace AdventOfCode2024.Days.Day24;

public class Day24 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var (wires, gates) = ParseInput(input);
        Simulate(wires, gates);
        return GetZValue(wires).ToString();
    }

    public string SolvePart2(string input)
    {
        // Part 2 requires finding 4 pairs of swapped output wires to make the circuit
        // compute x + y correctly. This is a circuit analysis problem.
        var (_, gates) = ParseInput(input);

        // For a ripple-carry adder, each bit position should have:
        // - XOR of x[i] and y[i] -> intermediate
        // - XOR of intermediate and carry[i-1] -> z[i]
        // - AND of x[i] and y[i] -> partial carry
        // - AND of intermediate and carry[i-1] -> partial carry 2
        // - OR of partial carries -> carry[i]

        var swapped = new List<string>();

        // Find gates with suspicious outputs
        foreach (var gate in gates)
        {
            var (a, op, b, output) = gate;

            // z outputs (except z45) should come from XOR gates
            if (output.StartsWith('z') && output != "z45" && op != "XOR")
            {
                swapped.Add(output);
            }

            // XOR gates that don't involve x/y inputs and don't output to z are wrong
            if (op == "XOR" &&
                !a.StartsWith('x') && !a.StartsWith('y') &&
                !b.StartsWith('x') && !b.StartsWith('y') &&
                !output.StartsWith('z'))
            {
                swapped.Add(output);
            }

            // AND gates (except x00 AND y00) should feed into OR gates
            if (op == "AND" && a != "x00" && b != "x00")
            {
                // Check if output feeds into an OR gate
                bool feedsOr = gates.Any(g => (g.a == output || g.b == output) && g.op == "OR");
                if (!feedsOr)
                {
                    swapped.Add(output);
                }
            }

            // XOR gates should not feed into OR gates
            if (op == "XOR")
            {
                bool feedsOr = gates.Any(g => (g.a == output || g.b == output) && g.op == "OR");
                if (feedsOr)
                {
                    swapped.Add(output);
                }
            }
        }

        var result = swapped.Distinct().OrderBy(x => x).ToList();
        return string.Join(",", result);
    }

    private (Dictionary<string, int?> wires, List<(string a, string op, string b, string output)> gates) ParseInput(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var wires = new Dictionary<string, int?>();
        var gates = new List<(string a, string op, string b, string output)>();

        foreach (var line in parts[0].Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var p = line.Split(": ");
            wires[p[0]] = int.Parse(p[1]);
        }

        foreach (var line in parts[1].Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var p = line.Split(' ');
            var a = p[0];
            var op = p[1];
            var b = p[2];
            var output = p[4];
            gates.Add((a, op, b, output));
            if (!wires.ContainsKey(a)) wires[a] = null;
            if (!wires.ContainsKey(b)) wires[b] = null;
            if (!wires.ContainsKey(output)) wires[output] = null;
        }

        return (wires, gates);
    }

    private void Simulate(Dictionary<string, int?> wires, List<(string a, string op, string b, string output)> gates)
    {
        bool changed = true;
        while (changed)
        {
            changed = false;
            foreach (var (a, op, b, output) in gates)
            {
                if (wires[output] != null) continue;
                if (wires[a] == null || wires[b] == null) continue;

                int va = wires[a]!.Value;
                int vb = wires[b]!.Value;
                int result = op switch
                {
                    "AND" => va & vb,
                    "OR" => va | vb,
                    "XOR" => va ^ vb,
                    _ => throw new Exception($"Unknown op: {op}")
                };
                wires[output] = result;
                changed = true;
            }
        }
    }

    private long GetZValue(Dictionary<string, int?> wires)
    {
        var zWires = wires.Keys.Where(k => k.StartsWith('z')).OrderByDescending(k => k).ToList();
        long result = 0;
        foreach (var z in zWires)
        {
            result = (result << 1) | (wires[z] ?? 0);
        }
        return result;
    }
}
