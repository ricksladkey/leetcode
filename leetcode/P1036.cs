using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode1036
{
    public class Solution {

        private int rows, cols;
        private Dictionary<int, int> rowMap, colMap;

        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {

            // Compress consecutive blank rows and columns.
            (rows, rowMap) = GetMap(blocked, source, target, 0);
            (cols, colMap) = GetMap(blocked, source, target, 1);

            // Create a grid from the compressed data.
            var grid = new bool[rows, cols];
            foreach (var pair in blocked) grid[rowMap[pair[0]], colMap[pair[1]]] = true;

            // Connect unblocked squares to each other.
            var uf = new UnionFind(rows * cols);
            var deltas = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            for (var row = 0; row < rows; row++) for (var col = 0; col < cols; col++) {
                var id = GetId(row, col);
                if (!grid[row, col]) foreach (var (dr, dc) in deltas)
                {
                    var (r, c) = (row + dr, col + dc);
                    if (r >= 0 && r < rows && c >= 0 && c < cols && !grid[r, c])
                        uf.Union(id, GetId(r, c));
                }
            }

            // Check whether the source is connected to the target.
            return uf.Find(GetMappedId(source), GetMappedId(target));
        }

        private (int, Dictionary<int, int>) GetMap(int[][] blocked, int[] source, int[] target, int index) {
            var map = new Dictionary<int, int>();
            var ids = blocked.Select(pair => pair[index])
                .Concat(new [] { 0, source[index], target[index], 999999 })
                .OrderBy(id => id).Distinct().ToArray();
            var next = 0;
            for (var i = 0; i < ids.Length; i++) {
                if (i > 0) next += Math.Min(2, ids[i] - ids[i - 1]);
                map.Add(ids[i], next);
            }
            return (next + 1, map);
        }
        private int GetId(int row, int col) {
            return row * cols + col;
        }
        private int GetMappedId(int[] pair) {
            return GetId(rowMap[pair[0]], colMap[pair[1]]);
        }

        // Union-Find algorithm
        public class UnionFind {
            private int[] id;
            private int[] sz;
            public UnionFind(int n) {
                id = new int[n];
                sz = new int[n];
                for (var i = 0; i < n; i++) id[i] = i;
            }
            private int Root(int i) {
                while (i != id[i]) {
                    id[i] = id[id[i]];
                    i = id[i];
                }
                return i;
            }
            public bool Find(int p, int q) {
                return Root(p) == Root(q);
            }
            public void Union(int p, int q) {
                int i = Root(p);
                int j = Root(q);
                if (i == j) return;
                if (sz[i] < sz[j]) { id[i] = j; sz[j] += sz[i]; }
                else { id[j] = i; sz[i] += sz[j]; }
            }
        }
    }
}
