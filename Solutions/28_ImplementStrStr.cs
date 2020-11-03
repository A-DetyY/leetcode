/*(Easy)
Implement strStr().

Return the index of the first occurrence of needle in haystack, 
or -1 if needle is not part of haystack.

Clarification:

What should we return when needle is an empty string? 
This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. 
This is consistent to C's strstr() and Java's indexOf().
*/

public class Solution {
   public void GetNext(string p, int[] next)
    {
        int length = p.Length;
        next[0] = -1;
        int k = -1, j = 0;
        while (j < length - 1)
        {
            if(k==-1 || p[j] == p[k])
            {
                k++;
                j++;
                next[j] = k;
            }
            else
            {
                k = next[k];
            }
        }
    }

    public int KmpSearch(string s, string p)
    {
        int i = 0, j = 0;
        int s_len = s.Length, p_len = p.Length;
        int[] next = new int[p_len];
        GetNext(p, next);

        while(i<s_len && j < p_len)
        {
            if(j==-1 || s[i] == p[j])
            {
                i++;
                j++;
            }
            else
            {
                j = next[j];
            }
        }
        if (j == p_len)
        {
            return i - j;
        }
        else
        {
            return -1;
        }
    }

    public int StrStr(string haystack, string needle)
    {
        if(needle.Length == 0)
        {
            return 0;
        }
        return KmpSearch(haystack, needle);
    }
}

// 72  ms,  88.18%
// 23.2MB,  14.46%
 