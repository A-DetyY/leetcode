/*(Medium)
You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.
*/

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = new ListNode(0);
        int addToNext = 0;
        ListNode temp = head;

        while (true)
        {
            if (l1 == null && l2 == null && addToNext == 0)
            {
                break;
            }
            
            int leftValue = (l1 != null) ? l1.val : 0;
            int rightValue = (l2 != null) ? l2.val : 0;

            int value = leftValue + rightValue + addToNext;
            int val = value % 10;
            addToNext = value / 10;

            ListNode newNode = new ListNode(0);
            newNode.val = val;
            temp.next = newNode;
            temp = temp.next;
        
            l1 = (l1 != null) ? l1.next : l1;
            l2 = (l2 != null) ? l2.next : l2;
        }

        return head.next;
    }
}

// 100  ms,  95.72%
// 28.8 MB,  14.10%
