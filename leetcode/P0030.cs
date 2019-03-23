using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode0030
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var n = words.Length;
            var result = new List<int>();
            if (n == 0) return result;
            var m = words[0].Length;
            var len = m * n;
            var bag = new Dictionary<string, int>();
            foreach (var word in words) { if (!bag.ContainsKey(word)) bag.Add(word, 0); bag[word] += 1; }
            for (var i = 0; i < s.Length - len + 1; i++)
            {
                var set = new Dictionary<string, int>(bag);
                var found = true;
                for (var j = 0; j < n; j++)
                {
                    var current = s.Substring(i + j * m, m);
                    var match = (string)null;
                    foreach (var word in set.Keys) if (current == word) { match = word; break; }
                    if (match == null) { found = false; break; }
                    set[match] -= 1;
                    if (set[match] == 0) set.Remove(match);
                }
                if (found) result.Add(i);
            }
            return result;
        }
    }
}
