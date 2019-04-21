using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode1032
{
    public class StreamChecker {
        private class Trie {
            private class Node {
                public bool value;
                public Dictionary<char, Node> map = new Dictionary<char, Node>();
            }
            private Node root = new Node();
            public bool FindPrefix(IEnumerable<char> s) {
                var node = root;
                foreach (var c in s) {
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else return false;
                    if (node.value) return true;
                }
                return node.value;
            }
            public void Insert(IEnumerable<char> s) {
                var node = root;
                foreach (var c in s) {
                    if (node.map.TryGetValue(c, out Node child)) node = child;
                    else {
                        var newNode = new Node();
                        node.map.Add(c, newNode);
                        node = newNode;
                    }
                }
                node.value = true;
            }
        }
        private Trie trie = new Trie();
        private Stack<char> stack = new Stack<char>();
        public StreamChecker(string[] words) {
            foreach (var word in words) trie.Insert(word.Reverse());
        }
        public bool Query(char letter) {
            stack.Push(letter);
            return trie.FindPrefix(stack);
        }
        public static void Go() {
            var streamChecker = new StreamChecker(new[] { "cd", "f", "kl" });
            foreach (var c in Enumerable.Range('a', 26)) {
                var result = streamChecker.Query((char)c);
                Console.WriteLine($"c = '{(char)c}', result = {result}");
            }
        }
    }
}
