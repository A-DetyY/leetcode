/*(Hard)
Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like . or *.
*/

public class Solution {
    public bool IsMatch(string text, string pattern) 
    {
        if (pattern.Length == 0)
        {
            return text.Length == 0;
        }

        bool firstMatch = text.Length > 0 && (text[0] == pattern[0] || pattern[0] == '.');
        if (pattern.Length >= 2 && pattern[1] == '*')
        {
            return IsMatch(text, pattern.Substring(2)) ||
                    (firstMatch && IsMatch(text.Substring(1), pattern));
        }
        else
        {
            return firstMatch && IsMatch(text.Substring(1), pattern.Substring(1));
        }
    }
}

// 488  ms,  27.38%
// 25.7 MB,  25.79%
