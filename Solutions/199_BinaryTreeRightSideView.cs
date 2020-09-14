/*(Medium)
Given a binary tree, imagine yourself standing on the right side of it, 
return the values of the nodes you can see ordered from top to bottom.

Example:

Input: [1,2,3,null,5,null,4]
Output: [1, 3, 4]
Explanation:

   1            <---
 /   \
2     3         <---
 \     \
  5     4       <---
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
    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }
        IList<int> rightList = new List<int>();
        Queue<TreeNode> nodeQuene = new Queue<TreeNode>();
        nodeQuene.Enqueue(root);
        while (nodeQuene.Count != 0)
        {
            TreeNode node = null;
            int count = nodeQuene.Count;
            for (int i = 0; i < count; i++)
            {
                node = nodeQuene.Dequeue();
                if (node.left != null)
                {
                    nodeQuene.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    nodeQuene.Enqueue(node.right);
                }
            }
            rightList.Add(node.val);
        }
        return rightList;
    }
}

// 236 ms,  91.86%
// 30.2MB,  83.45%
