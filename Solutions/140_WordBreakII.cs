/*(Hard)
Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
add spaces in s to construct a sentence where each word is a valid dictionary word. 
Return all such possible sentences.

Note:

The same word in the dictionary may be reused multiple times in the segmentation.
You may assume the dictionary does not contain duplicate words.
*/

using System.Collections.Generic;

public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict, Dictionary<string, IList<string>> memory)
    {
        if (memory.ContainsKey(s))
        {
            return memory[s];
        }

        IList<string> result = new List<string>();

        if (String.IsNullOrEmpty(s))
        {
            result.Add("");
            return result;
        }

        foreach (string word in wordDict)
        {
            if (s.StartsWith(word))
            {
                string sub = s.Substring(word.Length);
                IList<string> subRes = WordBreak(sub, wordDict, memory);
                foreach (string st in subRes)
                {
                    if (st == "")
                    {
                        result.Add(word);
                    }
                    else
                    {
                        result.Add(word + " " + st);
                    }
                }
            }
        }
        memory.Add(s, result);
        return result;
    }

    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        return WordBreak(s, wordDict, new Dictionary<string, IList<string>>());
    }
}

// 300  ms,  69.06%
// 31.9 MB,  88.06%
