/*(Medium)
Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]
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

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        IList<IList<int>> resList = new List<IList<int>>();
        if(root != null)
        {
            queue.Enqueue(root);
        }
        while(queue.Count > 0)
        {
            List<int> tempList = new List<int>();
            Queue<TreeNode> orderQueue = new Queue<TreeNode>();
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                tempList.Add(node.val);
                if(node.left != null)
                {
                    orderQueue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    orderQueue.Enqueue(node.right);
                }
            }
            resList.Add(tempList);
            queue = orderQueue;
        }

        return resList;
    }
}

// 236  ms,  98.10%
// 31.2 MB,  23.60%
