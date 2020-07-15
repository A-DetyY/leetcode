/*(Medium)
Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
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

 using System.Collections;
public class Solution {
    public bool IsValidBST(TreeNode root) 
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    public bool IsValidBST(TreeNode root, long min, long max)
    {
        if(root == null)
        {
            return true;
        }
        if(root.val <= min || root.val >= max)
        {
            return false;
        }
        return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
    }
}

// 100  ms,  67.17%
// 26.2 MB,  64.08%
