﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1073
{
    public class Solution {
        public int NumSubmatrixSumTarget(int[][] matrix, int target) {
            var xlen = matrix.Length;
            var ylen = matrix[0].Length;
            var sums = new int[xlen + 1][];
            for (var x = 0; x <= xlen; x++) sums[x] = new int[ylen];
            for (var y = 0; y < ylen; y++) {
                sums[0][y] = 0;
                for (var x = 1; x <= xlen; x++) {
                    sums[x][y] = sums[x - 1][y] + matrix[x - 1][y];
                }
            }
            var count = 0;
            for (var x1 = 0; x1 < xlen; x1++) {
                for (var x2 = x1; x2 < xlen; x2++) {
                    for (var y1 = 0; y1 < ylen; y1++) {
                        var sum = 0;
                        for (var y2 = y1; y2 < ylen; y2++) {
                            sum += sums[x2 + 1][y2] - sums[x1][y2];
                            if (sum == target) count += 1;
                        }
                    }
                }
            }
            return count;
        }
        public void Main()
        {
            var matrix1 = new[] { new[] { 1, -1 }, new[] { -1, 1 } };
            var matrix2 =
new [] {
new[] { 1,0,0,1,0,0,1,1,1,1,1,1,1,0,1,0,0,1,0,0,1,1,1,1,1,1,0,1,0,0,1,0,0,1,0,1,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,1,1,0,1,0,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,1,0,0,0,1,1,1,1,0,1,0,1,1,1,0,1,1,0 },
new[] { 0,0,0,0,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,0,0,1,1,0,0,1,0,1,0,0,1,0,0,0,0,0,1,0,1,1,1,1,1,0,1,1,0,1,0,0,1,1,0,0,1,1,0,0,0,0,0,1,0,0,0,1,0,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,0,0,0,0,0,1,1 },
new[] { 0,1,0,0,1,0,0,0,0,1,1,1,1,0,1,1,0,0,1,0,1,1,0,1,0,0,0,0,0,1,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,1,0,1,0,1,1,1,0,0,0,1,1,1,1,0,1,0,1,1,0,1,0,0,1,1,0,0,1,1,0,0,1,0,0,0,1,1,0,1,0,0,1,1,0,0,1,0,1,1,0,1,0,0,1,1 },
new[] { 1,1,0,1,0,1,0,1,1,1,0,1,1,1,0,1,0,1,1,1,1,0,0,1,1,0,0,0,0,0,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,0,0,0,1,1,1,0,0,1,0,1,0,1,0,0,1,1,0,1,1,0,0,0,0,1,1,1,1,1,0,1,0,1,1,0,1,1,1,0,1,1,0,1,0,1,0,0,0,0,1,0,1,0,0,1 },
new[] { 1,0,0,1,1,1,0,0,0,1,1,1,1,0,1,0,0,0,1,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,1,0,1,0,1,1,1,1,0,0,0,1,1,0,1,1,1,0,0,1,1,1,1,0,1,1,1,1,0,1,1,1,1,0,0,0,0,0,1,1,0,0,1,1,1,0,1,1,0,1,0,0,0,1,1,0,0,0,1,1,1,1,0,0,1 },
new[] { 1,0,1,0,0,0,1,1,1,0,1,0,0,1,1,1,1,1,1,1,0,1,1,0,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,0,1,0,0,1,1,1,1,1,1,1,0,1,1,0,0,1,1,0,1,0,1,1,0,1,0,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,0,0,1,1,0,1,1,0,1,0,0,1,1,1,1 },
new[] { 1,0,0,0,0,1,0,0,0,0,1,0,1,1,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,1,0,1,0,1,0,0,1,1,0,1,0,1,1,1,1,0,0,1,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,0,0,0,1,0,1,0,0,0,1,0,0,1,0,0,0,1,0,1,0,1,1,0,0,0,0,0,1,0,1,0,1,0 },
new[] { 1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,0,1,0,1,1,1,1,0,0,0,1,1,1,1,0,0,1,1,1,0,0,0,1,1,1,1,0,0,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,0,0,1,1,0,0,0,0,0 },
new[] { 1,0,0,0,0,0,0,1,0,1,1,0,1,1,1,1,0,1,1,0,0,0,0,1,1,0,1,0,0,1,0,0,1,0,1,1,0,1,0,0,0,1,1,0,1,1,1,1,0,1,0,0,1,0,0,1,0,1,1,0,1,1,0,1,0,1,0,1,1,0,0,0,1,1,1,0,1,0,1,1,1,1,0,1,0,0,0,0,1,1,0,1,1,1,0,0,1,1,0,0 },
new[] { 1,0,0,0,1,1,1,1,1,0,1,0,1,0,0,1,1,0,0,0,1,0,0,0,1,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,1,0,0 },
new[] { 0,1,0,1,0,1,0,0,1,0,1,1,0,1,1,0,1,1,0,0,1,0,0,1,0,1,1,1,1,0,1,1,0,0,0,0,1,0,1,0,1,0,0,0,1,1,1,1,0,0,1,0,1,0,1,0,1,0,1,0,0,0,1,1,0,1,1,1,1,0,0,1,1,1,1,0,1,0,1,0,0,1,1,0,1,1,0,0,1,1,0,1,1,1,0,0,0,1,1,0 },
new[] { 0,0,0,0,1,0,0,0,0,0,1,0,0,0,1,1,0,1,1,1,0,0,1,0,0,0,0,1,1,1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,1,0,0,1,0,1,0,1,1,1,0,1,0,0,0,0,0,1,1,0,1,1,0,0,0,0,1,1,0,0,1,1,1,1,0,0,0,0,0,1,1,0,1,0,1,1,1,1,0,1,0,0,0,1,1,1 },
new[] { 0,0,0,0,1,1,1,0,0,1,1,1,0,0,1,0,0,1,0,0,0,0,1,1,1,0,1,1,0,0,0,0,0,0,0,1,1,0,1,1,1,1,0,1,0,1,0,0,0,1,1,1,0,1,0,1,1,0,0,0,0,0,0,1,0,0,1,1,0,1,0,1,1,0,0,0,0,0,0,1,0,0,0,0,1,0,1,1,0,0,1,0,1,1,0,1,0,0,1,0 },
new[] { 1,0,0,0,0,0,1,1,0,0,1,0,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,0,0,1,1,0,1,1,0,1,0,0,0,0,0,1,1,1,1,1,1,0,1,0,0,0,1,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0,1,0,1,1,0,1,0,0,1,1,1,0,0,0,1,0,0,1,1,0,0,0 },
new[] { 0,0,0,1,1,1,0,1,1,0,1,0,1,1,0,0,1,1,0,1,1,0,0,1,1,0,1,1,0,1,0,0,0,0,0,1,1,0,0,0,1,1,0,1,1,0,1,1,0,1,0,1,0,0,0,1,1,1,0,0,1,1,0,0,0,0,0,1,1,0,1,1,0,0,0,1,1,0,1,1,1,0,1,1,0,1,1,1,0,0,0,1,1,0,0,0,0,0,0,1 },
new[] { 1,1,1,1,1,0,0,0,1,0,0,1,1,0,1,1,0,0,1,1,0,1,1,0,1,0,1,0,0,1,0,1,1,0,1,1,0,1,1,0,0,1,1,1,1,0,0,1,1,0,0,1,1,1,1,0,1,0,1,0,1,1,1,1,1,0,0,1,1,0,1,0,1,1,1,1,0,1,1,0,1,0,1,0,1,0,1,0,1,1,1,0,0,0,0,1,1,1,1,1 },
new[] { 1,0,0,1,0,0,0,0,0,1,1,0,0,0,1,1,1,0,0,0,1,1,0,0,1,1,0,0,0,1,0,0,1,1,0,1,1,1,0,1,1,0,1,0,1,1,0,1,0,0,0,0,1,0,0,1,0,1,0,0,0,1,1,0,1,1,0,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,0,1,1,0,0,1,1,1,0,1,0,1,1,1,0 },
new[] { 0,0,1,1,1,0,1,1,0,1,0,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,1,1,0,1,1,1,1,0,0,0,0,0,1,1,1,1,0,1,0,0,1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,0,0,1,0,0,0,1,0,1,1,0,1,1,1,0,1,0,0,1,0,1,1,1,1,0,1,0,0,1,1,1,0,1,1,1 },
new[] { 0,1,0,0,1,1,1,0,0,1,1,1,0,1,0,1,1,0,0,1,0,0,0,1,1,1,1,1,0,1,1,1,0,0,1,1,1,1,0,1,1,0,1,0,0,0,0,1,1,1,0,1,0,1,0,1,0,1,1,0,1,1,0,0,0,0,1,0,0,1,0,0,0,0,1,1,1,0,1,1,1,0,0,0,1,1,0,0,1,0,1,0,0,0,0,1,1,0,0,1 },
new[] { 1,0,1,1,1,0,1,0,1,1,1,0,0,0,1,0,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,1,1,0,1,0,0,0,0,1,1,1,0,0,1,0,1,0,0,0,0,1,1,1,0,0,0,0,0,0,1,0,1,1,1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,1,1,1,1,1,1,1,0,0,0,0 },
new[] { 0,0,1,0,0,1,0,1,0,1,1,0,1,1,1,1,1,1,1,0,0,1,0,1,1,0,0,0,0,0,0,1,0,1,0,0,0,1,1,1,0,0,1,1,0,0,0,0,1,0,0,0,1,0,1,0,0,1,1,0,1,0,1,0,1,1,1,1,0,1,1,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,1,1,0,0,1,1,0,0,0,0,0,0,0 },
new[] { 0,0,1,0,1,0,0,1,1,1,0,0,0,0,1,1,1,1,0,1,1,0,0,1,0,0,0,0,1,1,1,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,1,1,0,0,0,1,0,0,1,0,1,1,1,1,0,0,1,0,0,0,0,0,1,0,0,0,1,1,0,0,1,1,1,0,1,1,1,1,0,1,1,1,1 },
new[] { 1,0,1,0,1,0,0,1,0,1,0,1,1,1,1,1,0,0,1,1,0,1,1,1,0,1,1,0,0,1,1,1,1,0,1,0,0,0,0,0,1,0,1,1,0,0,1,0,1,1,1,1,0,1,0,0,1,1,1,0,1,0,1,0,1,0,1,0,0,1,0,0,1,0,0,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,0,0,0,1,0,0,1,1,1,0 },
new[] { 1,0,0,1,1,1,1,1,0,0,1,0,1,1,0,1,1,1,0,1,0,1,0,1,1,0,0,1,0,1,0,0,0,0,1,0,0,0,1,1,1,0,1,0,0,0,1,0,1,1,1,0,1,0,0,0,1,1,0,1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1,0,1,1,1 },
new[] { 1,0,1,0,1,1,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,0,1,0,1,1,1,1,1,1,0,1,0,1,0,1,1,0,0,1,1,0,1,1,1,0,0,1,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,0,1,0,0,0,1,0,1,0,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,1,0,0 },
new[] { 1,0,1,0,0,1,0,0,0,0,1,1,0,1,1,0,1,0,0,1,1,1,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,1,0,1,0,0,1,0,0,0,0,0,0,0,1,1,1,0,1,0,0,0,1,1,1,0,0,0,0,1,1,0,0,1,0,0,1,0,1,0,1,1,0,1,1,0,1,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,1,0 },
new[] { 0,1,0,0,1,0,1,1,0,1,0,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1,1,1,0,0,0,1,0,0,0,0,0,0,1,1,0,1,1,1,0,1,0,0,0,0,1,1,1,1,0,1,1,0,1,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,1,0,1,0,0,1,1,0,0,1,0,1,1,1,0,0,1,0,1,1,0,1,0,1,0,0 },
new[] { 0,1,1,0,1,0,0,0,0,0,1,0,1,1,0,1,1,0,1,0,0,1,0,1,0,0,1,0,0,1,0,0,0,1,1,0,1,0,1,1,1,0,1,1,0,0,1,1,0,0,1,1,1,0,0,1,0,1,1,0,0,0,1,1,0,1,1,0,1,1,1,0,1,1,1,0,1,1,0,1,0,1,1,1,1,0,0,0,0,0,0,1,1,1,1,0,0,1,0,0 },
new[] { 1,0,0,0,1,0,0,0,1,0,0,0,1,0,1,1,1,0,0,1,1,1,1,0,0,0,1,0,0,1,1,0,1,0,0,1,0,1,0,1,0,1,1,1,0,0,0,1,0,0,0,0,0,1,1,0,1,1,0,1,1,1,0,0,1,1,0,1,1,0,0,0,0,0,1,0,1,1,0,1,0,0,0,1,1,1,0,1,1,1,0,1,0,1,0,0,1,1,1,1 },
new[] { 1,0,1,1,0,1,1,1,0,1,0,0,0,1,0,0,0,0,0,1,0,1,1,1,1,0,1,0,0,1,1,0,1,1,1,0,0,1,0,1,1,1,1,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,1,1,0,0,0,0,1,0,0,1,0,0,0,1,0,0,1,0,0,1,1,0,1,1,1,0,0,1,1,0,1,0,1,1,0,0,1,1,0,0,0,0 },
new[] { 0,0,1,0,1,0,0,1,1,1,1,0,0,1,1,0,1,0,0,1,0,0,0,0,1,1,0,0,0,1,0,1,0,0,0,1,1,1,1,1,0,0,1,1,0,1,0,1,1,0,1,1,1,0,0,1,1,0,0,0,1,1,1,1,0,1,0,1,0,0,1,0,1,1,1,1,1,0,1,0,1,0,0,1,0,0,0,1,0,0,0,1,0,1,0,0,1,1,1,1 },
new[] { 0,0,0,1,0,1,1,1,1,0,1,0,0,1,1,0,0,0,0,0,0,1,1,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,0,0,1,1,0,1,1,1,1,1,0,0,0,1,0,1,0,1,1,1,0,0,1,0,1,0,1,1,1,0,0,0,1,0,1,0,0,1,1,0,0,0,0,1,1,0,1,1,0,0,1,1,0,1,0,1,0,0,1,1,0,0 },
new[] { 0,0,1,0,1,0,0,1,1,1,1,1,0,1,0,1,1,0,0,0,1,1,1,0,0,1,0,1,1,0,0,0,0,0,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,0,1,0,1,0,1,1,1,0,0,0,0,0,0,1,1,0,1,1,0,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,1,0,1,1,0 },
new[] { 1,1,0,1,0,0,0,1,1,1,1,0,0,0,1,1,0,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,1,0,1,0,0,1,0,1,0,0,1,0,0,1,0,0,1,1,1,0,1,1,1,0,1,0,0,1,0,0,0,0,1,0,0,1,0,0,0,1,1,1,0,1,1,1,0,1,0,0,1,0,0,1,1,1,1,0,0,0,1,1,0,0,0,1 },
new[] { 0,1,0,0,0,1,1,1,1,0,0,1,1,1,1,0,1,0,0,0,0,1,1,1,0,1,0,1,1,0,0,1,1,0,0,1,0,0,0,1,0,1,0,1,0,0,1,1,0,0,0,0,0,1,0,0,1,0,1,1,1,0,0,1,0,1,0,0,0,0,0,0,1,0,0,1,0,1,0,1,0,1,1,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0 },
new[] { 1,0,0,0,0,0,0,1,0,1,1,0,1,0,0,0,1,0,1,0,0,0,1,1,1,0,1,0,0,0,1,0,0,0,1,1,1,0,0,1,1,0,0,1,0,0,1,0,1,1,0,0,0,0,0,1,0,0,0,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,1,1,1,0,0,0,1,0,1,1,1,0,1,1,0,0,0,1,0,0,0,1,0 },
new[] { 0,0,1,0,1,0,0,0,1,1,0,0,0,0,1,0,1,0,1,1,0,1,1,0,1,0,0,1,0,0,1,1,1,0,1,1,1,0,1,1,1,0,0,1,0,1,1,0,1,0,0,0,1,0,0,1,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,1,0,1,1,0,0,1,0,0,0,0,1,1,0,1,1,1,1,0,0,1 },
new[] { 0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,1,0,0,1,0,0,1,1,0,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,0,0,1,0,0,0,1,0,1,1,1,1,1,1,0,1,1,0,0,1,1,1,0,1,0,0,1,0,0,1,1,0,0,0,1,0,1,1,0,1,0,1,0,0,0,0,0,1,1,1,1,0 },
new[] { 1,0,1,1,1,1,1,0,0,1,1,0,0,0,0,0,1,0,1,1,1,1,0,1,0,1,1,1,0,1,0,0,1,1,1,0,1,0,1,1,0,0,0,0,1,1,1,0,1,1,0,1,0,1,1,1,1,1,1,0,1,1,1,0,0,0,0,0,1,0,0,0,1,1,0,0,1,1,1,0,0,0,1,0,0,1,0,0,0,0,1,1,1,0,0,0,1,1,0,0 },
new[] { 1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,1,0,0,1,1,0,1,0,0,1,0,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1,0,0,1,0,1,1,0,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,1,1,0,0,0,1,0 },
new[] { 1,0,0,1,1,1,1,0,1,0,1,1,1,0,1,1,0,1,0,1,1,0,1,1,0,1,1,1,0,0,0,1,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,1,1,0,0,1,1,1,0,1,1,1,1,1,0,1,1,1,0,0,0,0,1,1,0,0,0,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,1,1,0,0,0,1 },
new[] { 0,0,1,0,1,1,1,1,0,0,0,1,0,1,1,0,0,1,0,1,0,0,0,0,0,0,0,1,1,0,0,1,1,0,1,0,0,0,0,0,0,0,0,1,1,0,1,0,0,1,1,1,0,0,1,0,0,1,0,1,1,0,0,0,0,1,0,1,0,0,0,0,1,0,0,1,1,0,1,0,1,1,0,1,0,0,0,1,1,1,0,0,0,1,0,0,1,0,1,0 },
new[] { 1,1,1,1,0,1,0,1,0,0,0,1,1,1,0,0,1,0,1,1,1,1,0,0,1,1,0,1,1,0,0,1,0,0,0,0,0,1,0,0,0,1,1,1,1,1,1,0,1,0,0,1,1,0,1,0,1,1,1,0,0,1,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,1,1,1,0,0,1,0,0,1,0,1,1,1,0,0,1,1,0 },
new[] { 1,1,1,1,0,0,1,1,0,0,1,0,1,0,0,1,1,1,0,1,0,0,0,1,1,1,1,0,1,1,1,0,1,1,1,0,0,1,0,1,1,0,0,0,1,1,1,0,1,0,0,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,1,1,1,1,0,1,1,1,1,1,1,0,0,1,0,1,0,1,1,0,1,1,1 },
new[] { 0,0,0,0,0,1,0,0,0,0,1,0,1,1,0,1,1,1,0,0,0,0,0,1,1,0,1,1,1,1,1,0,0,1,1,0,1,1,1,0,0,1,1,1,0,1,1,0,1,0,1,1,0,0,1,0,0,1,1,1,0,0,0,1,1,0,1,1,0,0,1,1,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,0,1,0,0,0,1,0,1,1,1,1 },
new[] { 1,1,0,1,0,0,0,1,0,0,0,0,1,0,0,1,0,1,1,0,0,1,1,0,1,1,0,0,1,1,1,0,0,1,1,1,0,1,1,0,0,0,1,0,0,1,0,1,0,0,1,1,1,0,0,1,1,0,1,0,0,1,1,1,0,0,0,0,0,1,0,0,0,1,0,1,1,1,1,0,0,0,1,0,1,1,0,1,1,0,1,1,0,1,0,1,0,0,1,0 },
new[] { 0,1,0,1,1,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,0,1,1,1,1,1,1,0,0,1,0,1,1,0,1,1,0,0,1,0,1,1,0,0,1,1,1,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,1,1,0,1,1,1,0,1,1,0,1,0,1,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,1,1,0,1,0 },
new[] { 1,1,1,1,1,1,0,0,0,1,1,0,1,1,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,1,0,1,1,0,1,0,0,1,1,1,1,0,1,1,1,0,1,0,1,0,0,1,0,0,1,0,1,0,0,0,1,1,1,0,0,1,0,1,0,1,1,0,1,1,0,1,1,0,0,1,0,1,0,0,0,1,0,1,0,1,0,1,0 },
new[] { 0,0,1,0,0,0,1,1,0,0,1,0,1,1,0,0,1,1,1,1,1,1,0,1,0,1,0,0,1,1,1,0,1,0,0,1,0,0,1,0,0,1,0,1,1,1,0,1,1,0,0,1,0,1,1,1,0,0,0,1,0,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,0,1,1,0,1,0,0,1,1,1,0,1,0,1,0,1,0,0,0,1,0,1,1 },
new[] { 1,1,1,1,0,1,0,0,0,1,0,0,0,1,0,0,1,0,0,0,1,0,0,1,1,1,1,0,1,0,0,0,0,1,0,0,0,1,0,0,1,1,0,1,0,1,1,0,0,0,1,0,1,1,1,0,0,1,0,1,1,1,0,0,1,1,1,0,1,0,1,0,0,0,1,0,1,1,1,0,0,1,1,1,0,1,0,0,0,1,1,1,0,1,0,0,1,1,0,0 },
new[] { 0,1,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,1,0,1,0,0,1,1,1,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,1,0,1,0,0,1,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,0,1,1,1,0,1,1,1,0,1,0,1,0 },
new[] { 1,0,1,0,0,0,0,0,1,1,0,0,0,1,0,1,1,0,1,1,1,1,0,0,0,1,1,1,0,0,1,0,0,1,0,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,1,1,1,1,0,0,1,1,0,1,0,0,1,1,1,0,1,1,0,0,0,1,0,1,0,1,1,1,0,1,0,0,1,1,1,1,1,0,1,1 },
new[] { 1,1,1,1,0,1,0,1,1,1,0,0,1,1,0,1,1,0,1,1,1,0,1,0,0,0,1,1,0,1,0,1,0,1,1,0,1,1,0,0,1,1,0,1,1,1,1,1,0,0,1,1,1,0,0,0,0,1,1,0,0,1,0,0,1,0,0,0,0,1,1,1,1,1,1,0,0,1,1,0,0,0,0,1,0,1,1,1,0,1,1,0,1,0,0,0,0,0,1,0 },
new[] { 1,1,0,0,1,1,0,1,1,0,0,1,1,1,0,1,1,1,1,1,1,0,0,1,1,1,1,0,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,0,1,0,0,0,1,1,1,0,1,0,0,0,1,0,1,1,1,0,1,0,0,0,0,1,1,0,0,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,0 },
new[] { 0,0,0,0,1,1,1,1,0,0,0,1,0,0,1,1,0,0,1,0,0,1,1,0,1,1,0,0,0,1,0,1,1,1,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,1,1,1,1,1,1,0,1,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,1,0,1,0,1,1,1,0,1,1 },
new[] { 0,1,0,0,0,1,0,0,0,0,0,0,1,0,0,1,0,0,1,1,0,0,0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,0,1,1,1,1,1,0,0,1,1,1,0,1,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,1,0,0,0,1,1,0,1,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,1,1,1,0,1,0,1 },
new[] { 1,0,0,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,0,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,1,0,1,1,1,1,0,1,0,1 },
new[] { 1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,1,1,0,0,0,0,1,0,1,0,1,1,0,1,0,1,1,1,1,1,0,1,0,1,0,0,1,1,0,1,1,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,1,1,1,1,1,0,0,0,1,0,1,1,1,0,1,1,0,1,0,0,0,0,0,1,1,0,1,1 },
new[] { 0,0,0,0,1,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,1,1,0,0,0,0,1,0,1,1,0,1,1,1,1,0,1,1,1,1,0,1,0,1,0,1,1,1,0,1,1,0,0,1,0,1,0,0,1,1,1,0,1,1,0,0,0,1,0,1,0,0,1,0,1,1,1,0,1,0,0 },
new[] { 1,0,0,0,1,0,0,1,0,1,1,0,0,1,0,1,1,1,1,0,0,1,0,1,1,1,1,1,1,0,1,1,0,1,0,1,1,0,1,1,0,0,0,1,0,1,1,1,0,1,1,0,0,1,1,0,0,1,0,0,1,0,1,1,1,1,0,1,1,0,0,1,0,0,1,1,1,0,0,0,1,1,0,1,0,0,0,0,1,1,1,0,0,1,1,1,1,0,1,1 },
new[] { 0,0,0,0,0,1,1,0,0,1,1,0,0,1,1,0,0,0,1,1,1,1,0,0,0,0,1,0,1,0,0,0,0,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,1,0,0,1,0,0,1,0,0,0,1,0,1,1,1,1,1,0,1,1,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1,0,1,1,0,0,1,1,0,0,0 },
new[] { 1,0,1,0,0,1,0,0,0,1,1,0,0,0,0,1,1,0,1,1,1,1,0,0,0,0,1,0,1,1,1,0,0,1,0,0,0,0,0,1,1,0,1,1,1,0,1,0,0,1,1,1,1,1,0,1,1,1,0,0,0,1,1,1,1,0,0,1,1,0,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,0,0,1,0,1,1,0,0,1,1,1,1,1,0 },
new[] { 0,0,1,1,1,1,0,0,0,0,0,0,0,1,0,0,1,0,1,1,1,0,1,0,0,0,0,1,0,1,0,0,1,0,1,0,0,1,0,1,0,1,0,1,0,0,1,1,1,1,0,0,1,1,0,1,1,0,0,0,0,1,0,1,0,0,0,0,0,1,1,1,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,1,1,1,0,0,1,1,1,0,1,0,1 },
new[] { 0,1,1,1,0,1,1,1,0,1,1,1,1,1,0,1,0,0,0,1,1,1,0,1,1,1,0,0,1,0,1,0,1,0,0,0,1,1,1,1,0,1,1,1,0,1,1,0,1,1,1,0,0,0,0,0,1,0,0,1,0,0,0,0,1,1,1,0,0,1,1,0,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,0,1,0,1,1,0,1,0,1,0,0,1,1 },
new[] { 1,1,0,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,0,1,1,0,1,0,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,1,0,1,0,1,0,1,1,1,1,1,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,1,1,1,1,1,1,0,1,1,1,1,0,0,1,0 },
new[] { 0,0,1,1,1,1,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,1,0,0,1,1,0,1,0,0,1,1,0,0,0,0,0,1,0,0,1,0,1,1,1,1,1,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,1,1,0,0,1,1,1,0,1,0,1,1,0,1,0,1,1,0,0,0,0,0,1,0,1,0,0,0,0,0,1 },
new[] { 0,0,0,0,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,0,1,1,0,0,1,1,0,1,0,0,0,1,0,0,0,1,0,0,0,0,1,1,1,1,0,1,1,1,0,1,0,0,1,0,1,0,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1 },
new[] { 1,0,0,1,1,0,1,1,0,0,0,0,1,1,0,0,1,0,1,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,0,1,0,1,1,1,1,0,0,0,0,0,1,1,0,1,1,0,0,1,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,1,1,1,0,1,1,0,0,1,0,0,0,0,1,0,0,0,1,1,1,0,0,1,1,0,1,1,1,0 },
new[] { 0,1,1,0,1,0,0,1,1,1,0,0,0,1,0,0,1,1,1,1,0,0,1,1,0,1,1,0,0,0,1,0,1,1,1,1,0,0,0,1,1,1,0,1,0,1,1,1,0,0,1,1,1,0,0,1,1,0,0,1,1,1,0,1,0,1,1,0,0,1,0,1,1,1,0,1,0,1,0,1,0,0,0,0,1,0,1,1,1,0,0,0,0,1,0,0,0,1,0,1 },
new[] { 1,1,1,1,1,0,0,0,0,1,0,0,0,1,1,0,0,1,0,1,1,0,0,1,1,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,0,1,1,1,1,0,1,0,0,1,1,1,1,1,0,1,1,1,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,0,1,1,1,0,0,1,0,0,1,0,1,1,0,1,1,0,0,0,0,1,1,0,1,0,1,1 },
new[] { 0,0,0,1,1,1,1,0,0,1,1,1,1,1,1,1,1,0,0,0,1,1,0,1,1,1,1,1,0,1,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,1,0,1,1,0,0,0,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1,0,1,0,1,1,0,0,1,1,1,1,0,1,0,1,0,0,0,0,1,1,0,1,1,0,0,0,0,1 },
new[] { 1,1,1,0,0,1,0,1,0,1,0,0,0,0,1,0,0,0,1,0,1,1,1,1,0,0,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,0,1,1,0,0,1,1,0,0,1,1,1,0,0,1,0,1,0,1,1,1,1,0,1,1,1,0,0,0,0,1,1,1,0,0,1,0,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,1,0,1,1,1,0,0 },
new[] { 1,1,0,1,0,1,1,1,0,1,0,0,1,0,1,0,1,1,0,1,0,1,0,0,0,0,0,0,1,0,1,0,1,1,1,0,1,1,1,1,0,1,0,0,0,1,1,0,1,1,1,0,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,0,1,0,0,0,0,1,1,1,0,0,0,1,1,1,1,1,0,0,1,0,1,0,1,0 },
new[] { 0,0,1,1,0,1,1,0,1,1,1,1,0,0,0,1,0,1,0,1,1,0,1,1,0,1,1,1,1,0,0,0,1,1,1,1,1,0,1,1,0,0,0,1,0,0,1,1,1,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,1,0,0,0,0,1,0,1,1,1 },
new[] { 1,0,1,0,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,1,0,1,1,1,0,0,1,0,1,0,0,0,0,1,0,0,1,0,1,1,0,0,0,0,1,0,1,1,0,0,0,1,0,1,0,0,1,0,1,0,1,0,0,0,1,0,1,1,1,1,1,0,0,1,0,1,1,1,1,1,0,1,1,1,0,0,0,0,1,0,0,1,1,1,1,1,1,0,1,1 },
new[] { 0,0,1,1,0,1,1,0,0,1,1,1,1,0,0,0,1,1,0,1,1,1,0,1,1,0,1,1,0,0,0,1,1,1,1,0,1,1,1,1,1,0,1,0,0,0,1,0,1,0,0,1,1,1,0,0,1,0,1,1,0,0,1,0,1,0,1,1,1,0,0,1,0,0,1,0,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,0,1,1,0 },
new[] { 1,0,1,0,1,0,1,0,0,0,1,0,1,1,0,0,0,0,1,1,1,0,0,0,1,1,0,1,0,0,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,1,1,0,1,0,1,0,1,1,1,0,0,0,0,1,1,1,0,1,1,1,0,1,0,0,0 },
new[] { 1,1,0,0,1,0,0,1,1,1,1,0,1,1,1,1,0,0,0,0,1,0,0,1,1,0,0,1,1,1,0,0,1,0,0,1,0,0,1,1,1,0,0,1,1,1,1,0,0,0,1,1,1,0,0,1,0,1,0,1,1,0,1,0,0,0,0,0,1,1,0,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,0,0,1,0,1,1,0,1,1,1,1,1,0,1 },
new[] { 0,1,1,0,0,0,0,1,1,0,1,1,1,0,1,1,1,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,1,0,0,0,0,1,1,0,1,0,0,1,1,1,0,1,0,0,1,0,0,0,0,1,1,1,0,1,0,0,1,0,0,1,0,1,0,0,0,0,0,0 },
new[] { 0,1,0,1,1,1,0,1,1,0,1,1,0,1,1,1,0,1,0,0,1,0,0,1,1,1,1,0,0,1,0,1,1,1,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,1,1,1,1,0,1,0,1,0,0,0,0,1,0,1,1,1,0,0,1,1,0,0,1,1,0,1,1,1,1,0,0,1,1 },
new[] { 1,0,1,0,1,0,1,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,0,1,1,1,0,1,1,0,1,0,1,1,1,1,1,1,0,1,1,0,0,1,1,0,1,1,1,0,0,0,1,0,0,1,0,0,1,1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,0,1,0,0,1,1,1,1 },
new[] { 0,0,0,0,1,0,1,1,0,1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,0,1,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,1,1,0,1,0,0,1,1,1,1,1,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,1,1,1,0,1,0,1,1,0,0,0,0,1,1,0,1,1,1,1,1,1,0,0 },
new[] { 0,1,0,0,1,1,0,1,1,0,0,0,0,0,0,0,1,0,1,0,1,1,0,1,1,0,1,0,1,1,0,0,1,1,1,1,1,0,1,0,0,0,1,0,0,1,0,1,1,1,1,0,1,0,1,1,0,0,0,1,1,1,1,1,1,0,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,0,1,0,1 },
new[] { 1,0,0,0,0,0,0,1,0,0,1,0,1,0,0,1,0,0,1,0,0,1,0,1,0,1,1,1,0,1,1,0,1,1,1,1,1,1,0,1,1,1,0,0,1,1,0,0,1,1,1,0,0,0,1,0,1,1,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,1,1,0,0,1,0,1,0,1,1,1,0,0,0,1,0,0,1,0,1,1,0,1,1,1 },
new[] { 1,0,0,1,1,0,0,0,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,1,1,1,0,0,0,1,0,1,0,0,0,1,1,1,0,1,1,0,1,0,0,0,0,1,0,1,0,1,0,1,0,0,1,1,0,1,0,1,1,0,1,1,0,0,1,0,0,0,1,0,1,1,0,0,0,1,1,0,1,1,1,0,1,1,0,1,0 },
new[] { 1,0,1,0,1,0,0,0,1,0,0,0,0,1,1,0,0,1,1,1,1,1,0,1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,1,1,0,0,0,1,0,1,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,1,1,1,0,1,1,0,1,0,0,0,1,0,1,0,1,1,1,1,0,1,0,0,1,0,0,1,1,1,0,0,1,1 },
new[] { 1,0,0,1,0,1,1,1,0,0,0,1,0,1,0,0,1,1,0,1,0,1,1,0,1,1,0,0,1,0,1,0,0,0,0,1,1,1,0,0,1,0,0,1,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,0,1,1,0,0,1,1,1,0,0,0,1,1,0,0,0,0,0,1,1,0,0,0,0,1,1,1,0,0 },
new[] { 0,1,0,0,1,0,1,0,0,0,0,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,0,0,1,0,1,1,1,1,0,0,0,1,0,0,0,0,0,0,1,1,0,1,0,0,1,0,0,1,0,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,1,1,0,0,1,0,0,0,0,0,1,0,0,1,1,0,1,0,1,1,1,1,1 },
new[] { 1,1,0,1,0,0,1,0,1,0,1,0,1,0,1,1,1,0,0,0,1,1,1,0,1,1,1,0,0,0,0,1,0,1,0,1,1,0,1,1,0,1,1,1,0,1,0,0,1,1,1,0,0,0,0,0,1,1,1,1,1,1,0,1,0,1,1,1,0,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,1,1 },
new[] { 0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,1,1,0,0,1,1,1,0,0,1,0,0,1,0,1,1,0,0,1,0,1,0,0,0,1,1,1,1,1,1,1,0,1,1,1,0,0,0,1,1,1,1,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,1,0,0,0,1,1,0,1,0,0 },
new[] { 1,1,1,1,0,1,1,0,1,0,1,0,1,1,1,0,0,0,0,1,1,0,1,0,0,1,1,0,1,0,1,1,1,1,1,0,0,0,1,0,1,1,1,1,1,1,0,0,1,0,0,0,0,1,1,1,1,0,1,0,0,1,1,0,0,0,0,1,0,1,0,0,0,0,0,0,1,1,0,1,0,0,1,0,0,0,0,1,0,1,1,0,0,1,1,1,0,1,1,0 },
new[] { 0,0,0,1,0,1,1,0,1,1,1,1,0,1,1,1,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,0,1,0,1,1,0,0,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,0,0,1,1,0,1,1,0,0,0,1,1,0,0,1,0,1,1,0,1,0,1,1,1,0,0,1,0,1,0,0,0,1,0,1,1 },
new[] { 0,1,0,0,1,0,0,1,0,1,1,1,0,1,1,1,1,0,0,0,1,1,0,0,1,0,1,0,0,1,1,1,0,1,1,1,0,0,0,1,1,1,0,1,0,1,1,1,0,1,0,0,1,1,0,0,1,0,0,1,0,0,1,1,0,1,0,1,0,1,0,1,0,0,1,1,0,0,1,1,0,1,1,1,0,1,1,1,1,0,0,1,0,1,1,1,0,1,1,1 },
new[] { 1,1,1,1,1,1,0,0,1,1,0,0,0,0,0,1,1,1,1,0,1,0,1,1,0,0,0,1,1,1,1,0,1,0,1,0,0,1,1,0,1,0,1,1,0,0,0,0,1,1,1,1,1,0,0,1,0,1,1,0,1,1,1,0,1,1,0,0,0,0,1,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,0,1,1,0,1,0,1,0,1,1,0,1,0,0 },
new[] { 1,1,1,0,0,1,1,1,1,0,1,1,1,1,0,0,0,1,1,1,0,1,1,1,0,1,1,0,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,1,1,1,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,0,1,1,1,1,0,0,0,0,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,1,0,0 },
new[] { 1,1,0,1,0,0,1,1,0,0,0,0,0,0,1,0,0,1,0,1,1,1,0,1,0,0,1,0,1,1,1,0,1,0,0,1,0,0,0,1,0,1,1,1,0,0,1,0,0,0,0,0,1,1,1,1,1,0,0,0,1,0,1,0,0,1,0,0,0,1,1,0,1,0,1,0,1,0,1,0,0,1,1,1,0,1,1,0,0,0,0,1,0,0,1,1,0,0,1,0 },
new[] { 0,1,0,1,1,0,1,0,0,0,1,1,0,0,1,0,1,0,0,0,1,0,1,1,0,1,0,0,0,1,1,0,0,1,1,0,0,1,0,0,1,0,1,1,1,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,1,1,0,1,0,1,0,0,1,1,0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,1,1,0,0,1,0,1,1,1,1,1,0,1,1,1 },
new[] { 0,1,1,0,1,1,0,1,1,0,0,1,1,0,0,0,0,1,0,0,1,0,0,0,0,1,1,0,0,1,0,0,1,0,0,1,0,1,0,0,0,1,0,1,0,0,0,1,1,1,1,1,1,0,1,0,0,1,0,0,0,1,0,1,0,0,0,0,1,0,1,1,0,1,0,0,1,1,0,1,1,0,0,1,1,0,1,0,0,0,0,0,1,1,1,0,1,0,1,0 },
new[] { 1,0,1,0,0,1,0,0,0,1,1,1,0,0,1,1,0,0,1,1,1,1,1,1,0,0,1,1,0,0,1,0,0,1,0,1,0,0,1,0,1,1,1,0,0,1,1,0,1,0,0,1,1,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,1,1,0,1,1,0,0,1,1,1,0,1,0,0,0,0 },
new[] { 1,0,0,1,1,0,1,1,1,0,1,0,1,0,1,1,1,1,0,0,0,1,0,1,0,0,0,1,1,1,1,1,0,1,1,0,0,1,1,0,1,1,0,1,1,0,0,1,1,1,0,0,0,1,0,0,0,0,1,0,1,1,1,0,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,0,1,1,0,0,0,0,1,0,1,1,0,1,1,1,1,0,0,0,0,1 },
};

            var result = NumSubmatrixSumTarget(matrix2, 0);
            var result2 = NumSubmatrixSumTarget(matrix2, 0);
            Console.WriteLine($"result = {result}");
        }
    }
}
