/*(Medium)
Given a positive integer n, find the least number of perfect square numbers 
(for example, 1, 4, 9, 16, ...) which sum to n.
*/

public class Solution {
    public int NumSquares(int n) {
        int[] dp = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = i;
            int sqrtI = (int) Math.Sqrt(i);
            for (int j = 1; j <= sqrtI; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }

        return dp[n];
    }
}

// 88  ms,  80.45%
// 16.9MB,   5.00%
