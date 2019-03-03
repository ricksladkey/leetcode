using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace leetcode1262
{
    public class Solution
    {
        public bool IsValid(string S)
        {
            if (S == "") return false;
            while (true)
            {
                if (S == "")
                {
                    return true;
                }
                else if (S.Contains("abc"))
                {
                    S = S.Replace("abc", "");
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
