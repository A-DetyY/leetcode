/*(Medium)
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Determine if you are able to reach the last index.
*/

public class Solution {
    public bool CanJump(int[] nums)
    {
        int rightMost = 0, length = nums.Length;
        for (int i = 0; i < length; i++)
        {
            if (i <= rightMost)
            {
                rightMost = Math.Max(rightMost, i + nums[i]);
                if (rightMost >= length - 1)
                    return true;
            }
        }

        return false;
    }
}

// 112 ms,  91.41%
// 26.2MB,  24.68%
