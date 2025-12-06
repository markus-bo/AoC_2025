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

        var numbers = input.SkipLast(1).Select(
                x => x.Split().Where(y => string.IsNullOrWhiteSpace(y) == false).Select(y => int.Parse(y.Trim())).ToList()).ToList();
        

        var operators = input.Last().Split().Where(y => string.IsNullOrWhiteSpace(y) == false).ToList();

        for(int i = 0; i < numbers.First().Count(); i++)
        {
            var intermediateResult = operators[i] == "*" ? 1L : 0L;

            for(int j = 0; j < numbers.Count; j++)
            {
                if (operators[i] == "*")
                {
                    intermediateResult *= numbers[j][i]; 
                }
                else if (operators[i] == "+")
                {
                    intermediateResult += numbers[j][i]; 
                }
                else
                    throw new NotImplementedException();
            }

            result += intermediateResult;
        }

        return result;
    }

    static object? solutionPart2(string[] input)
    {
        var result = 0L;

        var nums = new List<long>();

        for (int i = input.First().Length - 1; i >= 0 ; i--)
        {
            var numString = "";

            for (int j = 0; j < input.Length - 1; j++)
            {
                numString += input[j][i];
            }
            
            if (string.IsNullOrWhiteSpace(numString))
                continue;

            var num = long.Parse(numString);

            nums.Add(num);

            if (input[input.Length - 1][i] == ' ')
                continue;

            if (input[input.Length - 1][i] == '+')
            {
                result += nums.Sum();
                nums.Clear();
            }
            else if (input[input.Length - 1][i] == '*')
            {
                result += nums.Aggregate(1L, (a,b) => a*b);
                nums.Clear();
            }
            else
                throw new NotImplementedException(); 
        }

        return result;
    }
}