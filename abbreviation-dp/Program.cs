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

    // Complete the abbreviation function below.
    static string abbreviation(string a, string b)
    {
        int[,] dp = new int[b.Length + 1, a.Length + 1];

        // Empty string can match with empty string.
        dp[0, 0] = 1;

        // Initialize first row of the dp table.
        var foundCapital = false;
        for (int i = 1; i <= a.Length; ++i)
        {
            if (!foundCapital && char.IsLower(a[i-1]))
            {
                dp[0, i] = 1;
            }
            else
            {
                foundCapital = true;
            }
        }

        for (int i = 1; i <= b.Length; ++i)
        {
            for (int j = 1; j <= a.Length; ++j)
            {
                if (a[j-1] == b[i-1])
                {
                    // a[j] must be capital here
                    dp[i, j] = dp[i - 1, j - 1] == 1 ? 1 : 0;
                }
                else if (char.IsLower(a[j-1]) && char.ToUpper(a[j-1]) == b[i-1])
                {
                    dp[i, j] = dp[i - 1, j - 1] == 1 || dp[i, j - 1] == 1 ? 1 : 0;
                }
                else
                {
                    if (char.IsLower(a[j-1]))
                    {
                        dp[i, j] = dp[i, j - 1] == 1 ? 1 : 0;
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }
        }

        return dp[b.Length, a.Length] == 1 ? "YES" : "NO";
    }

    //    "" d a B c d
    // ""  1 1 1 0 0 0
    // A   0 0 1 0 0 0
    // B   0 0 0 1 1 1
    // C   0 0 0 0 1 1
    

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = abbreviation(a, b);

            //textWriter.WriteLine(result);
            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
