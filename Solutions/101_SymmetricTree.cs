/*(Easy)
Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
 

But the following [1,2,2,null,3,null,3] is not:

    1
   / \
  2   2
   \   \
   3    3
 

Follow up: Solve it both recursively and iteratively.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {

    public bool IsSymmetric(TreeNode node1, TreeNode node2)
    {
        if(node1 == null && node2 == null)
        {
            return true;
        }
        else if(node1 != null && node2 != null)
        {
            if(node1.val != node2.val)
            {
                return false;
            }
            return IsSymmetric(node1.left, node2.right) && IsSymmetric(node1.right, node2.left);
        }
        else
        {
            return false;
        }
    }
    public bool IsSymmetric(TreeNode root) 
    {
        return IsSymmetric(root, root);
    }
}

// 128  ms,  71.93%
// 25   MB,  97.32%
