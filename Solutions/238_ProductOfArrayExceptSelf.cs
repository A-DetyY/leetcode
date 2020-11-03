/*(Medium)
Given an array nums of n integers where n > 1,  
return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Example:

Input:  [1,2,3,4]
Output: [24,12,8,6]
Constraint: It's guaranteed that the product of the elements of any prefix or suffix of the array 
(including the whole array) fits in a 32 bit integer.

Note: Please solve it without division and in O(n).

Follow up:
Could you solve it with constant space complexity? 
(The output array does not count as extra space for the purpose of space complexity analysis.)
*/

public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        int length = nums.Length;
        int[] leftProduct = new int[length];
        int[] rightProduct = new int[length];
        int[] answerProduct = new int[length];

        leftProduct[0] = 1;
        for (int i = 1; i < length; i++)
        {
            leftProduct[i] = leftProduct[i - 1] * nums[i-1];
        }

        rightProduct[length - 1] = 1;
        for (int i = length - 2; i >= 0; i--)
        {
            rightProduct[i] = rightProduct[i + 1] * nums[i+1];
        }

        for (int i = 0; i < length; i++)
        {
            answerProduct[i] = leftProduct[i] * rightProduct[i];
        }

        return answerProduct;
    }
}

// 248 ms,  99.34%
// 36.2MB,  6.60 %
