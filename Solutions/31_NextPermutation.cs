/*(Medium)
Implement next permutation, 
which rearranges numbers into the lexicographically next greater permutation of numbers.

If such an arrangement is not possible, 
it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

The replacement must be in place and use only constant extra memory.
*/

public class Solution {
    public void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    
    public void NextPermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }

        if (i >= 0)
        {
            int j = nums.Length - 1;
            while (j >= 0 && nums[i] >= nums[j])
            {
                j--;
            }
            Swap(ref nums[i], ref nums[j]);
        }
        Array.Reverse(nums, i+1, nums.Length-i-1);
    }
}

// 272 ms,  93.62%
// 31.4MB,  28.37%
