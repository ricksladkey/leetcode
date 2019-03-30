using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode0037
{
    public class Solution
    {
        private bool debug = false;
        private List<List<(int, int)>> groups = new List<List<(int, int)>>();
        private Dictionary<int, int> map = new Dictionary<int, int>();
        public Solution()
        {
            MakeGroups();
            MakeMap();
        }
        public void SolveSudoku(char[][] b)
        {
            var board = ParseBoard(b);
            if (!Solve(board)) return;
            if (debug)
            {
                if (!Solved(board)) Console.WriteLine("board was not solved");
                if (!CheckBoard(board)) Console.WriteLine("board is not valid");
            }
            CopyToBoard(board, b);
        }
        private bool Solve(int[,] board)
        {
            if (!CheckBoard(board)) return false;
            var solved = Solved(board);
            while (!solved)
            {
                while (DeduceNumbers(board));
                solved = Solved(board);
                if (!solved)
                {
                    var (row, col) = FindFewest(board);
                    if (debug)
                    {
                        DisplayBoard(board);
                        Console.WriteLine($"checking ({row}, {col})");
                    }
                    var num = board[row, col];
                    for (var val = 1; val <= 9; val++)
                    {
                        if ((num & (1 << val)) == 0)
                        {
                            if (debug) Console.WriteLine($"trying {val}");
                            var trial = board.Clone() as int[,];
                            trial[row, col] = 1 << val;
                            if (Solve(trial))
                            {
                                CopyToBoard(trial, board);
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            return true;
        }
        private (int, int) FindFewest(int[,] board)
        {
            var fewest = 9;
            var (r, c) = (-1, -1);
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var num = board[row, col];
                    if ((num & 1) == 0) continue;
                    var cnt = 0;
                    for (var val = 1; val <= 9; val++)
                        if ((num & (1 << val)) == 0) cnt += 1;
                    if (cnt < fewest)
                    {
                        r = row;
                        c = col;
                        fewest = cnt;
                    }
                }
            }
            return (r, c);
        }
        private bool Solved(int[,] board)
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var num = board[row, col];
                    if ((num & 1) != 0) return false;
                }
            }
            return true;
        }
        private bool DeduceNumbers(int[,] board)
        {
            CheckBoard(board);
            var cnt = 0;
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var num = board[row, col];
                    if ((num & 1) == 0) continue;
                    var bits = ~num & ((1 << 10) - 2);
                    if (bits != 0 && (bits & (bits - 1)) == 0)
                    {
                        board[row, col] = bits;
                        cnt += 1;
                    }
                }
            }
            return cnt > 0;
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
        private void CopyToBoard(int[,] board, char[][] b)
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var num = board[row, col];
                    var val = (num & 1) != 0 ? '.' : map[num] + '0';
                    b[row][col] = (char)val;
                }
            }
        }
        private void CopyToBoard(int[,] board1, int[,] board2)
        {
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    board2[row, col] = board1[row, col];
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
            for (var num = 1; num <= 9; num++) map.Add(1 << num, num);
        }
        private void DisplayBoard(char[][] b)
        {
            var display = string.Join(Environment.NewLine, b.Select(row => new string(row)));
            Console.WriteLine(display);
        }
        private void DisplayBoard(int[,] board)
        {
            var b = Enumerable.Repeat(0, 9).Select(n => new char[9]).ToArray();
            CopyToBoard(board, b);
            var display = string.Join(Environment.NewLine, b.Select(row => new string(row)));
            Console.WriteLine(display);
        }
        public void Main()
        {
            var input = new[] {
                new[] { ".", ".", "9", "7", "4", "8", ".", ".", "." },
                new[] { "7", ".", ".", ".", ".", ".", ".", ".", "." },
                new[] { ".", "2", ".", "1", ".", "9", ".", ".", "." },
                new[] { ".", ".", "7", ".", ".", ".", "2", "4", "." },
                new[] { ".", "6", "4", ".", "1", ".", "5", "9", "." },
                new[] { ".", "9", "8", ".", ".", ".", "3", ".", "." },
                new[] { ".", ".", ".", "8", ".", "3", ".", "2", "." },
                new[] { ".", ".", ".", ".", ".", ".", ".", ".", "6" },
                new[] { ".", ".", ".", "2", "7", "5", "9", ".", "." }
            };
            var b = input.Select(row => row.Select(s => s[0]).ToArray()).ToArray();
            SolveSudoku(b);
            DisplayBoard(b);
        }
    }

#if false
Test cases:

[["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
[[".",".","9","7","4","8",".",".","."],["7",".",".",".",".",".",".",".","."],[".","2",".","1",".","9",".",".","."],[".",".","7",".",".",".","2","4","."],[".","6","4",".","1",".","5","9","."],[".","9","8",".",".",".","3",".","."],[".",".",".","8",".","3",".","2","."],[".",".",".",".",".",".",".",".","6"],[".",".",".","2","7","5","9",".","."]]
#endif
}
