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
        var result = 0L;

        var ranges = input.First().Split(',');

        foreach(var range in ranges)
        {
            var parsedRanges = range.Split('-').Select(long.Parse);

            var startRange = parsedRanges.First();
            var endRange = parsedRanges.Last();

            for (long i = startRange; i <= endRange; i++)
            {
                var id = i.ToString();

                if (id.Length % 2 == 1)
                {
                    continue;
                }

                if (id[..(id.Length/2)] == id[(id.Length/2)..])
                {
                    result += i;
                }
            }
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0L;

        var ranges = input.First().Split(',');

        foreach(var range in ranges)
        {
            var parsedRanges = range.Split('-').Select(long.Parse);

            var startRange = parsedRanges.First();
            var endRange = parsedRanges.Last();

            for (long i = startRange; i <= endRange; i++)
            {
                var id = i.ToString();

                for (int j = 1; j < id.Length; j++)
                {
                    var subId = new string(id[..j].ToArray());
                    
                    if (id.Replace(subId, "").Length == 0)
                    {
                        result += i;

                        break;
                    }
                }
            }
        }

        return result;
    }
}