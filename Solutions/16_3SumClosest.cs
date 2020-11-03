/*(Medium)
Given an array nums of n integers and an integer target, 
find three integers in nums such that the sum is closest to target. 
Return the sum of the three integers. You may assume that each input would have exactly one solution.

 

Example 1:

Input: nums = [-1,2,1,-4], target = 1
Output: 2
Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
 

Constraints:

3 <= nums.length <= 10^3
-10^3 <= nums[i] <= 10^3
-10^4 <= target <= 10^4
*/

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) 
    {
        Array.Sort(nums);

        int closestNum = nums[0] + nums[1] + nums[2];
        int gapValue = (int)(Math.Pow(2, 31) - 1);
        for (int i=0; i<nums.Length-2; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                int absValue = Math.Abs(target - sum);
                if (absValue < gapValue)
                {
                    closestNum = sum;
                    gapValue = absValue;
                }
                if (sum == target)
                {
                    return sum;
                }
                else if(sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return closestNum;
    }
}

// 92  ms,  94.73%
// 25.9MB,  34.28%
