/*(Medium)
A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given a non-empty string containing only digits, determine the total number of ways to decode it.
*/

public class Solution {
    public int NumDecodings(string s) 
    {
        if(s == null || s.Length == 0 || s[0] == '0')
        {
            return 0;
        }

        int[] dp = new int[s.Length+1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        for(int i=2; i<=s.Length; i++)
        {
            dp[i] = s[i-1] == '0' ? 0 : dp[i-1];
            if((s[i-2]=='1' || (s[i-2]=='2' && s[i-1]<='6')))
            {
                dp[i] += dp[i-2];
            }
        }

        return dp[s.Length];
    }
}

// 76   ms,  81.36%
// 22.4 MB,  92.38%
