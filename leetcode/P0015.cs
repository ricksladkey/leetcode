using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode0015
{
    public class Solution
    {
        private class Triplet : List<int>, IEquatable<Triplet>
        {
            public Triplet(int a, int b, int c)
            {
                this.Add(a); this.Add(b); this.Add(c);
            }
            public override int GetHashCode()
            {
                return this[0] ^ (this[1] << 8) ^ (this[2] << 16);
            }
            public bool Equals(Triplet other)
            {
                return this[0] == other[0] && this[1] == other[1] && this[2] == other[2];
            }
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length < 3) return result;
            var found = new HashSet<Triplet>();
            var n = nums.OrderBy(x => x).ToArray();
            for (var i = 0; i < n.Length - 2; i++)
            {
                for (var j = i + 1; j < n.Length - 1; j++)
                {
                    var sum = n[i] + n[j];
                    var k = Array.BinarySearch(n, j + 1, n.Length - (j + 1), -sum);
                    if (k >= 0)
                    {
                        var triplet = new Triplet(n[i], n[j], n[k]);
                        if (!found.Contains(triplet))
                        {
                            found.Add(triplet);
                            result.Add(triplet);
                        }
                    }
                }
            }
            return result;
        }
    }
}
