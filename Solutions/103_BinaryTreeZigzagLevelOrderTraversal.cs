/*(Medium)
Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:
[
  [3],
  [20,9],
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
    {
        IList<IList<int>> resList = new List<IList<int>>();
        IList<TreeNode> orderList = new List<TreeNode>();
        if(root != null)
        {
            orderList.Add(root);
        }
        bool needReverse = false;
        while(orderList.Count > 0)
        {
             List<int> tempList = new List<int>();
             IList<TreeNode> tempNodeList = new List<TreeNode>();
             for(int i = 0; i < orderList.Count; i++)
             {
                 TreeNode node = orderList[i];
                 tempList.Add(node.val);
                 if(node.left != null)
                 {
                     tempNodeList.Add(node.left);
                 }
                 if(node.right != null)
                 {
                     tempNodeList.Add(node.right);
                 }
             }
             if(needReverse)
             {
                 tempList.Reverse();
             }
             needReverse = !needReverse;
             resList.Add(tempList);
             orderList = tempNodeList;
        }

        return resList;
    }
}

// 248  ms,  76.21%
// 30.6 MB,  26.00%
