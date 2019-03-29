using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode0045
{
    public class Solution
    {
        private int[] nums;
        private int n;
        private HashSet<(int, int)> set;
        public int Jump(int[] nums)
        {
            // Intuition: Remove the last element and partition the
            // remainder into k non-empty subsequences each of whose
            // length is bounded by its first element.
            var n = nums.Length;
            if (n == 1) return 0;
            if (n == 2) return 1;
            n -= 1;
            this.nums = nums.Take(n).ToArray();
            this.n = n;
            set = new HashSet<(int, int)>();
            var min = Math.Max(1, this.nums.TakeWhile(num => num == 1).Count());
            for (var k = min; k < n; k++) if (Partition(k, 0)) return k;
            return n;
        }
        private bool Partition(int k, int start)
        {
            var pair = (k, start);
            if (set.Contains((pair))) return false;
            //Console.WriteLine($"k = {k}, start = {start}");
            if (k == 1)
            {
                if (nums[start] >= n - start) return true;
                return false;
            }
            var max = Math.Min(nums[start], n - start - k + 1);
            for (var p = max; p >= 1; p--) if (Partition(k - 1, start + p)) return true;
            set.Add(pair);
            return false;
        }
        public void Main()
        {
            var nums = Enumerable.Repeat(1, 2500).ToArray();
            var result = Jump(nums);
            Console.WriteLine(result);
        }
    }
}
