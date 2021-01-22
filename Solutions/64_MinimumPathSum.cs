/*(Medium)
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, 
which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.
*/

public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] dp = new int[m][];

        for(int i = 0; i < m; i++)
        {
            dp[i] = new int[n + 1];
            for(int j = 0; j < n; j++)
            {
                int minValue;
                if (i > 0 && j > 0)
                {
                    minValue = Math.Min(dp[i - 1][j], dp[i][j - 1]);
                }
                else if(i > 0)
                {
                    minValue = dp[i - 1][j];
                }
                else if(j > 0)
                {
                    minValue = dp[i][j - 1];
                }
                else
                {
                    minValue = 0;
                }
                dp[i][j] = minValue + grid[i][j];
            }
        }

        return dp[m-1][n-1];
    }
}

// 116 ms,  81.44%
// 26.5MB,   8.98%
