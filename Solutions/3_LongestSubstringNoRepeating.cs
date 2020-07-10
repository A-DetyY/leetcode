/*(Medium)
Given a string, find the length of the longest substring without repeating characters.

*/

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        Hashtable charIndex = new Hashtable();
        int first = -1, maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (!charIndex.ContainsKey(c))
            {
                charIndex.Add(c, i);
            }
            else
            {
                int index = (int)charIndex[c];
                if (index > first)
                {
                    first = index;
                }
                charIndex[c] = i;
            }
            if (i - first > maxLength)
            {
                maxLength = i - first;
            }
        }

        return maxLength;
    }
}

// 92   ms,  61.00%
// 25.8 MB,  52.85%
