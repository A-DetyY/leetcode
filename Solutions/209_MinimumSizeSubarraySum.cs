/*(Medium)
Given an array of n positive integers and a positive integer s, 
find the minimal length of a contiguous subarray of which the sum ≥ s. 
If there isn't one, return 0 instead.

Example: 

Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.
Follow up:
If you have figured out the O(n) solution, 
try coding another solution of which the time complexity is O(n log n). 
*/

public class Solution {
    public int MinSubArrayLen(int s, int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int len = nums.Length;
        int sumValue = 0, minLen = int.MaxValue;
        int startPos = 0, endPos = 0;

        for (int i = 0; i < len; i++)
        {
            if (nums[i] >= s)
            {
                return 1;
            }
            sumValue += nums[i];
            endPos = i;
            if (sumValue >= s)
            {
                while (startPos < endPos)
                {
                    sumValue -= nums[startPos];
                    if (sumValue < s)
                    {
                        sumValue += nums[startPos];
                        break;
                    }
                    else
                    {
                        startPos++;
                    }
                }

                minLen = Math.Min(minLen, endPos - startPos + 1);
            }
        }
        
        return (minLen != Int32.MaxValue) ? minLen : 0;
    }
}

// 112 ms,  40.44%
// 25.2MB,  91.14%
