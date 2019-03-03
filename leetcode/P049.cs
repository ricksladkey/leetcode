using System.Collections.Generic;

namespace leetcode49
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var v = new bool[s.Length + 1];
            v[0] = true;
            for (var i = 1; i <= s.Length; i++)
            {
                foreach (var w in wordDict)
                {
                    var j = i - w.Length;
                    if (j >= 0 && v[j] && s.Substring(j, w.Length) == w) v[i] = true;
                }

            }
            return v[s.Length];
        }
    }
}
