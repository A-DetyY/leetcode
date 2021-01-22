/*(Easy)
Given a non-empty array of decimal digits representing a non-negative integer, 
increment one to the integer.

The digits are stored such that the most significant digit is at the head of the list, 
and each element in the array contains a single digit.

You may assume the integer does not contain any leading zero, except the number 0 itself.
*/

public class Solution {
    public int[] PlusOne(int[] digits) {
        int length = digits.Length;
        int k = 0, i = length - 1;
        for (i = length - 1; i >= 0; i--)
        {
            k = (digits[i] + 1) / 10;
            if (k > 0)
                digits[i] = 0;
            else
            {
                digits[i] = digits[i] + 1;
                break;
            }
        }

        if (k > 0)
        {
            int[] newDigits = new int[length + 1];
            newDigits[0] = k;
            for (i = 1; i <= length; i++)
                newDigits[i] = 0;
            return newDigits;
        }
        else
        {
            return digits;
        }
    }
}

// 268 ms,  91.82%
// 30  MB,  62.19%
