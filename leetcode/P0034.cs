using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0034
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var beg = Rank(nums, target);
            var end = Rank(nums, target + 1);
            if (beg == end) return new[] { -1, -1 };
            else return new[] { beg, end - 1 };
        }
        private int Rank(int[] nums, int val)
        {
            var lo = 0;
            var hi = nums.Length;
            while (lo < hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (nums[mid] < val) lo = mid + 1;
                else hi = mid;
            }
            return lo;
        }
    }
}
