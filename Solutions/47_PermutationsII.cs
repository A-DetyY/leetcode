/*(Medium)
Given a collection of numbers, nums, that might contain duplicates, 
return all possible unique permutations in any order.
*/

public class Solution {
    private bool[] visit;
    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        IList<IList<int>> resList = new List<IList<int>>();
        IList<int> perm = new List<int>();
        visit = new bool[nums.Length];
        Array.Sort(nums);
        Backtrack(nums, resList, 0, perm);
        return resList;
    }

    public void Backtrack(int[] nums, IList<IList<int>> resList, int idx, IList<int> perm)
    {
        if (idx == nums.Length)
        {
            resList.Add(new List<int>(perm));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (visit[i] || (i > 0 && nums[i] == nums[i - 1] && !visit[i - 1]))
            {
                continue;
            }
            perm.Add(nums[i]);
            visit[i] = true;
            Backtrack(nums, resList, idx+1, perm);
            visit[i] = false;
            perm.RemoveAt(idx);
        }
    }
}

// 280 ms,  97.33%
// 33.1MB,  5.80 %
