/*(Hard)
Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

k is a positive integer and is less than or equal to the length of the linked list. 
If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.

Follow up:

Could you solve the problem in O(1) extra memory space?
You may not alter the values in the list's nodes, only nodes itself may be changed.
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
    public ListNode ReverseKGroup(ListNode head, int k) 
    {
        ListNode hair = new ListNode(0);
        hair.next = head;
        ListNode pre = hair;
        while (head != null)
        {
            ListNode tail = pre;
            for (int i = 0; i < k; i++)
            {
                tail = tail.next;
                if (tail == null)
                {
                    return hair.next;
                }
            }

            ListNode next = tail.next;
            ListNode[] reverse = MyReverse(head, tail);
            head = reverse[0];
            tail = reverse[1];
            pre.next = head;
            tail.next = next;
            pre = tail;
            head = tail.next;
        }

        return hair.next;
    }

    public ListNode[] MyReverse(ListNode head, ListNode tail)
    {
        ListNode prev = tail.next;
        ListNode p = head;
        while (prev != tail)
        {
            ListNode next = p.next;
            p.next = prev;
            prev = p;
            p = next;
        }

        return new ListNode[] {tail, head};
    }
}

// 96  ms,  75.90%
// 26.7MB,  60.39%
