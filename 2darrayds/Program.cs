using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        int max = int.MinValue;
        int lx = arr.Length;
        int ly = arr[0].Length;

        if (lx < 3 || ly < 3) return 0;

        for (int i = 0; i <= lx - 3; ++i)
        {
            for (int j = 0; j <= ly - 3; ++j)
            {
                int sum = arr[i][j] + arr[i][j+1] + arr[i][j+2] + arr[i+1][j+1] + arr[i + 2][j] + arr[i + 2][j+1] + arr[i + 2][j + 2];
                if (sum > max)
                {
                    max = sum;
                }
            }
        }

        return max;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
        Console.WriteLine(result);
    }
}