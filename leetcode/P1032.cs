using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1032
{
#if true
    public class StreamChecker {
        public class Trie<TKey, TValue> {
            private class Node {
                public TValue value;
                public Dictionary<TKey, Node> map = new Dictionary<TKey, Node>();
            }
            private Node root = new Node();
            public bool TryFindPrefix(IEnumerable<TKey> s, Func<TValue, bool> where) {
                var node = root;
                foreach (var c in s) {
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else return false;
                    if (where(node.value)) return true;
                }
                return where(node.value);
            }
            public bool TryFind(IEnumerable<TKey> s, out TValue value) {
                var node = root;
                value = default(TValue);
                foreach (var c in s) {
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else return false;
                }
                value = node.value;
                return true;
            }
            public void Insert(IEnumerable<TKey> s, TValue value) {
                var node = root;
                foreach (var c in s) {
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else {
                        var newNode = new Node();
                        node.map.Add(c, newNode);
                        node = newNode;
                    }
                }
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
            return trie.TryFindPrefix(stack, value => value);
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
