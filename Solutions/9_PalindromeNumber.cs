/*(Easy)
Determine whether an integer is a palindrome. 
An integer is a palindrome when it reads the same backward as forward.

*/

public class Solution {
    public bool IsPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            return false;
        }

        int tailNum = 0;
        while (tailNum < x)
        {
            tailNum = tailNum * 10 + x % 10;
            x /= 10;
        }

        return x == tailNum || x == tailNum / 10;
    }
}

// 60   ms,  87.84%
// 15.7 MB,  99.72%
