/*(Medium)
Given an unsorted array of integers, find the length of longest increasing subsequence.
*/

public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        int len = nums.Length;
        int[] dp = new int[len];
        int maxLen = 0;
        for (int i = 0; i < len; i++)
        {
            int value = nums[i];
            int beforeLen = 0;
            for (int j = i - 1; j >= 0; j--)
            {
                if (nums[j] < value)
                {
                    beforeLen = Math.Max(beforeLen, dp[j]);
                }
            }

            if (beforeLen > 0)
            {
                dp[i] = beforeLen + 1;
            }
            else
            {
                dp[i] = 1;
            }

            maxLen = Math.Max(maxLen, dp[i]);
        }

        return maxLen;
    }
}

// 100 ms,  79.26%
// 24.4MB,   5.68%
