/*(Hard)
You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

Merge all the linked-lists into one sorted linked-list and return it.

 

Example 1:

Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6
Example 2:

Input: lists = []
Output: []
Example 3:

Input: lists = [[]]
Output: []
 

Constraints:

k == lists.length
0 <= k <= 10^4
0 <= lists[i].length <= 500
-10^4 <= lists[i][j] <= 10^4
lists[i] is sorted in ascending order.
The sum of lists[i].length won't exceed 10^4.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
            return null;
        ListNode headNode = new ListNode(0);
        ListNode curNode = headNode;
        int k = lists.Length;
        while (true)
        {
            int idx = -1;
            for (int i = 0; i < k; i++)
            {
                if (lists[i] != null)
                {
                    if (idx == -1)
                    {
                        idx = i;
                        continue;
                    }

                    if (lists[idx].val > lists[i].val)
                    {
                        idx = i;
                    }
                }
            }

            if (idx != -1)
            {
                curNode.next = lists[idx];
                curNode = curNode.next;
                lists[idx] = lists[idx].next;
            }
            else
            {
                break;
            }
        }

        return headNode.next;
    }
}

// 468 ms,  18.74%
// 29.5MB,   5.01%
