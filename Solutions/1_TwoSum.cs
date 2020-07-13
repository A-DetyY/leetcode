/*(Easy)
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        Hashtable hashtable = new Hashtable();
        int first_index = 0, second_index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (hashtable.ContainsKey(nums[i]))
            {
                first_index = (int)hashtable[nums[i]];
                second_index = i;
                break;
            }
            else if (!hashtable.ContainsKey(target - nums[i]))
            {
                hashtable.Add(target - nums[i], i);
            }
        }

        return new int[] { first_index, second_index };
    }
}

// 256 ms,  67.14%
// 32  MB,  6.10 % 
