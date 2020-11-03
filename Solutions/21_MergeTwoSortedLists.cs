/*(Easy)
Merge two sorted linked lists and return it as a new sorted list. 
The new list should be made by splicing together the nodes of the first two lists.
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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        if (l1 == null && l2 == null)
            return null;
        if (l1 == null || l2 == null)
            return (l1 == null) ? l2 : l1;
        
        ListNode headNode = new ListNode(0);
        ListNode curNode = headNode;
        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                curNode.next = l1;
                curNode = curNode.next;
                l1 = l1.next;
            }
            else
            {
                curNode.next = l2;
                curNode = curNode.next;
                l2 = l2.next;
            }
        }

        if (l1 != null)
            curNode.next = l1;
        if (l2 != null)
            curNode.next = l2;
        return headNode.next;
    }
}

// 88  ms,  92.63%
// 26.3MB,  28.80%
