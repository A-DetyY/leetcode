/*(Medium)
Given an array of integers nums sorted in ascending order, 
find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

Follow up: Could you write an algorithm with O(log n) runtime complexity?
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
    
    public int[] SearchRange(int[] nums, int target)
    {
        int leftIdx = BinarySearch(nums, target, true);
        int rightIdx = BinarySearch(nums, target, false) - 1;
        if (leftIdx <= rightIdx && rightIdx < nums.Length && nums[leftIdx] == target && nums[rightIdx] == target)
        {
            return new int[] {leftIdx, rightIdx};
        }

        return new[] {-1, -1};
    }
}

// 292 ms,  60.34%
// 31.9MB,  59.39%
