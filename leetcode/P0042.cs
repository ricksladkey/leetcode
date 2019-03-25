using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0042
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            var n = nums.Length;

            // Zero out non-positive numbers and negate positive ones.
            for (var i = 0; i < n; i++)
            {
                if (nums[i] >= 1 && nums[i] <= n) nums[i] = -nums[i];
                else nums[i] = 0;
            }

            // Do an in-place radix sort for the numbers 1 to n discarding duplicates.
            for (var i = 0; i < n; i++)
            {
                while (nums[i] < 0)
                {
                    var num = nums[i];
                    var index = -num - 1;
                    if (nums[index] > 0) nums[i] = 0;
                    else
                    {
                        nums[i] = nums[index];
                        nums[index] = -num;
                    }
                }
            }

            // Return first unoccupied slot.
            for (var i = 0; i < n; i++) if (nums[i] == 0) return i + 1;
            return n + 1;
        }
    }
}
