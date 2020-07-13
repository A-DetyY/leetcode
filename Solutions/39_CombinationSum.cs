/*(Medium)
Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), 
find all unique combinations in candidates where the candidate numbers sums to target.

The same repeated number may be chosen from candidates unlimited number of times.

Note:

All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
*/

public class Solution {
    public void AddNext(int[] candidates, int target, int startPos, IList<int> tempList, IList<IList<int>> resList)
    {
        for(int i = startPos; i < candidates.Length; i++)
        {
            if(candidates[i] < target)
            {
                tempList.Add(candidates[i]);
                AddNext(candidates, target - candidates[i], i, tempList, resList);
                tempList.RemoveAt(tempList.Count - 1);
            }
            else if(candidates[i] == target)
            {
                IList<int> oneSolve = new List<int>(tempList);
                oneSolve.Add(candidates[i]);
                resList.Add(oneSolve);
                break;
            }
            else
            {
                break;
            }
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> resList = new List<IList<int>>();
        if(candidates.Length == 0)
        {
            return resList;
        }

        Array.Sort(candidates);
        IList<int> tempList = new List<int>();
        AddNext(candidates, target, 0, tempList, resList);

        return resList;
    }
}

// 240  ms,  94.24%
// 31.8 MB,  63.42%
