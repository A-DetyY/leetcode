/*(Hard)
Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item. For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.

Note that the number of times an item is used is the number of calls to the get and put functions for that item since it was inserted. This number is set to zero when the item is removed.

 

Follow up:
Could you do both operations in O(1) time complexity?

 

Example:

LFUCache cache = new LFUCache( 2 );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.get(3);       // returns 3.
cache.put(4, 4);    // evicts key 1.
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
*/

using System.Collections.Generic;

public class LRUNode
{
    public int key;
    public int val;
    public LRUNode prev;
    public LRUNode next;
    public LRUNode head;
    public LFUNode freq;

    public LRUNode(int key, int val, LFUNode freq)
    {
        this.key = key;
        this.val = val;
        this.prev = this;
        this.next = this;
        this.freq = freq;
    }

    public void Access()
    {
        LFUNode oriLFUNode = this.freq;
        LFUNode myLFUNode;
        if (this.freq.prev.val != this.freq.val + 1)
        {
            myLFUNode = this.freq.InsertBefore(this.freq.val + 1);
        }
        else
        {
            myLFUNode = this.freq.prev;
        }
        this.prev.next = this.next;
        this.next.prev = this.prev;
        oriLFUNode.CheckNeedDelete();

        LRUNode nodeHead = myLFUNode.head;
        this.next = nodeHead.next;
        this.prev = nodeHead;
        this.freq = myLFUNode;
        nodeHead.next.prev = this;
        nodeHead.next = this;
    }

    public void DeleteSelf(LRUNode head, LFUNode lfuNode)
    {
        this.prev.next = this.next;
        this.next.prev = this.prev;
        this.freq.CheckNeedDelete();
        this.key = 0;
        this.val = 0;
        this.prev = head.prev;
        this.next = head.next;
        this.freq = lfuNode;
        head.next.prev = this;
        head.prev = this;
    }
}

public class LFUNode
{
    public int val;
    public LFUNode prev;
    public LFUNode next;
    public LRUNode head;

    public LFUNode(int val)
    {
        this.val = val;
        this.prev = this;
        this.next = this;
        this.head = new LRUNode(0, 0, this);
    }

    public LFUNode InsertBefore(int val)
    {
        LFUNode newNode = new LFUNode(val);
        newNode.next = this;
        newNode.prev = this.prev;
        this.prev.next = newNode;
        this.prev = newNode;
        return newNode;
    }

    public void CheckNeedDelete()
    {
        Console.WriteLine("this.val = {0}", this.val);
        Console.WriteLine("this.head.next.val = {0}", this.head.next.val);
        Console.WriteLine("this.head.val = {0}", this.head.val);
        if (this.val != 0 && this.head.next == this.head)
        {
            this.prev.next = this.next;
            this.next.prev = this.prev;
            this.val = 0;
            this.prev = null;
            this.next = null;
            this.head = null;
        }
    }
}

public class LFUCache
{
    Dictionary<int, LRUNode> nodeDict;
    LFUNode myLFUHead;
    int capacity;
    int size;

    public LFUCache(int capacity)
    {
        this.nodeDict = new Dictionary<int, LRUNode>();
        this.myLFUHead = new LFUNode(0);
        this.capacity = capacity;
        this.size = 0;
    }

    public int Get(int key)
    {
        if (!nodeDict.ContainsKey(key))
        {
            return -1;
        }

        LRUNode node = nodeDict[key];
        node.Access();
        return node.val;
    }

    public void Put(int key, int value)
    {
        if (nodeDict.ContainsKey(key))
        {
            LRUNode node = nodeDict[key];
            node.Access();
            node.val = value;
        }
        else
        {
            if (size < capacity)
            {
                size++;
                LRUNode newLRUNode = new LRUNode(key, value, myLFUHead);
                newLRUNode.Access();
                nodeDict.Add(key, newLRUNode);
            }
            else
            {
                LFUNode lastLFUNode = myLFUHead.prev;
                if (lastLFUNode.head.prev == lastLFUNode.head)
                {
                    return;
                }
                LRUNode lastNode = lastLFUNode.head.prev;
                nodeDict.Remove(lastNode.key);
                lastNode.DeleteSelf(myLFUHead.head, myLFUHead);
                lastNode.key = key;
                lastNode.val = value;
                lastNode.Access();
                nodeDict.Add(key, lastNode);
            }
        }
    }

    public void Show()
    {
        LFUNode tempNode = myLFUHead.next;
        while(tempNode.val != 0)
        {
            Console.Write("{0}   ", tempNode.val);
            LRUNode childNode = tempNode.head.next;
            while(childNode != tempNode.head)
            {
                Console.Write("{0}   ", childNode.val);
                childNode = childNode.next;
            }
            Console.WriteLine();
            tempNode = tempNode.next;
        }
    }
}

// 244  ms,  99.05%
// 48.8 MB,  99.05%
