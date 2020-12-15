/*(Medium)
Given two non-negative integers num1 and num2 represented as strings, 
return the product of num1 and num2, also represented as a string.

Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/

public class Solution {
    public string Multiply(string num1, string num2)
    {
        if (num1.Equals("0") || num2.Equals("0"))
            return "0";

        int m = num1.Length, n = num2.Length;
        int[] ansArray = new int[m + n];
        for (int i = m - 1; i >= 0; i--)
        {
            int x = num1[i] - '0';
            for (int j = n - 1; j >= 0; j--)
            {
                int y = num2[j] - '0';
                ansArray[i + j + 1] += x * y;
            }
        }

        for (int i = m + n - 1; i > 0; i--)
        {
            ansArray[i - 1] += ansArray[i] / 10;
            ansArray[i] %= 10;
        }

        int index = ansArray[0] == 0 ? 1 : 0;
        StringBuilder sb = new StringBuilder();
        while (index < m + n)
        {
            sb.Append(ansArray[index]);
            index++;
        }
        return sb.ToString();
    }
}

// 96  ms,  98.63%
// 25.2MB,  65.28%
