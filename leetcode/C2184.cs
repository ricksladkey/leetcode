using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode1284
{
    public class Solution
    {
        private bool _debug = false;
        private Solution SetDebug(bool debug)
        {
            _debug = debug;
            return this;
        }
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

            // The number starts with a non-zero digit. Count non-duplicates
            // that start with one through through the first digit followed by
            // all zeros.
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
            var itself = BruteDup(N) ? 0 : 1;
            Debug(N, N, itself);
            result += itself;
            return N - result;
        }
        private void Debug(int lo, int hi, int result)
        {
            if (_debug)
            {
                Console.WriteLine("{0} - {1}: {2} (brute {3})",
                    lo, hi, result, BruteNumNonDupDigitsAtMostN(lo, hi));
            }
        }
        private int CountNonDupPow10(int power)
        {
            var result = 0;
            for (var i = 1;  i <= power; i++)
            {
                var product = 9;
                for (var factor = 9; factor > 9 - i; factor--) product *= factor;
                Debug((int)Math.Pow(10, power - 1), (int)(Math.Pow(10, power) - 1), result);
                result += product;
            }
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
        private bool BruteDup(int i)
        {
            var seen = new bool[10];
            var test = i;
            for (var j = 0; j < 10; j++) seen[j] = false;
            while (test != 0)
            {
                var digit = test % 10;
                if (seen[digit])
                {
                    return true;
                }
                seen[digit] = true;
                test = test / 10;
            }
            return false;
        }
        private int BruteNumDupDigitsAtMostN(int N1, int N2)
        {
            var result = 0;
            for (var i = N1; i <= N2; i++)
            {
                result += BruteDup(i) ? 1 : 0;
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
            Console.WriteLine("{0}: {1}, (brute {2})", N, NumDupDigitsAtMostN(N), BruteNumDupDigitsAtMostN(N));
        }
        private void CheckResult(int N)
        {
            if (BruteNumDupDigitsAtMostN(N) != NumDupDigitsAtMostN(N))
            {
                SetDebug(true);
                Console.WriteLine("FAIL {0}: {1} (brute {2})", N, NumDupDigitsAtMostN(N), BruteNumDupDigitsAtMostN(N));
                Environment.Exit(1);
            }
        }
        public void Main()
        {
            for (var i = 1; i <= 1000; i++) CheckResult(i);
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
