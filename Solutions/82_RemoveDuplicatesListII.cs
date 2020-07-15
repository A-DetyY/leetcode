/*(Medium)
Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

Return the linked list sorted as well.
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if(head==null || head.next==null)
        {
            return head;
        }

        ListNode newHead = new ListNode(-1, head);
        ListNode tempNode = newHead;
        while(tempNode.next != null)
        {
            ListNode curNode = tempNode.next;
            while(curNode.next != null && curNode.next.val == curNode.val)
            {
                curNode = curNode.next;
            }
            if(curNode != tempNode.next)
            {
                tempNode.next = curNode.next;
            }
            else
            {
                tempNode = tempNode.next;
            }
        }

        return newHead.next;
    }
}

// 136  ms,  21.46%
// 25.7 MB,  60.00%
