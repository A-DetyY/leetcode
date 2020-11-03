/*(Medium)
Given two integers dividend and divisor, divide two integers without using multiplication, division, 
and mod operator.

Return the quotient after dividing dividend by divisor.

The integer division should truncate toward zero, which means losing its fractional part. 
For example, truncate(8.345) = 8 and truncate(-2.7335) = -2.

Note:

Assume we are dealing with an environment that could only store integers within the 32-bit signed integer
range: [−231,  231 − 1]. For this problem, 
assume that your function returns 231 − 1 when the division result overflows.
*/

public class Solution {
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0)
            return 0;
        if (divisor == 1)
            return dividend;
        else if (divisor == -1)
        {
            if (dividend > int.MinValue)
                return -dividend;
            else
                return int.MaxValue;
        }

        bool isPositive = !((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0));
        int value = Div(Math.Abs((long)dividend), Math.Abs((long)divisor));
        return isPositive ? value : -value;
    }

    public int Div(long dividend, long divisor)
    {
        if (divisor > dividend)
            return 0;
        int count = 1;
        long p = divisor;
        while ((p+p) <= dividend)
        {
            count = count + count;
            p = p + p;
        }

        return count + Div(dividend - p, divisor);
    }
}

// 44  ms,  55.71%
// 15.3MB,  21.43%
