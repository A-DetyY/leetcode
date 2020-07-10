/*(Medium)
Implement atoi which converts a string to an integer.

The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.
Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:

Only the space character ' ' is considered as whitespace character.
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−2^31,  2^31 − 1]. 
If the numerical value is out of the range of representable values, INT_MAX (2^31 − 1) or INT_MIN (−2^31) is returned.
*/

public class Solution {
    public int MyAtoi(string str)
    {
        int MAX = (int)(Math.Pow(2, 31) - 1);
        int MIN = -(int)Math.Pow(2, 31);
        bool isNegative = false, hasFind = false;
        int curVal = 0, maxDivideTen = MAX / 10;

        for(int i = 0; i < str.Length; i++)
        {
            if (str[i] == '-' || str[i] == '+' || str[i] == ' ')
            {
                if (str[i] == '-' && !isNegative && !hasFind)
                {
                    isNegative = true;
                    hasFind = true;
                }
                else if(str[i] == '+' && !isNegative && !hasFind)
                {
                    hasFind = true;
                }
                else if (!isNegative && !hasFind)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            else if (str[i] >= '0' && str[i] <= '9')
            {
                hasFind = true;
                int val = str[i] - '0';
                if (curVal > maxDivideTen)
                {
                    curVal = (!isNegative) ? MAX : MIN;
                    return curVal;
                }
                else
                {
                    curVal *= 10;
                }
                if (!isNegative)
                {
                    if (MAX - curVal < val)
                    {
                        return MAX;
                    }
                    else
                    {
                        curVal += val;
                    }
                }
                else
                {
                    if ((MAX - curVal <= val - 1))
                    {
                        return MIN;
                    }
                    else
                    {
                        curVal += val;
                    }
                }
            }
            else
            {
                break;
            }
        }

        return (!isNegative) ? curVal : -curVal;
    }
}

// 108  ms,  25.02%
// 24.8 MB,  90.75%
