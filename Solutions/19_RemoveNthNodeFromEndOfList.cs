/*(Medium)
Given the head of a linked list, remove the nth node from the end of the list and return its head.

Follow up: Could you do this in one pass?
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        ListNode preHead = head;
        ListNode forHead = head;
        for (int i = 0; i < n; i++)
        {
            forHead = forHead.next;
        }
        
        if (forHead == null)
        {
            return preHead.next;
        }
        while (forHead.next != null)
        {
            forHead = forHead.next;
            preHead = preHead.next;
        }
        preHead.next = preHead.next.next;

		return head;
    }
}

// 88  ms,  90.37%
// 25.6MB,  11.54%
