/*(Hard)
Given a non-empty binary tree, find the maximum path sum.

For this problem, 
a path is defined as any sequence of nodes from some starting node to any node 
in the tree along the parent-child connections. 
The path must contain at least one node and does not need to go through the root.

Example 1:

Input: [1,2,3]

       1
      / \
     2   3

Output: 6
Example 2:

Input: [-10,9,20,null,null,15,7]

   -10
   / \
  9  20
    /  \
   15   7

Output: 42
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
    public int[] CalPathSum(TreeNode root)
    {
        if (root == null)
        {
            return new int[2] {0, int.MinValue};
        }

        int[] left = CalPathSum(root.left);
        int[] right = CalPathSum(root.right);
        int[] calVal = new int[2];

        int maxNoTurnVal = (left[0] > right[0]) ? left[0] : right[0];
        calVal[0] = (maxNoTurnVal > 0) ? maxNoTurnVal + root.val : root.val;

        int val = Math.Max(left[0] + root.val, right[0] + root.val);
        val = Math.Max(val, left[0] + right[0] + root.val);
        val = Math.Max(val, left[1]);
        val = Math.Max(val, right[1]);
        calVal[1] = val;
        return calVal;
    }

    public int MaxPathSum(TreeNode root)
    {
        int[] calVal = CalPathSum(root);
        return Math.Max(calVal[0], calVal[1]);
    }
}

// 108  ms,  78.59%
// 31.6 MB,  7.97 %
