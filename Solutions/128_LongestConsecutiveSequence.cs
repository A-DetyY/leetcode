/*(Hard)
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

Your algorithm should run in O(n) complexity.

Example:

Input: [100, 4, 200, 1, 3, 2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
*/

using System.Collections.Generic;

public class Solution {
    public int LongestConsecutive(int[] nums) 
    {
        Dictionary<int, int> counter = new Dictionary<int, int>();
        int maxLength = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(counter.ContainsKey(nums[i]))
            {
                continue;
            }
            int leftCount = 0;
            if(counter.ContainsKey(nums[i]-1))
            {
                leftCount = counter[nums[i]-1];
            }
            int rightCount = 0;
            if(counter.ContainsKey(nums[i]+1))
            {
                rightCount = counter[nums[i]+1];
            }
            int allCount = leftCount + rightCount + 1;
            counter[nums[i]] = allCount;
            counter[nums[i]-leftCount] = allCount;
            counter[nums[i]+rightCount] = allCount;
            maxLength = Math.Max(maxLength, allCount);
        }

        return maxLength;
    }
}

// 92  ms,  95.65%
// 25.3MB,  55.07%
