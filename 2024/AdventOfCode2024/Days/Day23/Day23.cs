namespace AdventOfCode2024.Days.Day23;

public class Day23 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var graph = BuildGraph(input);
        var nodes = graph.Keys.ToList();
        var triangles = new HashSet<string>();

        // Find all triangles (sets of 3 mutually connected nodes)
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = i + 1; j < nodes.Count; j++)
            {
                if (!graph[nodes[i]].Contains(nodes[j])) continue;

                for (int k = j + 1; k < nodes.Count; k++)
                {
                    if (graph[nodes[i]].Contains(nodes[k]) && graph[nodes[j]].Contains(nodes[k]))
                    {
                        var triangle = new[] { nodes[i], nodes[j], nodes[k] };
                        // Check if at least one starts with 't'
                        if (triangle.Any(n => n.StartsWith('t')))
                        {
                            Array.Sort(triangle);
                            triangles.Add(string.Join(",", triangle));
                        }
                    }
                }
            }
        }

        return triangles.Count.ToString();
    }

    public string SolvePart2(string input)
    {
        var graph = BuildGraph(input);
        var nodes = graph.Keys.ToList();

        // Find the largest clique using Bron-Kerbosch algorithm
        var maxClique = new HashSet<string>();
        BronKerbosch([], [.. nodes], [], graph, ref maxClique);

        var sorted = maxClique.OrderBy(x => x).ToList();
        return string.Join(",", sorted);
    }

    private Dictionary<string, HashSet<string>> BuildGraph(string input)
    {
        var graph = new Dictionary<string, HashSet<string>>();

        foreach (var line in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split('-');
            var a = parts[0];
            var b = parts[1];

            if (!graph.ContainsKey(a)) graph[a] = [];
            if (!graph.ContainsKey(b)) graph[b] = [];

            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }

    private void BronKerbosch(
        HashSet<string> r,
        HashSet<string> p,
        HashSet<string> x,
        Dictionary<string, HashSet<string>> graph,
        ref HashSet<string> maxClique)
    {
        if (p.Count == 0 && x.Count == 0)
        {
            if (r.Count > maxClique.Count)
            {
                maxClique = [.. r];
            }
            return;
        }

        // Pivot selection: choose vertex with most connections in P ∪ X
        var union = p.Union(x).ToList();
        var pivot = union.OrderByDescending(v => graph[v].Intersect(p).Count()).First();
        var candidates = p.Except(graph[pivot]).ToList();

        foreach (var v in candidates)
        {
            var neighbors = graph[v];
            BronKerbosch(
                [.. r, v],
                [.. p.Intersect(neighbors)],
                [.. x.Intersect(neighbors)],
                graph,
                ref maxClique);
            p.Remove(v);
            x.Add(v);
        }
    }
}
