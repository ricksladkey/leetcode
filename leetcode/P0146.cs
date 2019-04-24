using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode0146
{
    public class LRUCache {
        private int n;
        private Dictionary<int, int> slots;
        private int[] keys;
        private int[] values;
        private int[] prev;
        private int[] next;
        private int first;
        private int used;
        public LRUCache(int capacity) {
            n = capacity;
            slots = new Dictionary<int, int>();
            keys = new int[n];
            values = new int[n];
            prev = new int[n];
            next = new int[n];
            for (var slot = 0; slot < n; slot++) {
                keys[slot] = -1;
                values[slot] = -1;
                prev[slot] = (slot + n - 1) % n;
                next[slot] = (slot + 1) % n;
            }
            first = 0;
            used = 0;
        }
        
        public int Get(int key) {
            if (slots.TryGetValue(key, out int slot)) {
                var value = values[slot];
                Put(key, value);
                return value;
            }
            return -1;
        }
        
        public void Put(int key, int value) {
            int slot;
            if (!slots.TryGetValue(key, out slot)) {
                if (used < n) slot = used++;
                else {
                    slot = prev[first];
                    slots.Remove(keys[slot]);
                }
                slots.Add(key, slot);
                keys[slot] = key;
            }
            values[slot] = value;
            if (slot == first) return;
            next[prev[slot]] = next[slot];
            prev[next[slot]] = prev[slot];
            prev[slot] = prev[first];
            next[slot] = first;
            next[prev[first]] = slot;
            prev[first] = slot;
            first = slot;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
