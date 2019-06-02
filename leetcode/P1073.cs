using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1073
{
    public class Solution {
        public int NumSubmatrixSumTarget(int[][] matrix, int target) {
            var cache = new Dictionary<(int, int, int, int), int>();
            var count = 0;
            var xlen = matrix.Length;
            var ylen = matrix[0].Length;
            for (var x1 = 0; x1 < xlen; x1++) {
                for (var x2 = x1; x2 < xlen; x2++) {
                    for (var y1 = 0; y1 < ylen; y1++) {
                        for (var y2 = y1; y2 < ylen; y2++) {
                            var result = SumCached(x1, x2, y1, y2);
                            if (result == target) count += 1;
                        }
                    }
                }
            }
            return count;

            int SumCached(int x1, int x2, int y1, int y2) {
                var key = (x1, x2, y1, y2);
                if (cache.TryGetValue(key, out int value)) return value;
                var result = Sum(x1, x2, y1, y2);
                cache[key] = result;
                return result;
            }
            int Sum(int x1, int x2, int y1, int y2) {
                if (x1 != x2) {
                    var sum1 = SumCached(x1, x1, y1, y2);
                    var sum2 = SumCached(x1 + 1, x2, y1, y2);
                    return sum1 + sum2;
                }
                if (y1 != y2) {
                    var sum1 = SumCached(x1, x2, y1, y1);
                    var sum2 = SumCached(x1, x2, y1 + 1, y2);
                    return sum1 + sum2;
                }
                return matrix[x1][y1];
            }
        }
        public void Main()
        {
            var matrix = new[] { new[] { 1, -1 }, new[] { -1, 1 } };
            var result = NumSubmatrixSumTarget(matrix, 0);
            Console.WriteLine($"result = {result}");
        }
    }
}
