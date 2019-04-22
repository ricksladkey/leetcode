using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode1020
{
    public class Solution {
        public class UnionFind
        {
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
        private int rows;
        private int cols;
        public int NumEnclaves(int[][] grid) {
            rows = grid.Length;
            if (rows == 0) return 0;
            cols = grid[0].Length;

            // Create Union-Find data structure with one
            // more node representing the edge of the grid.
            var n = rows * cols;
            var uf = new UnionFind(n + 1);

            // Connect all lands to neighbors and possibly the edge.
            for (var row = 0; row < rows; row++) {
                for (var col = 0; col < cols; col++) {
                    var square = grid[row][col];
                    if (square == 1) {

                        // Check the four neighbors for lands and connect them.
                        if (row > 0 && grid[row - 1][col] == 1) uf.Union(getid(row, col), getid(row - 1, col));
                        if (col > 0 && grid[row][col - 1] == 1) uf.Union(getid(row, col), getid(row, col - 1));
                        if (row < rows - 1 && grid[row + 1][col] == 1) uf.Union(getid(row, col), getid(row + 1, col));
                        if (col < cols - 1 && grid[row][col + 1] == 1) uf.Union(getid(row, col), getid(row, col + 1));

                        // Connect border cells with the edge.
                        if (row == 0 || col == 0 || row == rows - 1 || col == cols - 1) uf.Union(getid(row, col), n);
                    }
                }
            }

            // Sum all lands not connected to the edge.
            var cnt = 0;
            for (var row = 0; row < rows; row++) {
                for (var col = 0; col < cols; col++) {
                    var square = grid[row][col];
                    if (square == 1 && !uf.Find(getid(row, col), n)) cnt += 1;
                }
            }
            return cnt;
        }
        private int getid(int row, int col) {
            return row * cols + col;
        }
    }
}
