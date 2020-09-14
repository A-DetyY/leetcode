/*(Medium)
Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
determine if s can be segmented into a space-separated sequence of one or more dictionary words.

Note:

The same word in the dictionary may be reused multiple times in the segmentation.
You may assume the dictionary does not contain duplicate words.
*/

using System.Collections.Generic;

public class Solution {
    Dictionary<string, bool> breakableDict = new Dictionary<string, bool>();

    public bool WordBreak(string s, IList<string> wordDict)
    {
        if (String.IsNullOrEmpty(s))
        {
            return true;
        }

        if (breakableDict.ContainsKey(s))
        {
            return breakableDict[s];
        }

        foreach (string word in wordDict)
        {
            if (s.StartsWith(word) && WordBreak(s.Substring(word.Length), wordDict))
            {
                breakableDict[s] = true;
                return true;
            }
        }

        breakableDict[s] = false;
        return false;
    }
}

// 112  ms,  78.44%
// 25.2 MB,  84.88%
