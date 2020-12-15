/*(Medium)
Implement pow(x, n), which calculates x raised to the power n (i.e. xn).
*/

public class Solution {
    public double MyPow(double x, int n)
    {
        long N = n;
        return N >= 0 ? QuickMul(x, N) : 1.0 / QuickMul(x, -N);
    }

    public double QuickMul(double x, long n)
    {
        if (n == 0)
            return 1.0;
        double y = QuickMul(x, n / 2);
        return n % 2 == 0 ? y * y : y * y * x;
    }
}

// 52  ms,  86.01%
// 15.5MB,  14.66%
