using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode1032
{
#if true
    public class StreamChecker {
        public class Trie<TKey, TValue> {
            private class Node {
                public bool hasValue = false;
                public TValue value = default(TValue);
                public Dictionary<TKey, Node> map = new Dictionary<TKey, Node>();
            }
            private Node root = new Node();
            public bool TryFind(IEnumerable<TKey> s, bool prefix, out TValue value) {
                value = default(TValue);
                var node = root;
                foreach (var c in s) {
                    if (prefix && node.hasValue) { value = node.value; return true; }
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else return false;
                }
                if (node.hasValue) { value = node.value; return true; }
                return false;
            }
            public void Insert(IEnumerable<TKey> s, TValue value) {
                var node = root;
                foreach (var c in s) {
                    if (!node.map.ContainsKey(c)) node.map[c] = new Node();
                    node = node.map[c];
                }
                node.hasValue = true;
                node.value = value;
            }
        }
        private Trie<char, bool> trie = new Trie<char, bool>();
        private Stack<char> stack = new Stack<char>();
        public StreamChecker(string[] words) {
            foreach (var word in words) trie.Insert(word.Reverse(), true);
        }
        public bool Query(char letter) {
            stack.Push(letter);
            return trie.TryFind(stack, true, out bool value);
        }
        public static void Go() {
            var streamChecker = new StreamChecker(new[] { "cd", "f", "kl" });
            foreach (var c in Enumerable.Range('a', 26).Select(letter => (char)letter)) {
                var result = streamChecker.Query(c);
                Console.WriteLine($"c = '{c}', result = {result}");
            }
        }
    }
#endif
}
