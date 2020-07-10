/*(Easy)
Given a 32-bit signed integer, reverse digits of an integer.

*/

public class Solution {
    public int Reverse(int x)
    {
        if(x == 0 || x == int.MinValue || x == int.MaxValue)
        {
            return 0;
        }
        bool isNegative = x < 0;
        if(isNegative)
        {
            x = -x;
        }
        int value = 0, remain;
        int otherValue = (int)(int.MaxValue/10);
        int digit = int.MaxValue % 10;

        while(x > 0)
        {
            remain = x % 10;
            if(value > otherValue || (value == otherValue && remain > digit))
            {
                value = 0;
                break;
            }
            value = value * 10 + remain;
            x /= 10;
        }

        return isNegative ? -value : value;
    }
}

// 40   ms,  88.48%
// 14.7 MB,  54.99%
