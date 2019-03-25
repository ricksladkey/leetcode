using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0004
{
    public class Solution
    {
        bool _debug = false;
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var n = nums1.Length + nums2.Length;
            if (n % 2 == 0)
            {
                var select1 = Select(nums1, nums2, n / 2 - 1);
                var select2 = Select(nums1, nums2, n / 2);
                return (select1 + select2) / 2.0;
            }
            else return Select(nums1, nums2, n / 2);
        }
        int Select(int[] nums1, int[] nums2, int k)
        {
            var lo1 = 0;
            var hi1 = nums1.Length;
            var lo2 = 0;
            var hi2 = nums2.Length;
            while (lo1 != hi1 && lo2 != hi2)
            {
                if (_debug) Console.WriteLine("{0} / {1}",
                    ArrayString(nums1, lo1, hi1), ArrayString(nums2, lo2, hi2));
                var mid1 = lo1 + (hi1 - lo1) / 2;
                var mid2 = lo2 + (hi2 - lo2) / 2;
                var limit = mid1 + mid2;
                if (nums1[mid1] > nums2[mid2])
                {
                    if (k < limit) hi1 = mid1;
                    else if (k > limit) lo2 = mid2 + 1;
                    else { hi1 = mid1; lo2 = mid2; }
                }
                else
                {
                    if (k < limit) hi2 = mid2;
                    else if (k > limit) lo1 = mid1 + 1;
                    else { hi2 = mid2; lo1 = mid1; }
                }
            }
            if (_debug) Console.WriteLine("{0} / {1}",
                ArrayString(nums1, lo1, hi1), ArrayString(nums2, lo2, hi2));
            return lo1 != hi1 ? nums1[k - lo2] : nums2[k - lo1];
        }
        private string ArrayString(int[] array, int lo, int hi)
        {
            var builder = new StringBuilder();
            builder.Append("[");
            for (var i = lo; i < hi; i++)
            {
                builder.Append(array[i]);
                builder.Append(", ");
            }
            builder.Append("]");
            return builder.ToString();
        }
        public void Main()
        {
            Console.WriteLine("{0}", FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));
            Console.WriteLine("{0}", FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }));
            Console.WriteLine("{0}", FindMedianSortedArrays(new[] { 1, 3, 5, 7 }, new[] { 2, 4, 6, 8 }));
        }
    }
}
