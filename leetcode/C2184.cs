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

            // Count non-duplicates for each prefix up to each remaining digit.
            var appeared = new bool[10];
            for (var i = digits.Count - 2; i >= 0; i--)
            {
                var digit = digits[i];
                var left = 10 - (digits.Count - i);
                var mult = digit;
                for (var j = 0; j < digit; j++)
                {
                    if (appeared[j]) mult -= 1;
                }
                result += mult * CountNonDup(i, left);
                if (appeared[digit]) break;
                appeared[digit] = true;
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
        private int BruteNumDupDigitsAtMostN(int N)
        {
            return BruteNumDupDigitsAtMostN(1, N);
        }

        private int BruteNumNonDupDigitsAtMostN(int N1, int N2)
        {
            return N2 - N1 + 1 - BruteNumDupDigitsAtMostN(N1, N2);
        }
        private void RunTest(int N)
        {
            Console.WriteLine("{0}: {1}, {2}", N, BruteNumDupDigitsAtMostN(N), NumDupDigitsAtMostN(N));
        }
        public void Main()
        {
            RunTest(20);
            RunTest(1);
            RunTest(10);
            RunTest(100);
            RunTest(1000);
            RunTest(2000);
            RunTest(2100);
            RunTest(2130);
            RunTest(2134);
            RunTest(76528);
        }
    }
}
