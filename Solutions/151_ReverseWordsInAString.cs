/*(Medium)
Given an input string, reverse the string word by word.

 

Example 1:

Input: "the sky is blue"
Output: "blue is sky the"
Example 2:

Input: "  hello world!  "
Output: "world! hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
Example 3:

Input: "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
 

Note:

A word is defined as a sequence of non-space characters.
Input string may contain leading or trailing spaces. However, 
your reversed string should not contain leading or trailing spaces.
You need to reduce multiple spaces between two words to a single space in the reversed string.
 

Follow up:

For C programmers, try to solve it in-place in O(1) extra space.
*/

public class Solution {
    public string ReverseWords(string s) 
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
        {
            return "";
        }

        string[] s_list = s.Split(' ');
        StringBuilder reverse_s = new StringBuilder();
			for (int i = s_list.Length - 1; i >= 0; i--)
			{
				if (!string.IsNullOrWhiteSpace(s_list[i]))
				{
					reverse_s.Append(s_list[i]);
				    reverse_s.Append(" ");
                }
			}

			reverse_s.Remove(reverse_s.Length - 1, 1);
        return reverse_s.ToString();
    }
}

// 92  ms,  81.70%
// 24.6MB,  76.64%
