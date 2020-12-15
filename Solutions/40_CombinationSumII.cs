/*(Medium)
Given a collection of candidate numbers (candidates) and a target number (target), 
find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.
*/

public class Solution {
    public void AddNext(int[] candidates, int target, int startPos, IList<int> tempList, IList<IList<int>> resList)
    {
        for (int i = startPos; i < candidates.Length; i++)
        {
            if(i > startPos && candidates[i]==candidates[i-1])
            {
                continue;
            }

            if (candidates[i] < target)
            {
                tempList.Add(candidates[i]);
                AddNext(candidates, target - candidates[i], i+1, tempList, resList);
                tempList.RemoveAt(tempList.Count - 1);
            }
            else if (candidates[i] == target)
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

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> resList = new List<IList<int>>();
        if (candidates.Length == 0)
        {
            return resList;
        }

        Array.Sort(candidates);
        IList<int> tempList = new List<int>();
        AddNext(candidates, target, 0, tempList, resList);

        return resList;
    }
}

// 272 ms,  99.60%
// 31.4MB,  34.82%
