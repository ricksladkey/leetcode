using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1036
{
    public class Solution {
        public class UnionFind {
            private int[] id;
            private int[] sz;
            public UnionFind(int n) {
                id = new int[n];
                sz = new int[n];
                for (var i = 0; i < n; i++) id[i] = i;
            }
            public int Root(int i) {
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
        private int rows;
        private int cols;
        private Dictionary<int, int> rowMap, colMap;
        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {
            for (var index = 0; index <= 1; index++) {
                var max = 0;
                var ids =
                    blocked.Select(pair => pair[index])
                    .Concat(new [] { 0, source[index], target[index], 999999 })
                    .OrderBy(id => id)
                    .Distinct()
                    .ToArray();
                var map = new Dictionary<int, int>();
                var next = 0;
                for (var i = 0; i < ids.Length; i++) {
                    if (i != 0) next += Math.Min(2, ids[i] - ids[i - 1]);
                    map.Add(ids[i], next);
                    max = Math.Max(max, next);
                }
                if (index == 0) { rows = max + 1; rowMap = map; }
                if (index == 1) { cols = max + 1; colMap = map; }
            }
            var grid = new bool[rows, cols];
            foreach (var pair in blocked) grid[rowMap[pair[0]], colMap[pair[1]]] = true;
            var uf = new UnionFind(rows * cols);
            for (var row = 0; row < rows; row++) {
                for (var col = 0; col < cols; col++) {
                    if (!grid[row, col]) {
                        if (row > 0 && !grid[row - 1, col])
                            uf.Union(GetId(row, col), GetId(row - 1, col));
                        if (col > 0 && !grid[row, col - 1])
                            uf.Union(GetId(row, col), GetId(row, col - 1));
                        if (row < rows - 1 && !grid[row + 1, col])
                            uf.Union(GetId(row, col), GetId(row + 1, col));
                        if (col < cols - 1 && !grid[row, col + 1])
                            uf.Union(GetId(row, col), GetId(row, col + 1));
                    }
                }
            }
            return uf.Find(GetMappedId(source), GetMappedId(target));
        }
        private int GetId(int row, int col) {
            return row * cols + col;
        }
        private int GetMappedId(int[] pair) {
            return rowMap[pair[0]] * cols + colMap[pair[1]];
        }
    }
}
