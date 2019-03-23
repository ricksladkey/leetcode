using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode0032
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            var result = 0;
            var start = new int[s.Length + 1];
            var depth = 0;
            var i = 0;
            while (i < s.Length)
            {
                var c = s[i];
                if (depth == 0 && c == ')') { i += 1; continue; }
                if (c == '(') start[depth++] = i++;
                else if (c == ')')
                {
                    result = Math.Max(result, ++i - start[--depth]);
                    if (i < s.Length && s[i] == '(') { depth += 1; i += 1; }
                }
            }
            return result;
        }
        public void Main()
        {
            Console.WriteLine(LongestValidParentheses(")()())"));
        }
    }
}
