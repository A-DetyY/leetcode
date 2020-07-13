/*(Hard)
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
*/

public class Solution {
    public string MinWindow(string s, string t)
    {
        if(s==null || s=="" || t==null || t=="" || s.Length < t.Length)
        {
            return "";
        }

        int[] need = new int[128];
        int[] have = new int[128];
        int left = 0, right = 0, min = s.Length + 1, count = 0, start = 0;

        for(int i = 0; i < t.Length; i++)
        {
            need[t[i]]++;
        }

        while(right < s.Length)
        {
            char r = s[right];
            if(need[r] == 0)
            {
                right++;
                continue;
            }
            if(have[r] < need[r])
            {
                count++;
            }
            have[r]++;
            right++;
            while(count == t.Length)
            {
                if(right-left < min)
                {
                    min = right - left;
                    start = left;
                }
                char l = s[left];
                if(need[l] == 0)
                {
                    left++;
                    continue;
                }
                if(have[l] == need[l])
                {
                    count--;
                }
                have[l]--;
                left++;
            }
        }
        if(min == s.Length + 1)
        {
            return "";
        }

        return s.Substring(start, min);
    }
}

// 92   ms,  91.88%
// 25.3 MB,  98.94%
