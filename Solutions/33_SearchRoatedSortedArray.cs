/*(Medium)
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.

Your algorithm's runtime complexity must be in the order of O(log n).
*/

public class Solution {
    public int Search(int[] nums, int target)
    {
        int length = nums.Length;
        if(length == 0)
        {
            return -1;
        }
        if(length == 1)
        {
            return nums[0] == target ? 0 : -1;
        }

        int left = 0, right = length - 1, mid = 0;
        while(left <= right)
        {
            mid = (left + right) / 2;
            if(nums[mid] == target)
            {
                return mid;
            }
            if(nums[left] <= nums[mid])
            {
                // left~mid 是一个升序序列
                if(nums[left]<=target && target<=nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                // left~mid 中存在一个旋转节点
                if (nums[mid] < target && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}

// 124  ms,  20.60%
// 24.9 MB,  14.06%
