using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0037
{
    public class Solution
    {
        private List<List<(int, int)>> groups;
        private Dictionary<int, int> map;
        public void SolveSudoku(char[][] board)
        {
            var b = ParseBoard(board);
            groups = new List<List<(int, int)>>();
            MakeGroups();
            MakeMap();
            var solving = true;
            while (solving)
            {
                CheckBoard(b);
                var cnt = 0;
                for (var row = 0; row < 9; row++)
                {
                    for (var col = 0; col < 9; col++)
                    {
                        var num = b[row, col];
                        if ((num & 1) == 0) continue;
                        var bits = ~num & ((1 << 10) - 2);
                        if ((bits & (bits - 1)) == 0)
                        {
                            b[row, col] = bits;
                            cnt += 1;
                        }
                    }
                }
                if (cnt == 0) solving = false;
            }
            CopyToBoard(b, board);
        }
        private bool CheckBoard(int[,] board)
        {
            foreach (var group in groups) if (!CheckGroup(board, group)) return false;
            return true;
        }
        private bool CheckGroup(int[,] board, List<(int, int)> group)
        {
            var seen = 0;
            for (var i = 0; i < 9; i++)
            {
                var (row, col) = group[i];
                var num = board[row, col];
                if ((num & 1) != 0) continue;
                if ((seen & num) != 0) return false;
                seen |= num;
            }
            for (var i = 0; i < 9; i++)
            {
                var (row, col) = group[i];
                var num = board[row, col];
                if ((num & 1) != 0) board[row, col] |= seen;
            }
            return true;
        }
        private int[,] ParseBoard(char[][] board)
        {
            var b = new int[9, 9];
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var square = board[row][col];
                    var val = square == '.' ? 1 : (1 << (square - '0'));
                    b[row, col] = val;
                }
            }
            return b;
        }
        private void CopyToBoard(int[,] b, char[][] board)
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var num = b[row, col];
                    var val = (num & 1) != 0 ? '.' : map[num] + '0';
                    board[row][col] = (char)val;
                }
            }
        }
        private void MakeGroups()
        {
            for (var row = 0; row < 9; row++)
            {
                var group = new List<(int, int)>();
                for (var col = 0; col < 9; col++) group.Add((row, col));
                groups.Add(group);
            }
            for (var col = 0; col < 9; col++)
            {
                var group = new List<(int, int)>();
                for (var row = 0; row < 9; row++) group.Add((row, col));
                groups.Add(group);
            }
            for (var row1 = 0; row1 < 9; row1 += 3)
            {
                for (var col1 = 0; col1 < 9; col1 += 3)
                {
                    var group = new List<(int, int)>();
                    for (var row = row1; row < row1 + 3; row++)
                    {
                        for (var col = col1; col < col1 + 3; col++) group.Add((row, col));
                    }
                    groups.Add(group);
                }
            }
        }
        private void MakeMap()
        {
            map = new Dictionary<int, int>();
            for (var num = 1; num <= 9; num++) map.Add(1 << num, num);
        }
    }
}
