/*(Medium)
Design and implement a data structure for Least Recently Used (LRU) cache. 
It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, 
otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. 
When the cache reached its capacity, 
it should invalidate the least recently used item before inserting a new item.

The cache is initialized with a positive capacity.

Follow up:
Could you do both operations in O(1) time complexity?

Example:

LRUCache cache = new LRUCache( 2 );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
*/

using System.Collections.Generic;

public class LRUCache {
    public class LRUNode 
    {
        public int key;
        public int val;
        public LRUNode prev;
        public LRUNode next;

        public LRUNode(int key, int val) 
        {
            this.key = key;
            this.val = val;
            this.prev = this;
            this.next = this;
        }
    }

    private LRUNode head = new LRUNode(0, 0);
    private Dictionary<int, LRUNode> valDict = new Dictionary<int, LRUNode>();
    private int capacity;
    private int size;

    public void DealWithNode(LRUNode node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
        node.prev = head;
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
    }

    public void AddNewNode(LRUNode node)
    {
        node.prev = head;
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
    }

    public LRUNode GetLastNode()
    {
        LRUNode node = head.prev;
        node.prev.next = node.next;
        node.next.prev = node.prev;
        return node;
    }

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.size = 0;
    }

    public int Get(int key) 
    {
        if (valDict.ContainsKey(key))
        {
            LRUNode node = valDict[key];
            DealWithNode(node);
            return node.val;
        }

        return -1;
    }

    public void Put(int key, int value) 
    {
        if (valDict.ContainsKey(key))
        {
            LRUNode node = valDict[key];
            node.val = value;
            DealWithNode(node);
            valDict[key] = node;
        }
        else
        {
            if (size < capacity)
            {
                size++;
                LRUNode newNode = new LRUNode(key, value);
                AddNewNode(newNode);
                valDict.Add(key, newNode);
            }
            else
            {
                LRUNode node = GetLastNode();
                if (node == head)
                {
                    return;
                }

                valDict.Remove(node.key);
                node.key = key;
                node.val = value;
                DealWithNode(node);
                valDict[key] = node;
            }
        }
    }
}

// 248  ms,  94.03%
// 48.4 MB,  99.36%
