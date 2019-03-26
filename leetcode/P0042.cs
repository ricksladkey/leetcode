using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode0042
{
    public class Solution
    {
        public int Trap(int[] heights)
        {
            var n = heights.Length;
            if (n == 0) return 0;
            var tot = 0;
            var stack = new Stack<int>();
            stack.Push(0);
            for (var i = 1; i < n; i++)
            {
                var height = heights[i];
                if (height <= heights[i - 1])
                {
                    if (height == heights[i - 1]) stack.Pop();
                    stack.Push(i);
                    continue;
                }
                var water = heights[stack.Pop()];
                while (stack.Count > 0 && heights[stack.Peek()] <= height)
                {
                    var prev = stack.Pop();
                    tot += (heights[prev] - water) * (i - prev - 1);
                    water = heights[prev];
                }
                if (stack.Count > 0)
                {
                    var prev = stack.Peek();
                    tot += (height - water) * (i - prev - 1);
                }
                stack.Push(i);
            }
            return tot;
        }

        private int BruteTrap(int[] height)
        {
            var n = height.Length;
            if (n == 0) return 0;
            var tot = 0;
            var max = height.Max();
            while (max > 0)
            {
                var next = height.Where(h => h > 0).Min();
                var prev = -1;
                for (var i = 0; i < n; i++)
                {
                    if (height[i] > 0)
                    {
                        if (prev != -1) tot += next * (i - prev - 1);
                        prev = i;
                    }
                }
                for (var i = 0; i < n; i++) height[i] -= next;
                max -= next;
            }
            return tot;
        }
        public void Main()
        {
            var heights = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var result = Trap(heights);
            var reference = BruteTrap(heights);
            Console.WriteLine($"result = {result}, reference = {reference}");
        }
    }
}
