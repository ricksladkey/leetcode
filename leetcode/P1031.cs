using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode1031
{
    public class Solution {
        private int[] id;
        private int[] sz;
        private int rows;
        private int cols;
        public int NumEnclaves(int[][] grid) {
            rows = grid.Length;
            if (rows == 0) return 0;
            cols = grid[0].Length;
            
            // Create Union-Find data structure with one
            // more node representing the edge of the grid.
            var n = rows * cols;
            id = new int[n + 1];
            sz = new int[n + 1];
            for (var i = 0; i <= n; i++) id[i] = i;
            
            // Connect all lands to neighbors and possibly the edge.
            for (var row = 0; row < rows; row++) {
                for (var col = 0; col < cols; col++) {
                    var square = grid[row][col];
                    if (square == 1) {
                    
                        // Check the four neighbors for lands and connect them.
                        if (row > 0 && grid[row - 1][col] == 1) union(getid(row, col), getid(row - 1, col));
                        if (col > 0 && grid[row][col - 1] == 1) union(getid(row, col), getid(row, col - 1));
                        if (row < rows - 1 && grid[row + 1][col] == 1) union(getid(row, col), getid(row + 1, col));
                        if (col < cols - 1 && grid[row][col + 1] == 1) union(getid(row, col), getid(row, col + 1));
                        
                        // Connect border cells with the edge.
                        if (row == 0 || col == 0 || row == rows - 1 || col == cols - 1) union(getid(row, col), n);
                    }
                }
            }
            
            // Sum all lands not connected to the edge.
            var cnt = 0;
            for (var row = 0; row < rows; row++) {
                for (var col = 0; col < cols; col++) {
                    var square = grid[row][col];
                    if (square == 1 && !find(getid(row, col), n)) cnt += 1;
                }
            }
            return cnt;
        }
        private int getid(int row, int col) {
            return row * cols + col;
        }
        private int root(int i) {
            while (i != id[i]) {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }
        private bool find(int p, int q) {
            return root(p) == root(q);
        }
        private void union(int p, int q) {
            int i = root(p);
            int j = root(q);
            if (i == j) return;
            if (sz[i] < sz[j]) { id[i] = j; sz[j] += sz[i]; }
            else { id[j] = i; sz[i] += sz[j]; }     }
    }
}
