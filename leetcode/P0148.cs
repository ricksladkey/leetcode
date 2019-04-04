using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace leetcode0148
{
    [DebuggerDisplay("{ToString()}")]
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public override string ToString()
        {
            var b = new StringBuilder();
            b.Append("[");
            var rest = this;
            while (rest != null) {
                b.Append(rest.val);
                if (rest.next != null) b.Append(", ");
                rest = rest.next;
            }
            b.Append("]");
            return b.ToString();
        }
    }

    public class Solution {
        public ListNode SortList(ListNode head) {
            if (head == null) return null;
            var n = 0;
            for (var current = head; current != null; current = current.next) n += 1;
            var dummy1 = new ListNode(-1);
            dummy1.next = head;
            var dummy2 = new ListNode(-1);
            for (var m = 1; m < n; m *= 2) {
                var prev1 = dummy1;
                while (prev1.next != null) {
                    
                    // Grab up to the next m items into list1.
                    var list1 = prev1.next;
                    var prev2 = list1;
                    for (var i = 0; i < m - 1 && prev2 != null; i++) prev2 = prev2.next;

                    if (prev2 == null) break;
                    
                    // Grab up to the next m items into list2.
                    var list2 = prev2.next;
                    var prev3 = list2;
                    for (var i = 0; i < m - 1 && prev3 != null; i++) prev3 = prev3.next;

                    // Save the remaining items, if any.
                    var list3 = prev3 != null ? prev3.next : null;

                    // Terminate list1 and list2.
                    prev2.next = null;
                    if (prev3 != null) prev3.next = null;

                    // Merge the two lists, terminating with remaining items.
                    (prev1.next, prev1) = Merge(dummy2, list1, list2, list3);
                }
            }
            return dummy1.next;
        }
        private (ListNode, ListNode) Merge(ListNode dummy, ListNode list1, ListNode list2, ListNode list3) {
            var prev = dummy;
            while (list1 != null || list2 != null) {
                var first = false;
                if (list1 == null) first = false;
                else if (list2 == null) first = true;
                else first = list1.val <= list2.val;
                if (first) {
                    prev.next = list1;
                    list1 = list1.next;
                }
                else {
                    prev.next = list2;
                    list2 = list2.next;
                }
                prev = prev.next;
            }
            prev.next = list3;
            return (dummy.next, prev);
        }
        private ListNode MakeList(IEnumerable<int> items)
        {
            var dummy = new ListNode(-1);
            var prev = dummy;
            foreach (var item in items)
            {
                prev.next = new ListNode(item);
                prev = prev.next;
            }
            return dummy.next;
        }
        public void Main()
        {
            var result1 = SortList(MakeList(new[] { 4, 2, 1, 3 }));
            var result2 = SortList(MakeList(new[] { 4, 2, 3 }));
            var result3 = SortList(MakeList(new[] { 5, 4, 1, 2, 4, 6, 7, 8, 11, 9 }));
            Console.WriteLine("done!");
        }
    }
}
