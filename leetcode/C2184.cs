using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode1284
{
    public class Solution
    {
        public int NumDupDigitsAtMostN(int N)
        {
            var result = 0;
            var digits = new List<int>();
            var current = N;
            while (current != 0)
            {
                digits.Add(current % 10);
                current /= 10;
            }

            // Count non-duplicates of largest power of ten not greater than N.
            result += CountNonDupPow10(digits.Count - 1);

            // Count non-duplicates that start with one through through the first digit
            // followed by all zeros.
            result += (digits[digits.Count - 1] - 1) * CountNonDup(digits.Count - 1, 9);

            // Count non-duplicates for each prefix upto each remaining digit.
            for (var i = digits.Count - 2; i >= 0; i--)
            {
                var digit = digits[i];
                var left = 10 - (digits.Count - i);
                result += digit * CountNonDup(i, left);
            }
            return N - result;
        }
        private int CountNonDupPow10(int power)
        {
            var result = 0;
            for (var i = power - 1; i >= 0; i--)
            {
                var product = 9;
                for (var factor = 9; factor > 9 - i; factor--) product *= factor;
                result += product;
            }
            if (power < 2) result += 1;
            return result;
        }
        private int CountNonDup(int count, int distinct)
        {
            if (distinct < count) return 0;
            var result = 0;
            var product = 1;
            for (var factor = distinct; factor > distinct - count; factor--) product *= factor;
            result += product;
            return result;
        }
        private int BruteNumDupDigitsAtMostN(int N1, int N2)
        {
            var result = 0;
            var seen = new bool[10];
            for (var i = N1; i <= N2; i++)
            {
                var test = i;
                for (var j = 0; j < 10; j++) seen[j] = false;
                while (test != 0)
                {
                    var digit = test % 10;
                    if (seen[digit])
                    {
                        result += 1;
                        break;
                    }
                    seen[digit] = true;
                    test = test / 10;
                }
            }
            return result;
        }
        private int BruteNumNonDupDigitsAtMostN(int N1, int N2)
        {
            return N2 - N1 + 1 - BruteNumDupDigitsAtMostN(N1, N2);
        }
        public void Main()
        {
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(20), 1);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(1), 0);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(10), 0);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(100), 10);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(1000), 262);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(10000), 4726);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(20000), 11702);
            Console.WriteLine("{0}, {1}", NumDupDigitsAtMostN(76528), 50867);
        }
    }
}
