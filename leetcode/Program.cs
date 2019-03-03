using System;
using leetcode1263;

namespace leetcode
{
    class Program
    {
        public static void Main()
        {
            var A = new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            var K = 2;
            var result = new Solution().LongestOnes(A, K);
            Console.WriteLine(result);
        }
    }
}
