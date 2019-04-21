using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1032
{
    public class StreamChecker {
        private HashSet<string> words;
        private int[] lengths;
        private string[] recents;
        public StreamChecker(string[] words) {
            this.words = words.ToHashSet();
            lengths = words.Select(word => word.Length).OrderBy(length => length).Distinct().ToArray();
            recents = new string[lengths.Length];
        }
        
        public bool Query(char letter) {
            var found = false;
            for (var i = 0; i < recents.Length; i++) {
                var length = lengths[i];
                var recent = recents[i];
                if (recent == null) recent = letter.ToString();
                else if (recent.Length < length) recent += letter.ToString();
                else recent = recent.Substring(1) + letter.ToString();
                recents[i] = recent;
                if (recent.Length == length) found = found || words.Contains(recent);
            }
             return found;
        }
    }
}
