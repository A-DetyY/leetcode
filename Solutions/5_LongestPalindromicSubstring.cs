/*(Medium)
Given a string s, find the longest palindromic substring in s. 
You may assume that the maximum length of s is 1000.

*/

public class Solution {
   public int ExpandAroundCenter(char[] array, int left, int right)
    {
        int L = left, R = right;
        while (L >= 0 && R < array.Length && array[L] == array[R])
        {
            L--;
            R++;
        }
        return R - L - 1;
    }

    public string LongestPalindrome(string s)
    {
        if(s==null || s.Length < 1)
        {
            return new string("");
        }

        char[] original_arr = s.ToCharArray();
        int length = original_arr.Length;
        int start = 0, end = 0;
        int i, len1, len2, len;
        for (i = 0; i < length; i++)
        {
            len1 = ExpandAroundCenter(original_arr, i, i);
            len2 = ExpandAroundCenter(original_arr, i, i + 1);
            len = Math.Max(len1, len2);
            if (len > end - start + 1)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }
        char[] longest_arr = new char[end - start + 1];
        for (i = 0; i < end - start + 1; i++)
        {
            longest_arr[i] = original_arr[start + i];
        }
        return new string(longest_arr);
    }
}

// 100  ms,  82.21%
// 23.1 MB,  64.09%
