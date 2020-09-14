/*(Easy)
You are a professional robber planning to rob houses along a street. 
Each house has a certain amount of money stashed, 
the only constraint stopping you from robbing each of them is 
that adjacent houses have security system connected and it will automatically contact the police 
if two adjacent houses were broken into on the same night.

Given a list of non-negative integers representing the amount of money of each house, 
determine the maximum amount of money you can rob tonight without alerting the police.

 

Example 1:

Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
             Total amount you can rob = 1 + 3 = 4.
Example 2:

Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
             Total amount you can rob = 2 + 9 + 1 = 12.
 

Constraints:

0 <= nums.length <= 100
0 <= nums[i] <= 400
*/

public class Solution {
    public int Rob(int[] nums)
    {
        int len = nums.Length;
        if (len <= 2)
        {
            int maxValue = 0;
            if (len == 2)
            {
                maxValue = Math.Max(nums[0], nums[1]);
            }
            else if (len == 1)
            {
                maxValue = nums[0];
            }

            return maxValue;
        }

        int[] dp = new int[len];
        dp[0] = nums[0];
        dp[1] = nums[1];
        for (int i = 2; i < len; i++)
        {
            if (i >= 3)
            {
                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
            }
            else
            {
                dp[i] = dp[i - 2] + nums[i];
            }
        }

        int maxDp = Math.Max(dp[len - 1], dp[len - 2]);
        return maxDp;
    }
}

// 84  ms,  94.33%
// 23.7MB,  69.09%
