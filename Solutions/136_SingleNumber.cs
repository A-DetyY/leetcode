/*(Easy)
Given a non-empty array of integers, every element appears twice except for one. Find that single one.

Note:

Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
*/

using System.Collections.Generic;

public class Solution {
    public int SingleNumber(int[] nums) 
    {
        HashSet<int> hashSet = new HashSet<int>();
        int sumSet = 0, sumNum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (!hashSet.Contains(nums[i]))
            {
                hashSet.Add(nums[i]);
                sumSet += nums[i];
            }

            sumNum += nums[i];
        }

        return 2 * sumSet - sumNum;
    }
}

// 108  ms,  65.80%
// 27.7 MB,  22.89%
