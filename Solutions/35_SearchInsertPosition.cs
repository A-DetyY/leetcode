/*(Easy)
Given a sorted array of distinct integers and a target value, 
return the index if the target is found. 
If not, return the index where it would be if it were inserted in order.
*/

public class Solution {
    public int BinarySearch(int[] nums, int target, bool lower)
    {
        int left = 0, right = nums.Length - 1, ans = nums.Length;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] > target || (lower && nums[mid] >= target))
            {
                right = mid - 1;
                ans = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return ans;
    }

    public int SearchInsert(int[] nums, int target)
    {
        int idx = BinarySearch(nums, target, true);
        return idx;
    }
}

// 108 ms,  82.35%
// 24.7MB,  21.75%
