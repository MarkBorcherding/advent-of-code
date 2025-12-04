using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day17;

public class Day17 : IPuzzle
{
    public string SolvePart1(string input)
    {
        var (a, b, c, program) = ParseInput(input);
        var output = RunProgram(a, b, c, program);
        return string.Join(",", output);
    }

    public string SolvePart2(string input)
    {
        var (_, b, c, program) = ParseInput(input);

        // Find the value of A that makes the program output itself
        // Work backwards from the last output digit
        var candidates = new List<long> { 0 };

        for (int i = program.Length - 1; i >= 0; i--)
        {
            var newCandidates = new List<long>();
            foreach (var candidate in candidates)
            {
                for (int digit = 0; digit < 8; digit++)
                {
                    long testA = candidate * 8 + digit;
                    var output = RunProgram(testA, b, c, program);

                    if (output.Count == program.Length - i)
                    {
                        bool matches = true;
                        for (int j = 0; j < output.Count; j++)
                        {
                            if (output[j] != program[i + j])
                            {
                                matches = false;
                                break;
                            }
                        }
                        if (matches)
                        {
                            newCandidates.Add(testA);
                        }
                    }
                }
            }
            candidates = newCandidates;
        }

        return candidates.Count > 0 ? candidates.Min().ToString() : "0";
    }

    private (long a, long b, long c, int[] program) ParseInput(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        long a = long.Parse(Regex.Match(lines[0], @"\d+").Value);
        long b = long.Parse(Regex.Match(lines[1], @"\d+").Value);
        long c = long.Parse(Regex.Match(lines[2], @"\d+").Value);
        var program = Regex.Matches(lines[3], @"\d+").Select(m => int.Parse(m.Value)).ToArray();
        return (a, b, c, program);
    }

    private List<int> RunProgram(long a, long b, long c, int[] program)
    {
        var output = new List<int>();
        int ip = 0;

        while (ip < program.Length)
        {
            int opcode = program[ip];
            int operand = program[ip + 1];

            long comboValue = operand switch
            {
                0 or 1 or 2 or 3 => operand,
                4 => a,
                5 => b,
                6 => c,
                _ => 0
            };

            switch (opcode)
            {
                case 0: // adv
                    a = a >> (int)comboValue;
                    break;
                case 1: // bxl
                    b = b ^ operand;
                    break;
                case 2: // bst
                    b = comboValue % 8;
                    break;
                case 3: // jnz
                    if (a != 0)
                    {
                        ip = operand;
                        continue;
                    }
                    break;
                case 4: // bxc
                    b = b ^ c;
                    break;
                case 5: // out
                    output.Add((int)(comboValue % 8));
                    break;
                case 6: // bdv
                    b = a >> (int)comboValue;
                    break;
                case 7: // cdv
                    c = a >> (int)comboValue;
                    break;
            }

            ip += 2;
        }

        return output;
    }
}
