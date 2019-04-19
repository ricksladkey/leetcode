using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode0095
{
    public class Solution {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        private List<List<TreeNode>> trees;
        public IList<TreeNode> GenerateTrees(int n) {
            if (n == 0) return new List<TreeNode>();
            trees = new List<List<TreeNode>>();
            for (var i = 0; i < n; i++) trees.Add(Generate(i));
            var result = Generate(n);
            foreach (var node in result) Assign(node, 1);
            return result;
        }
        private List<TreeNode> Generate(int n) {
            var result = new List<TreeNode>();
            if (n == 0) {
                result.Add(null);
                return result;
            }
            if (n == 1) {
                result.Add(new TreeNode(-1));
                return result;
            }
            n -= 1;
            for (var i = 0; i <= n; i++) {
                foreach (var left in trees[i]) {
                    foreach (var right in trees[n - i]) {
                        var node = new TreeNode(-1);
                        node.left = Copy(left);
                        node.right = Copy(right);
                        result.Add(node);
                    }
                }
            }
            return result;
        }
        private TreeNode Copy(TreeNode node) {
            if (node == null) return null;
            var copy = new TreeNode(node.val);
            copy.left = Copy(node.left);
            copy.right = Copy(node.right);
            return copy;
        }
        private int Assign(TreeNode node, int n) {
            if (node == null) return n;
            n = Assign(node.left, n);
            node.val = n;
            n += 1;
            n = Assign(node.right, n);
            return n;
        }
    }
}
