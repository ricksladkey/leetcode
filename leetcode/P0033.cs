using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0033
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            var n = nums.Length;
            if (n == 0) return -1;
            var m = 0;
            if (n > 1 && nums[0] > nums[n - 1])
            {
                var lo = 1;
                var hi = nums.Length - 1;
                while (lo < hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    if (nums[lo - 1] < nums[mid]) lo = mid + 1;
                    if (nums[mid] < nums[hi]) hi = mid;
                }
                m = lo;
            }
            {
                var lo = 0;
                var hi = n - 1;
                while (lo <= hi)
                {
                    var mid = lo + (hi - lo) / 2;
                    var index = (mid + m) % n;
                    var num = nums[index];
                    if (target < num) hi = mid - 1;
                    else if (target > num) lo = mid + 1;
                    else return index;
                }
            }
            return -1;
        }
        public void Main()
        {
            //Console.WriteLine(Search(new[] { 4,5,6,7,0,1,2 }, 0));
            //Console.WriteLine(Search(new[] { 4,5,6,7,0,1,2 }, 3));
            //Console.WriteLine(Search(new[] { 1,3 }, 1));
            Console.WriteLine(Search(new[] { 3,1 }, 1));
        }
    }
}
