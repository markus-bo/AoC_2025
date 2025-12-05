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
using System.IO.Pipelines;

internal class Solution
{
    static void Main(string[] args)
    {
        PuzzleSetup.Solve(solutionPart1, solutionPart2);
    }

    static object? solutionPart1(string[] input)
    {
        var result = 0L;

        var idRanges = new List<(long start, long end)>();
        var ids = new List<long>();

        var readBlock1 = true;

        foreach(var line in input)
        {
            if (line == "")
            {
                readBlock1 = false;
                continue;
            }

            if (readBlock1)
            {
                var range = line.Split('-').Select(long.Parse);

                idRanges.Add((start: range.First(), end: range.Last()));
            }
            else
            {
                ids.Add(long.Parse(line));
            } 
        }

        foreach(var id in ids)
        {
            var valid = false;

            foreach(var range in idRanges)
            {
                if (id >= range.start && id <= range.end)
                {
                    valid = true;
                    break;
                }
            }

            if (valid)
                result++;    
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0L;

        var idRanges = new List<(long start, long end)>();

        foreach(var line in input)
        {
            if (line == "")
            {
                break;
            }

            var range = line.Split('-').Select(long.Parse);

            idRanges.Add((start: range.First(), end: range.Last()));
        }

        var currentEnd = 0L;

        foreach(var range in idRanges
                                .OrderBy(x => x.start)
                                .ThenByDescending(x => x.end))
        {
            if (range.end <= currentEnd)
            {
                continue;
            }
            
            result += range.end - Math.Max(currentEnd + 1, range.start) + 1;

            currentEnd = range.end;
        }

        return result;
    }
}