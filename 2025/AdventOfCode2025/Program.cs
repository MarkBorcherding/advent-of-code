using System.Reflection;
using AdventOfCode2025;

int? day = null;
int? part = null;
bool useExample = false;

for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "--day" && i + 1 < args.Length)
    {
        if (int.TryParse(args[i + 1], out int d) && d >= 1 && d <= 25)
        {
            day = d;
            i++;
        }
        else
        {
            Console.WriteLine("Error: --day must be followed by a number between 1 and 25");
            return 1;
        }
    }
    else if (args[i] == "--part" && i + 1 < args.Length)
    {
        if (int.TryParse(args[i + 1], out int p) && (p == 1 || p == 2))
        {
            part = p;
            i++;
        }
        else
        {
            Console.WriteLine("Error: --part must be followed by 1 or 2");
            return 1;
        }
    }
    else if (args[i] == "--input")
    {
        useExample = false;
    }
    else if (args[i] == "--example")
    {
        useExample = true;
    }
    else
    {
        Console.WriteLine($"Error: Unknown argument '{args[i]}'");
        Console.WriteLine("Usage: AdventOfCode2025 --day <day> --part <part> [--input|--example]");
        Console.WriteLine("Example: AdventOfCode2025 --day 1 --part 1 --input");
        Console.WriteLine("         AdventOfCode2025 --day 1 --part 2 --example");
        return 1;
    }
}

if (!day.HasValue)
{
    Console.WriteLine("Error: --day is required");
    Console.WriteLine("Usage: AdventOfCode2025 --day <day> --part <part> [--input|--example]");
    return 1;
}

if (!part.HasValue)
{
    Console.WriteLine("Error: --part is required");
    Console.WriteLine("Usage: AdventOfCode2025 --day <day> --part <part> [--input|--example]");
    return 1;
}

var fileName = useExample ? "sample.txt" : "input.txt";
var inputFile = $"Days/Day{day.Value:D2}/{fileName}";
if (!File.Exists(inputFile))
{
    Console.WriteLine($"Error: Input file not found: {inputFile}");
    return 1;
}

var input = File.ReadAllText(inputFile);

var puzzleTypeName = $"AdventOfCode2025.Days.Day{day.Value:D2}.Day{day.Value:D2}";
var puzzleType = Assembly.GetExecutingAssembly().GetType(puzzleTypeName);

if (puzzleType == null)
{
    Console.WriteLine($"Error: Puzzle implementation not found for Day {day.Value:D2}");
    return 1;
}

var puzzle = Activator.CreateInstance(puzzleType) as IPuzzle;
if (puzzle == null)
{
    Console.WriteLine($"Error: Could not create puzzle instance for Day {day.Value:D2}");
    return 1;
}

var result = part.Value == 1 ? puzzle.SolvePart1(input) : puzzle.SolvePart2(input);
Console.WriteLine($"Day {day.Value:D2} Part {part.Value}: {result}");
return 0;
