using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace leetcode1263
{
    public class Solution
    {
        public int LongestOnes(int[] A, int K)
        {
            var zeroes = A.Select((value, index) => Tuple.Create(value, index))
                .Where(pair => pair.Item1 == 0)
                .Select(pair => pair.Item2)
                .ToArray();
            K = Math.Min(K, zeroes.Length);
            var flip = new int[K];
            for (var i = 0; i < K; i++) flip[i] = zeroes[i];
            var B = A.ToArray();
            for (var i = 0; i < K; i++) B[flip[i]] = 1;
            var max = 0;
            var sofar = 0;
            for (var i = 0; i < B.Length; i++)
            {
                max = Math.Max(max, sofar);
                if (B[i] == 0)
                {
                    sofar = 0;
                }
                else
                {
                    sofar += 1;
                }
            }
            max = Math.Max(max, sofar);
            return max;
        }
    }
}
