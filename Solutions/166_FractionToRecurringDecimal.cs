/*(Medium)
Given two integers representing the numerator and denominator of a fraction, 
return the fraction in string format.

If the fractional part is repeating, enclose the repeating part in parentheses.

If multiple answers are possible, just return any of them.

Example 1:

Input: numerator = 1, denominator = 2
Output: "0.5"
Example 2:

Input: numerator = 2, denominator = 1
Output: "2"
Example 3:

Input: numerator = 2, denominator = 3
Output: "0.(6)"
*/

public class Solution {
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0)
        {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        if (numerator < 0 ^ denominator < 0)
        {
            sb.Append("-");
        }

        long dividend = Math.Abs((long) numerator);
        long divisor = Math.Abs((long) denominator);
        sb.Append((dividend / divisor).ToString());
        long remainder = dividend % divisor;
        if (remainder == 0)
        {
            return sb.ToString();
        }

        sb.Append(".");
        Dictionary<long, int> dictionary = new Dictionary<long, int>();
        while (remainder != 0)
        {
            if (dictionary.ContainsKey(remainder))
            {
                sb.Insert(dictionary[remainder], "(");
                sb.Append(")");
                break;
            }
            dictionary.Add(remainder, sb.Length);
            remainder *= 10;
            sb.Append((remainder / divisor).ToString());
            remainder %= divisor;
        }

        return sb.ToString();
    }
}

// 80  ms,  88.18%
// 22.5MB,  78.18%
