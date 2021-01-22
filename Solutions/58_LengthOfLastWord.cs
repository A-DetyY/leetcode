/*(Easy)
Given a string s consists of some words separated by spaces, 
return the length of the last word in the string. If the last word does not exist, return 0.

A word is a maximal substring consisting of non-space characters only.
*/

public class Solution {
    public int LengthOfLastWord(string s) {
        if (String.IsNullOrEmpty(s))
            return 0;
        int length = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
                length++;
            else if (length > 0)
                break;
        }
        
        return length;
    }
}

// 80  ms,  94.74%
// 22.3MB,  49.81%
