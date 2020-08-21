/*(Medium)
Given a binary tree

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
Populate each next pointer to point to its next right node. 
If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

 

Follow up:

You may only use constant extra space.
Recursive approach is fine, you may assume implicit stack space does not count as extra space for this problem.
 

Example 1:



Input: root = [1,2,3,4,5,null,7]
Output: [1,#,2,3,#,4,5,7,#]
Explanation: Given the above binary tree (Figure A), 
your function should populate each next pointer to point to its next right node, just like in Figure B. 
The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.
 

Constraints:

The number of nodes in the given tree is less than 6000.
-100 <= node.val <= 100
*/

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) 
    {
        if(root == null)
        {
            return root;
        }

        Node nextNost = root;
        while(true)
        {
            if(nextNost.left == null && nextNost.right == null && nextNost.next == null)
            {
                break;
            }
            Node head =nextNost;
            while(head != null)
            {
                Node nextNode = null;
                Node tempNode = head;
                while(tempNode.next != null)
                {
                    if(tempNode.next.left != null || tempNode.next.right != null)
                    {
                        break;
                    }
                    tempNode = tempNode.next;
                } 
                if(tempNode.next != null)
                {
                    if(tempNode.next.left != null)
                    {
                        nextNode = tempNode.next.left;
                    }
                    else if(tempNode.next.right != null)
                    {
                        nextNode = tempNode.next.right;
                    }
                }
                
                if(head.left != null)
                {
                    if(head.right != null)
                    {
                        head.left.next = head.right;
                    }
                    else
                    {
                        head.left.next = nextNode;
                    }
                }
                if(head.right != null)
                {
                    head.right.next = nextNode;
                }

                head = head.next;
            }
            if(nextNost.left != null)
            {
                nextNost = nextNost.left;
            }
            else if(nextNost.right!= null)
            {
                nextNost = nextNost.right;
            }
            else
            {
                nextNost = nextNost.next;
            }
        }

        return root;
    }
}

// 92  ms,  98.34%
// 26.9MB,  54.55%
