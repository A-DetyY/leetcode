/*(Medium)
Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

An example is the root-to-leaf path 1->2->3 which represents the number 123.

Find the total sum of all root-to-leaf numbers.

Note: A leaf is a node with no children.
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

    public int allSum = 0;

    public void AddSumNumbers(TreeNode root, int val)
    {
        if(root.left == null && root.right == null)
        {
            allSum += val*10 + root.val;
            return;
        }
        val = val * 10 + root.val;
        if(root.left != null)
        {
            AddSumNumbers(root.left, val);
        }
        if(root.right != null)
        {
            AddSumNumbers(root.right, val);
        }
    }

    public int SumNumbers(TreeNode root) 
    {
        allSum = 0;
        if(root != null)
        {
            AddSumNumbers(root, 0);
        }
        return allSum;
    }
}

// 88  ms,  94.05%
// 24.2MB,  92.96%
