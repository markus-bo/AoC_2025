using AoC_Toolbox;
using AoC_Toolbox.Geometry;
using AoC_Toolbox.InputParsing;
using AoC_Toolbox.Pathfinding;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

internal class Solution
{
    static void Main(string[] args)
    {
        PuzzleSetup.Solve(solutionPart1, solutionPart2);
    }

    static object? solutionPart1(string[] input)
    {
        var result = 0;

        foreach(var line in input)
        {
            var max1 = line[..(line.Length-1)].Select(x => x- '0').Max();

            var index = line.IndexOf((char)(max1 + '0'));

            var max2 = line[(index + 1)..].Select(x => x- '0').Max();

            result += max1 * 10 + max2;
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0L;

        foreach(var line in input)
        {
            var index = -1;

            for (int i = 11; i >= 0; i--)
            {
                var leftBound = index + 1;
                var rightBound = line.Length - i;

                var max = line[leftBound..rightBound].Max();

                index = line.IndexOf(max, leftBound);

                result += (long)Math.Pow(10, i) * (max - '0');
            }
        }

        return result;
    }
}