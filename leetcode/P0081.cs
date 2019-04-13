using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0081
{
    public class Solution
    {
        public bool Search(int[] nums, int target)
        {
            var n = nums.Length;
            if (n == 0) return false;
            var m = 0;
            for (var i = 1; i < n; i++) {
                if (nums[i - 1] > nums[i]) {
                    m = i;
                    break;
                }
            }
            var lo = 0;
            var hi = n - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var index = (mid + m) % n;
                var num = nums[index];
                if (target < num) hi = mid - 1;
                else if (target > num) lo = mid + 1;
                else return true;
            }
            return false;
        }
    }

}
