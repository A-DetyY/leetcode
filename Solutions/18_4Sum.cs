/*(Medium)
Given an array nums of n integers and an integer target, 
are there elements a, b, c, and d in nums such that a + b + c + d = target? 
Find all unique quadruplets in the array which gives the sum of target.

Notice that the solution set must not contain duplicate quadruplets.

 

Example 1:

Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
Example 2:

Input: nums = [], target = 0
Output: []
 

Constraints:

0 <= nums.length <= 200
-109 <= nums[i] <= 109
-109 <= target <= 109
*/

public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) 
    {
        IList<IList<int>> resList = new List<IList<int>>();
        if (nums == null || nums.Length < 4)
        {
            return resList;
        }
        
        Array.Sort(nums);
        int length = nums.Length;
        for (int i = 0; i < length - 3; i++)
        {
            if(i>0 && nums[i] == nums[i-1])
                continue;
            if(nums[i]+nums[i+1]+nums[i+2]+nums[i+3] > target)
                break;
            if(nums[i]+nums[length-3]+nums[length-2]+nums[length-1] < target)
                continue;
            for (int j = i + 1; j < length - 2; j++)
            {
                if(j>i+1 && nums[j]==nums[j-1])
                    continue;
                if(nums[i]+nums[j]+nums[j+1]+nums[j+2] > target)
                    break;
                if(nums[i]+nums[j]+nums[length-2]+nums[length-1] < target)
                    continue;
                int left = j + 1, right = length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[j] + nums[left] + nums[right];
                    if (sum == target)
                    {
                        int[] tempArray = new int[] {nums[i], nums[j], nums[left], nums[right]};
                        resList.Add(new List<int>(tempArray));
                        while (left < right && nums[left] == nums[left + 1])
                        {
                            left++;
                        }
                        left++;
                        
                        while (left < right && nums[right] == nums[right - 1])
                        {
                            right--;
                        }
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
        }

        return resList;
    }
}

// 252 ms,  92.37%
// 32.6MB,   9.16%
