/*(Hard)
Given a string containing just the characters '(' and ')', 
find the length of the longest valid (well-formed) parentheses substring.

*/

public class Solution {
    // Stack
    public int LongestValidParentheses(string s)
    {
        Stack<int> stack = new Stack<int>();
        int maxLen = 0;
        stack.Push(-1);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    maxLen = Math.Max(maxLen, i - stack.Peek());
                }
            }
        }

        return maxLen;
    } 

    // DP
    public int LongestValidParentheses(string s)
    {
        int maxLen = 0;
        int[] dp = new int[s.Length];
        for(int i = 1; i < s.Length; i++)
        {
            if (s[i] == ')')
            {
                if(s[i-1] == '(')
                {
                    dp[i] = ((i >= 2) ? dp[i - 2] : 0) + 2;
                }
                else if(i-dp[i-1]>0 && s[i-dp[i-1]-1] == '(')
                {
                    dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
        }

        return maxLen;
    }
}

// 88   ms,  34.02%
// 24.5 MB,  14.29%

// 76   ms,  75.92%
// 23.2 MB,  39.50%
