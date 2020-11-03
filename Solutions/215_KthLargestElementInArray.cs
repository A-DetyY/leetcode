/*(Medium)
Find the kth largest element in an unsorted array. 
Note that it is the kth largest element in the sorted order, not the kth distinct element.

Example 1:

Input: [3,2,1,5,6,4] and k = 2
Output: 5
Example 2:

Input: [3,2,3,1,2,4,5,5,6] and k = 4
Output: 4
Note:
You may assume k is always valid, 1 ≤ k ≤ array's length.
*/

public class Solution {
    public void Swap(int[] nums, int i, int j)
    {
        if (i >= nums.Length || j >= nums.Length)
        {
            return;
        }

        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

   public int Partition(int[] nums, int l, int r)
    {
        int value = nums[l];
        int left = l, right = r;
        while (left < right)
        {
            while (nums[right] < value && left < right)
            {
                right--;
            }

            nums[left] = nums[right];
            while (nums[left] >= value && left < right)
            {
                left++;
            }

            nums[right] = nums[left];
        }

        nums[left] = value;
        return left;
    }

    public int QuickSelect(int[] nums, int left, int right, int index)
    {
        int partition = Partition(nums, left, right);
        if (partition == index)
        {
            return nums[partition];
        }
        else if(partition < index)
        {
            return QuickSelect(nums, partition + 1, right, index);
        }
        else
        {
            return QuickSelect(nums, left, partition - 1, index);
        }
    }
    
    public int FindKthLargest(int[] nums, int k)
    {
        return QuickSelect(nums, 0, nums.Length-1, k-1);
    }
}

// 112 ms,  59.03%
// 25.6MB,  64.20%
