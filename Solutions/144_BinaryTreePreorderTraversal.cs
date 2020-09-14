/*(Medium)
Given a binary tree, return the preorder traversal of its nodes' values.

Example:

Input: [1,null,2,3]
   1
    \
     2
    /
   3

Output: [1,2,3]
Follow up: Recursive solution is trivial, could you do it iteratively?
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
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        IList<int> resList = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode p = root;
        while (p != null || stack.Count > 0)
        {
            while (p != null)
            {
                resList.Add(p.val);
                stack.Push(p.right);
                p = p.left;
            }

            p = stack.Pop();
        }

        return resList;
    }
}

// 236  ms,  90.91%
// 29.5 MB,  91.95%
