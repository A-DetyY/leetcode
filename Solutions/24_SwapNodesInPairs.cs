/*(Medium)
Given a linked list, swap every two adjacent nodes and return its head.

You may not modify the values in the list's nodes. Only nodes itself may be changed.
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
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null)
            return head;
        
        ListNode preNode = new ListNode(0);
        preNode.next = head;
        if (head.next != null)
        {
            ListNode node = SwapPairs(head.next.next);
            ListNode headNext = head.next;
            preNode.next = headNext;
            headNext.next = head;
            head.next = node;
        }

        return preNode.next;
    }
}

// 92  ms,  55.56%
// 24.6MB,  44.75%
