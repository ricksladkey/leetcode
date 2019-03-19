using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
	public class PriorityQueue1<Item> where Item : IComparable<Item> {
		private struct Key : IComparable<Key> {
            public Item Item { get; }
            public uint Seq { get; }
            public Key(Item item, uint seq) { Item = item; Seq = seq; }
            public int CompareTo(Key other) {
                var result = Item.CompareTo(other.Item);
                if (result != 0) return result;
                return Seq < other.Seq ? -1 : (Seq > other.Seq ? 1 : 0);
            }
		}
		private readonly SortedDictionary<Key, bool> dict = new SortedDictionary<Key, bool>();
		private uint seq = 0;
        public int Count => dict.Count;
        void Enqueue(Item item) => dict.Add(new Key(item, seq++), true);
        Item Dequeue() { var min = dict.First().Key; dict.Remove(min); return min.Item; }
	}
	public class PriorityQueue2<Item> where Item : IComparable<Item> {
		private readonly SortedDictionary<Item, Stack<Item>> dict =
            new SortedDictionary<Item, Stack<Item>>();
        public int Count { get; private set; }
        void Enqueue(Item item) {
            Count += 1;
            if (dict.TryGetValue(item, out Stack<Item> stack)) {
                if (stack == null) stack = dict[item] = new Stack<Item>();
                stack.Push(item);
            }
            else dict[item] = null;
        }
        Item Dequeue() {
            Count -= 1;
            var pair = dict.First();
            if (pair.Value != null && pair.Value.Count != 0) return pair.Value.Pop();
            else { dict.Remove(pair.Key); return pair.Key; }
        }
	}
}
