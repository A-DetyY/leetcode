/*(Medium)
A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?
*/

public class Solution {
    public int UniquePaths(int m, int n)
    {
        int[] dp = new int[n];
        dp[0] = 1;

        for(int i = 0; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[n - 1];
    }
}

// 48   ms,  33.99%
// 14.4 MB,  99.63%
