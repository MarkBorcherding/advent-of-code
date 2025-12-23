namespace AdventOfCode2025.Days.Day06;

public static class MatrixExtensions
{
    public static T[][] Rotate<T>(this T[][] matrix)
    {
       var height = matrix.Length;
       var width = matrix[0].Length;


       for (var row = width - 1; row > 0; row--)
       {
           
       }
       
    }
}

public class Day06 : IPuzzle
{
    
    public string SolvePart1(string input)
    {

        var parsedInput = input.Split("\n");
        var operators = parsedInput.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        var numbers = parsedInput.SkipLast(1).Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList()).ToList();

        var result = operators
            .Select((op, index) => (op, index))
            .Aggregate(new List<long>(), (acc, cur ) =>
            {
                var (op, index) = cur;
                var col = numbers.Select(x => x[index]).ToList();
                switch (op)
                {
                    case "+":
                        acc.Add(col.Sum());
                        break;
                    case "*":
                        acc.Add(col.Aggregate(1L, (ac, x) => ac * x));
                        break;
                    default: 
                        throw new Exception($"Invalid operator {op}");    
                }
                return acc;
            });

        return result.Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        var parsedInput = 
            input
            .Split("\n")
            .Select(l => l.ToCharArray())
            .ToArray();

        var numbers 
            = parsedInput
                .SkipLast(1);
        
        var operators = parsedInput.Last().Where( c => c != ' '):
        
        
        return "incomplete";
    }
}
