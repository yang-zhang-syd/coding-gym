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

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr)
    {
        int[] results = new int[arr.Length];
        results[0] = arr[0];
        results[1] = arr[1] > arr[0] ? arr[1] : arr[0];
        int max = results[0] > results[1] ? results[0] : results[1];

        for (int i = 2; i < arr.Length; ++i)
        {
            //results[i] = arr[i] > 0 ? results[i - 2] + arr[i] : results[i - 1];
            int r1 = results[i - 2] + arr[i];
            int r2 = results[i - 1];
            results[i] = r1 > r2 ? r1 : r2;

            if (results[i] > max)
            {
                max = results[i];
            }
            else
            {
                results[i] = max;
            }
        }

        return max;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int res = maxSubsetSum(arr);

        Console.WriteLine(res);
    }
}
