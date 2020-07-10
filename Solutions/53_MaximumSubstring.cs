/*(Easy)
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

Example:

Input: [-2,1,-3,4,-1,2,1,-5,4],
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
Follow up:

If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
*/

public class Solution {
    public int MaxSubArray(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int n = nums.Length;
        int lastValue = nums[0];
        int maxValue = lastValue;
        for (int i = 1; i < n; i++)
        {
            lastValue = lastValue > 0 ? (lastValue + nums[i]) : nums[i];
            maxValue = maxValue > lastValue ? maxValue : lastValue;
        }

        return maxValue;
    }
}

// 96   ms,  77.84%
// 25.2 MB,  94.13%
