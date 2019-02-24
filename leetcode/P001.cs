using System.Linq;

namespace leetcode1
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var sorted = Enumerable.Range(0, nums.Length).OrderBy(index => nums[index]).ToArray();
            for (var i = 0; i < nums.Length; i++)
            {
                if (BinarySearch(nums, sorted, target - nums[i], out int j) && j != i)
                {
                    return new[] { i, j };
                }
            }
            return new[] { -1, -1 };
        }

        private bool BinarySearch(int[] nums, int[] sorted, int value, out int index)
        {
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var other = nums[sorted[mid]];
                if (other < value)
                {
                    lo = mid + 1;
                }
                else if (other > value)
                {
                    hi = mid - 1;
                }
                else
                {
                    index = sorted[mid];
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
