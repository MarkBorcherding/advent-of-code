using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2025.Days.Day05;

public class Range
{
    public long Start { get; set; }
    public long End { get; set; }

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public bool Contains(long value)
    {
        return value >= Start && value <= End;
    }
    
    public bool Overlaps(Range other)
    {
        return this.Start <= other.End && this.End >= other.Start;
    }
    
}

public class Day05 : IPuzzle
{
    public string SolvePart1(string input)
    {

        var split = input.Split("\n\n");
        var freshRanges = split[0]
            .Split("\n")
            .Select(txt =>
                {
                    var range = txt.Split("-");
                    return new Range(long.Parse(range[0]), long.Parse(range[1]));
                });
        
        var availableIngredients = split[1]
            .Split("\n")
            .Select(long.Parse)
            ;

        var freshIngredients = availableIngredients
            .Where(ingredient =>
            {
                return freshRanges.Any(range => range.Contains(ingredient));
            });
           
        return freshIngredients.Count().ToString();
    }

    public string SolvePart2(string input)
    {
        var split = input.Split("\n\n");
        var freshRanges = split[0]
            .Split("\n")
            .Select(txt =>
            {
                var range = txt.Split("-");
                return new Range(long.Parse(range[0]), long.Parse(range[1]));
            });

        var freshItems = freshRanges
            .OrderBy(range => range.Start)
            .Aggregate(new SortedList<long, Range>(), (acc, cur) =>
            {
                // []
                // -----
                if (acc.Count == 0)
                {
                    Console.Out.WriteLine($"Start {cur.Start}-{cur.End}");
                    acc.Add(cur.Start, cur);
                    return acc;
                }
                
                
                var last = acc.Last().Value;
                
                // [ -------- ]
                //      --
                if (cur.End < last.End)
                {
                    Console.Out.WriteLine($"Skip {cur.Start}-{cur.End}");
                    return acc;
                }

                // [ --------- ]
                //               ---- 
                if (cur.Start > last.End)
                {
                    Console.Out.WriteLine($"Add {cur.Start}-{cur.End}");
                    acc.Add(cur.Start, cur);
                    return acc;
                }
                
                // [ ----------- ]
                //         -----------
                if (cur.Start <= last.End && cur.End > last.End)
                {
                    var merged = new Range(last.End + 1, cur.End);
                    acc.Add(merged.Start, merged);
                    Console.Out.WriteLine($"Merge {cur.Start}-{cur.End} into {merged.Start}-{merged.End}");
                    return acc;
                }
                
                Console.Out.WriteLine($"Skipped {cur.Start}-{cur.End}");
                return acc;
            })
            .Values;
        
        freshItems.ToList().ForEach(rng => Console.Out.WriteLine($"{rng.Start}-{rng.End}  = {rng.End - rng.Start + 1}"));
        
        return freshItems.Sum(rng => rng.End - rng.Start + 1).ToString();

    }
}
