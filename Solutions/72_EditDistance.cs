/*(Hard)
Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.

You have the following 3 operations permitted on a word:

Insert a character
Delete a character
Replace a character
*/

public class Solution {
    public int MinDistance(string word1, string word2)
    {
        int len1 = word1.Length;
        int len2 = word2.Length;
        int[][] dp = new int[len1 + 1][];

        for(int i = 0; i < len1+1; i++)
        {
            dp[i] = new int[len2 + 1];
            if ( i == 0 )
            {
                continue;
            }
            else
            {
                dp[i][0] = dp[i - 1][0] + 1;
            }
        }
        for(int j = 1; j < len2+1; j++)
        {
            dp[0][j] = dp[0][j - 1] + 1;
        }

        for(int i = 1; i < len1+1; i++)
        {
            for(int j = 1; j < len2+1; j++)
            {
                if(word1[i-1] == word2[j-1])
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else
                {
                    dp[i][j] = Math.Min(Math.Min(dp[i][j - 1], dp[i - 1][j]), dp[i - 1][j - 1]) + 1;
                }
            }
        }

        return dp[len1][len2];
    }
}

// 96   ms,  22.25%
// 25.9 MB,  88.53%
