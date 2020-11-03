/*(Easy)
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

0 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lower-case English letters.
*/

public class Solution {
    public string LongestCommonPrefix(string[] strs) 
    {
        if(strs == null || strs.Length == 0)
        {
            return new string("");
        }
        string prefix = strs[0];
        for(int i = 1; i < strs.Length; i++)
        {
            while (!strs[i].StartsWith(prefix))
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if(prefix.Length < 1)
                {
                    return new string("");
                }
            }
        }
        return prefix;
    }
}

// 108 ms,  35.37%
// 25.8MB,   6.71%
