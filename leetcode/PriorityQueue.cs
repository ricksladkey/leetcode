using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
	public class PriorityQueue<Item> where Item : IComparable<Item> {
		private struct Key : IComparable<Key> {
            public Item Item { get; }
            public uint Seq { get; }
            public Key(Item item, uint seq) { Item = item; Seq = seq;  }
            public int CompareTo(Key other) {
                var result = Item.CompareTo(other.Item);
                if (result != 0) return result;
                return Seq < other.Seq ? -1 : (Seq > other.Seq ? 1 : 0);
            }
		}
		private SortedDictionary<Key, bool> dict = new SortedDictionary<Key, bool>();
		private uint seq = 0;
        public int Count => dict.Count;
        void Enqueue(Item item) => dict.Add(new Key(item, seq++), true);
        Item Dequeue(Item item) { var min = dict.First().Key; dict.Remove(min); return min.Item; }
	}
}
