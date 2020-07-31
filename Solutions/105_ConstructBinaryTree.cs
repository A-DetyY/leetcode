/*(Medium)
Given preorder and inorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.

For example, given

preorder = [3,9,20,15,7]
inorder = [9,3,15,20,7]
Return the following binary tree:

    3
   / \
  9  20
    /  \
   15   7
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int FindValue(int[] inorder, int val)
    {
        int pos = -1;
        for(int i=0; i<inorder.Length; i++)
        {
            if(val == inorder[i])
            {
                pos = i;
                break;
            }
        }

        return pos;
    }
    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        if(preorder == null || preorder.Length == 0)
        {
            return null;
        }

        int nodeLength = preorder.Length;
        TreeNode root = new TreeNode(preorder[0]);
        int pos = FindValue(inorder, preorder[0]);
        if(pos == -1)
        {
            return root;
        }

        int leftTreeLength = pos - 0;
        int rightTreeLength = preorder.Length - pos - 1;
        int[] leftPreorder = null;
        int[] leftInorder = null;
        int[] rightPreorder = null;
        int[] rightInorder = null;

        if(leftTreeLength > 0)
        {
            leftPreorder = new int[leftTreeLength];
            leftInorder = new int[leftTreeLength];
            for(int i=0; i<leftTreeLength; i++)
            {
                leftPreorder[i] = preorder[i+1];
                leftInorder[i] = inorder[i];
            }
            root.left = BuildTree(leftPreorder, leftInorder);
        }
        else
        {
            root.left = null;
        }

        if(rightTreeLength > 0)
        {
            rightPreorder = new int[rightTreeLength];
            rightInorder = new int[rightTreeLength];
            for(int i=0; i<rightTreeLength; i++)
            {
                rightPreorder[i] = preorder[pos+1+i];
                rightInorder[i] = inorder[pos+1+i];
            }
            root.right = BuildTree(rightPreorder, rightInorder);
        }
        else
        {
            root.right = null;
        }

        return root;
    }
}

// 156  ms,  30.00%
// 66.9 MB,  24.32%
