/*(Medium)
Given a collection of distinct integers, return all possible permutations.

Example:

Input: [1,2,3]
Output:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
*/

public class Solution {
    public void Swap(int[] nums, int i, int j)
    {
        if(i >= nums.Length || j >= nums.Length)
        {
            return;
        }

        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    public void PutNext(IList<IList<int>> resList, int[] nums, int n, int start)
    {
        if(n == start)
        {
            IList<int> solve = new List<int>(nums);
            resList.Add(solve);
            return;
        }

        for(int i = start; i < n; i++)
        {
            Swap(nums, start, i);
            PutNext(resList, nums, n, start + 1);
            Swap(nums, i, start);
        }
    }

    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> resList = new List<IList<int>>();
        IList<int> tempList = new List<int>();
        HashSet<int> hashSet = new HashSet<int>();
        PutNext(resList, nums, nums.Length, 0);

        return resList;
    }
}

// 232  ms,  99.22%
// 31.4 MB,  89.36%
