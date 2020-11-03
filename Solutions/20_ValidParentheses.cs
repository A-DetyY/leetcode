/*(Easy)
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
 determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
*/

public class Solution {
    public bool IsValid(string s) 
    {
        Stack<char> stack = new Stack<char>();
        if (s.Length == 0)
            return true;
        if (s[0] == ')' || s[0] == ']' || s[0] == '}')
            return false;
        
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
					return false;
                    
                char peek = stack.Pop();
                if (c == ')' && peek != '(')
                    return false;
                else if (c == ']' && peek != '[')
                    return false;
                else if (c == '}' && peek != '{')
                    return false;
            }
        }

        return (stack.Count == 0) ? true : false;
    }
}

// 72  ms,  82.45%
// 22.6MB,   5.06%