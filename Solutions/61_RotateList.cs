/*(Medium)
Given the head of a linked list, rotate the list to the right by k places.
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
    public ListNode RotateRight(ListNode head, int k) {
        int nodeLength = 0;
        ListNode temp = head;
        while (temp != null)
        {
            nodeLength++;
            temp = temp.next;
        }

        if (nodeLength == 0 || k % nodeLength == 0)
            return head;
        int step = nodeLength - (k % nodeLength);
        ListNode preNode = head;
        for (int i = 0; i < step - 1; i++)
        {
            preNode = preNode.next;
        }

        ListNode curNode = preNode.next;
        preNode.next = null;
        temp = curNode;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = head;
        
        return curNode;
    }
}

// 112 ms,  55.83%
// 25.1MB,  85.00%
