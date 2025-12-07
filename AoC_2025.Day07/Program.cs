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

        var line = new bool[input.First().Length];

        var xStart = input.First().IndexOf('S');
        line[xStart] = true;

        for (int i = 1; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == '^' && line[j] == true) // split
                {
                    result++;

                    line[j] = false;
                    
                    if ((j - 1) >= 0)
                        line[j-1] = true;
                    
                    if ((j+1) < line.Length)
                        line[j+1] = true;
                }        
            }   
        }
        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var xStart = input.First().IndexOf('S');

        map = input;
        memo.Clear();

        var result = dfs(xStart, 1);

        return result;
    }

    static string[] map;

    static Dictionary<(int y, int x), long> memo = new Dictionary<(int y, int x), long>();

    static long dfs(int xCurrent, int yCurrent)
    {
        if (memo.ContainsKey((yCurrent, xCurrent)))
        {
            return memo[(yCurrent, xCurrent)];
        }

        if (yCurrent == map.Length)
        {
            return 1L;
        }

        if (xCurrent < 0 || xCurrent >= map.First().Length)
        {
            return 0L;
        }

        var _count = 0L;

        if (map[yCurrent][xCurrent] == '^')
        {
            _count += dfs(xCurrent - 1, yCurrent + 1);
            _count += dfs(xCurrent + 1, yCurrent + 1);
        }
        else
        {
            _count += dfs(xCurrent, yCurrent + 1);
        }

        memo.Add((yCurrent, xCurrent), _count);

        return _count;
    }
}