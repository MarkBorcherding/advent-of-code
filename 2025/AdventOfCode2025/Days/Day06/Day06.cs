using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2025.Days.Day06;

public static class Extensions
{
    public static char[,] ToMatrix(this char[][] matrix)
    {
        var array = new char[matrix.Length, matrix[0].Length];
        for (var col = 0; col < matrix.Length; col++)
        {
            for (var row = 0; row < matrix[0].Length; row++)
            {
                array[col, row] = matrix[col][row];
            }
        }
        return array;
    }

    public static int Width(this char[,] matrix)
    {
        return matrix.GetLength(0);
    }
    
    public static IEnumerable<int> ColumnsEnum(this char[,] matrix)
    {
        return Enumerable.Range(0, matrix.Width());
    }

    public static int Height(this char[,] matrix)
    {
        return matrix.GetLength(1);
    }

    public static string Row(this char[,] matrix, int row)
    {
        return matrix
            .ColumnsEnum()
            .Aggregate("", (current, col) => current + matrix[col, row]);
    }

    public static IEnumerable<string> Rows(this char[,] matrix)
    {
        return Enumerable.Range(0,matrix.Height()).Select(matrix.Row);
    }
    


    public static char[,] RotateLeft(this char[,] matrix)
    {

        var width = matrix.Width();
        var height = matrix.Height();
        
        var result = new char[height, width];

        foreach (var col in ColsIndexes())
        {
            foreach (var row in RowsIndexes())
            {
                result[row, col] = matrix[col, row];
            }
        }

        return result;

        IEnumerable<int> RowsIndexes() => Enumerable.Range(0, height);
        IEnumerable<int> ColsIndexes() => Enumerable.Range(0, width);
    }

    public static T Tap<T>(this T matrix, Action<T> action)
    {
        action(matrix);
        return matrix;
    }

    public static IEnumerable<(char, List<string>)> GroupIntoProblems(this char[,] matrix)
    {
        var current = new List<string>();
        var op = ' ';

        foreach (var row in matrix.Rows())
        {
            var number = string.Join("",row.SkipLast(1));
            var possibleOp = row.Last();

            if (number.Trim().Length == 0)
            {
                yield return (op, current);
                current = [];
            }
            else
            {
                if (possibleOp != ' ')
                {
                    op = possibleOp;
                }
                current.Add(number); 
            }
        }
        
        yield return (op, current);
    }

    public static IEnumerable<long> SolveEachProblem(this IEnumerable<(char, List<string>)> problems)
    {
        
        foreach (var problem in problems)
        {
            var (op, numbers) = problem;
            yield return op switch
            {
                '+' => numbers.Select(int.Parse).Sum(),
                '*' => numbers.Select(int.Parse).Aggregate(1L, (acc, cur) => acc * cur),
                _ => throw new Exception($"Invalid operator {op}")
            };
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
        return input
                .Split("\n")
                .Select(l => l.ToCharArray())
                .ToArray()
                .ToMatrix()
                .GroupIntoProblems()
                .SolveEachProblem()
                .Sum()
                .ToString();

    }

}
