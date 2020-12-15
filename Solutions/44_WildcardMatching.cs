/*(Hard)
Given an input string (s) and a pattern (p), 
implement wildcard pattern matching with support for '?' and '*' where:

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).
*/

public class Solution {
    public bool IsMatch(string s, string p)
    {
        int m = s.Length, n = p.Length;
        bool[][] dp = new bool[m + 1][];
        for (int i = 0; i < m + 1; i++)
            dp[i] = new bool[n + 1];
        dp[0][0] = true;
        for (int i = 1; i <= n; i++)
        {
            if (p[i - 1] == '*')
                dp[0][i] = true;
            else
                break;
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                    dp[i][j] = dp[i][j - 1] || dp[i - 1][j];
                else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    dp[i][j] = dp[i - 1][j - 1];
            }
        }

        return dp[m][n];
    }
}

// 144 ms,  26.53%
// 25.4MB,  95.92%
