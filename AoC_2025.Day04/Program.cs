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

        var height = input.Length + 2;
        var width = input.First().Length + 2;

        var map = new char[height][];

        map[0] = new string('.', width).ToCharArray();
        map[^1] = new string('.', width).ToCharArray();

        for (int y = 1; y < height - 1; y++)
        {
            map[y] = $".{input[y - 1]}.".ToCharArray();
        }

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                var groupCount = 0;

                for (int _y = y - 1; _y <= y + 1; _y++)
                {
                    for (int _x = x - 1; _x <= x + 1; _x++)
                    {
                        if (map[_y][_x] == '@')
                            groupCount++;
                    }
                }
    
                if (map[y][x] == '@' && groupCount < 5)
                    result++;
            }
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0;

        var height = input.Length + 2;
        var width = input.First().Length + 2;

        var map = new char[height][];

        map[0] = new string('.', width).ToCharArray();
        map[^1] = new string('.', width).ToCharArray();

        for (int y = 1; y < height - 1; y++)
        {
            map[y] = $".{input[y - 1]}.".ToCharArray();
        }

        bool removedSome;
        
        do
        {
            removedSome = false;
            
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    var groupCount = 0;

                    for (int _y = y - 1; _y <= y + 1; _y++)
                    {
                        for (int _x = x - 1; _x <= x + 1; _x++)
                        {
                            if (map[_y][_x] == '@')
                                groupCount++;
                        }
                    }
        
                    if (map[y][x] == '@' && groupCount < 5)
                    {
                        map[y][x] = '.';
                        result++;
                        removedSome = true;
                    }
                }
            }
        }
        while(removedSome);

        return result;
    }
}