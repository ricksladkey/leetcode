using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode2
{
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carry = 0;
            var root = new ListNode(0);
            var current = root;
            while (l1 != null || l2 != null)
            {
                var val1 = 0;
                if (l1 != null)
                {
                    val1 = l1.val;
                    l1 = l1.next;
                }
                var val2 = 0;
                if (l2 != null)
                {
                    val2 = l2.val;
                    l2 = l2.next;
                }
                var sum = carry + val1 + val2;
                var digit = sum % 10;
                carry = sum / 10;
                current = current.next = new ListNode(digit);
            }
            if (carry != 0) current.next = new ListNode(carry);
            return root.next;
        }
    }
}
