using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode1261
{
    public class Solution
    {
        public IList<string> CommonChars(string[] A)
        {
            var accum = null as Dictionary<char, int>;
            foreach (var s in A)
            {
                var count = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    if (!count.ContainsKey(c)) count[c] = 0;
                    count[c] += 1;
                }
                if (accum == null)
                {
                    accum = count;
                }
                else
                {
                    foreach (var key in accum.Keys.ToList())
                    {
                        if (!count.ContainsKey(key))
                        {
                            accum.Remove(key);
                        }
                        else
                        {
                            accum[key] = Math.Min(accum[key], count[key]);
                        }
                    }
                }
            }
            var list = new List<string>();
            foreach (var key in accum.Keys)
            {
                for (var i = 0; i < accum[key]; i++)
                {
                    list.Add(key.ToString());
                }
            }
            return list;
        }
    }
}
