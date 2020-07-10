/*(Medium)
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
*/

public class Solution {
    public void GenerateParenthesisRecursive(StringBuilder curStr, List<string> solveList, int left, int right)
    {
        if (left == 0 && right == 0)
        {
            string solve = "" + curStr;
            solveList.Add(solve);
            return;
        }

        if (left > 0)
        {
            GenerateParenthesisRecursive(curStr.Append("("), solveList, left - 1, right);
            curStr.Remove(curStr.Length - 1, 1);
        }
        if (left < right)
        {
            GenerateParenthesisRecursive(curStr.Append(")"), solveList, left, right - 1);
            curStr.Remove(curStr.Length - 1, 1);
        }
    }

    public IList<string> GenerateParenthesis(int n)
    {
        List<string> allSoves = new List<string>();
        StringBuilder curStr = new StringBuilder();
        GenerateParenthesisRecursive(curStr, allSoves, n, n);
        return allSoves;
    }
}

// 236  ms,  79.15%
// 27.4 MB,  9.38 %
