/*(Hard)
Given an unsorted integer array nums, find the smallest missing positive integer.

Follow up: Could you implement an algorithm that runs in O(n) time and uses constant extra space.?
*/

public class Solution {
    public int FirstMissingPositive(int[] nums)
    {
        int length = nums.Length;
        int replaceValue = length + 1;
        for (int i = 0; i < length; i++)
        {
            if (nums[i] <= 0)
                nums[i] = replaceValue;
        }

        for (int i = 0; i < length; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num > 0 && num < replaceValue)
            {
                nums[num - 1] = -Math.Abs(nums[num - 1]);
            }
        }

        for (int i = 0; i < length; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }

        return length + 1;
    }
}

// 104 ms,  85.85%
// 24.6MB,  16.04%
