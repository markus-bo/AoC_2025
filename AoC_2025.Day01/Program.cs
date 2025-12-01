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
using Microsoft.VisualBasic;
using System.Reflection.Emit;

internal class Solution
{
    static void Main(string[] args)
    {
        PuzzleSetup.Solve(solutionPart1, solutionPart2);
    }

    static object? solutionPart1(string[] input)
    {
        var result = 0;

        var rotations = input.Select(x => (rot: x[0], dis: int.Parse(new string(x[1..].AsSpan()))));
        var acc = 50;

        foreach(var rotation in rotations)
        {
            if (rotation.rot == 'L')
            {
                acc -= rotation.dis;
            }
            else
            {
                acc += rotation.dis;
            }

            Console.Error.WriteLine(acc);
            if (Math.Abs(acc) % 100 == 0)
            {
                result++;
            }
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0;

        var rotations = input.Select(x => (rot: x[0], dis: int.Parse(new string(x[1..].AsSpan()))));
        var acc = 50;

        foreach(var rotation in rotations)
        {
            if (rotation.rot == 'L')
            {
                acc -= rotation.dis;
            }
            else
            {
                acc += rotation.dis;
            }

            while (acc > 99)
            {
                result++;
                acc-= 100;
            }

            while (acc < 0)
            {
                result++;
                acc+= 100;
            }
        }

        return result;
    }
}