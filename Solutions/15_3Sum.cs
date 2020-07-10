/*(Medium)
Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0?
Find all unique triplets in the array which gives the sum of zero.

Note:

The solution set must not contain duplicate triplets.
*/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> resList = new List<IList<int>>();
        Array.Sort(nums);
        if (nums.Length < 3 || nums[0] > 0)
        {
            return resList;
        }

        for (int i=0; i<nums.Length-2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            if (i>0 && nums[i] == nums[i-1])
            {
                continue;
            }
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[i]+nums[left]+nums[right] == 0)
                {
                    resList.Add(new List<int>(new int[] { nums[i], nums[left], nums[right] }));
                    while (left < right && nums[left]==nums[left+1])
                    {
                        left++;
                    }
                    while (left < right && nums[right]==nums[right-1])
                    {
                        right--;
                    }
                    left++;
                    right--;
                }
                else if (nums[i]+nums[left]+nums[right] > 0)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return resList;
    }
}

// 312  ms,  85.01%
// 35.5 MB,  76.76%
