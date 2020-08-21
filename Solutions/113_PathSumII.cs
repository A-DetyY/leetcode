/*(Medium)
Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

Note: A leaf is a node with no children.

Example:

Given the below binary tree and sum = 22,

      5
     / \
    4   8
   /   / \
  11  13  4
 /  \    / \
7    2  5   1
Return:

[
   [5,4,11,2],
   [5,8,4,5]
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
 
public class Solution {
    public void AddPathList(TreeNode root, int val, IList<int> tempList, IList<IList<int>> resList)
    {
        if(root == null)
        {
            return;
        }
        if(root.left == null && root.right == null)
        {
            if(root.val == val)
            {
                IList<int> copyList = new List<int>(tempList);
                copyList.Add(root.val);
                resList.Add(copyList);
            }
            return;
        }

        tempList.Add(root.val);
        AddPathList(root.left, val-root.val, tempList, resList);
        AddPathList(root.right, val-root.val, tempList, resList);
        tempList.RemoveAt(tempList.Count - 1);
    }

    public IList<IList<int>> PathSum(TreeNode root, int sum) 
    {
        IList<IList<int>> resList = new List<IList<int>>();
        if(root == null)
        {
            return resList;
        }

        IList<int> tempList = new List<int>();
        AddPathList(root, sum, tempList, resList);

        return resList;
    }
}

// 248  ms,  80.42%
// 32.6 MB,  72.23%
