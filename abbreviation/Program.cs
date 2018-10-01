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

    static bool canConvertFromAToB(string a, string b)
    {
        int aStartIdx = 0;
        int bStartIdx = 0;

        if (a.Length == 0)
        {
            if (b.Length == 0) return true;
            return false;
        }

        if (b.Length == 0)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (char.IsUpper(a[i])) return false;
            }

            return true;
        }

        while (a[aStartIdx] == b[bStartIdx])
        {
            aStartIdx++;
            bStartIdx++;

            if (aStartIdx == a.Length && bStartIdx == b.Length)
            {
                return true;
            }

            if (aStartIdx == a.Length && bStartIdx != b.Length)
            {
                return false;
            }

            if (aStartIdx != a.Length && bStartIdx == b.Length)
            {
                return canConvertFromAToB(a.Substring(aStartIdx), "");
            }
        }

        if (Char.IsUpper(a[aStartIdx])) return false;

        if (char.ToUpper(a[aStartIdx]) == b[bStartIdx])
        {
            return canConvertFromAToB(a.Substring(aStartIdx + 1), b.Substring(bStartIdx + 1)) ||
                   canConvertFromAToB(a.Substring(aStartIdx + 1), b.Substring(bStartIdx));
        }

        return canConvertFromAToB(a.Substring(aStartIdx + 1), b.Substring(bStartIdx));
    }

    // Complete the abbreviation function below.
    static string abbreviation(string a, string b)
    {
        if (canConvertFromAToB(a, b))
        {
            return "YES";
        }

        return "NO";
    }

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
