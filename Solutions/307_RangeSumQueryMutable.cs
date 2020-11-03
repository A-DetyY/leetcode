/*(Medium)
Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

The update(i, val) function modifies nums by updating the element at index i to val.

Example:

Given nums = [1, 3, 5]

sumRange(0, 2) -> 9
update(1, 2)
sumRange(0, 2) -> 8
 

Constraints:

The array is only modifiable by the update function.
You may assume the number of calls to update and sumRange function is distributed evenly.
0 <= i <= j <= nums.length - 1
*/

public class NumArray
{
    private int[] original_data;
    private int[] data;
    private int length;
    public NumArray(int[] nums)
    {
        length = nums.Length + 1;
        original_data = new int[length];
        data = new int[length];
        original_data[0] = 0;
        data[0] = 0;
        for (int i = 1; i < length; i++)
        {
            original_data[i] = nums[i - 1];
            data[i] = data[i - 1] + original_data[i];
        }
    }

    public void Update(int i, int val)
    {
        original_data[i + 1] = val;
        for (int k = i+1; k < length; k++)
        {
            data[k] = data[k - 1] + original_data[k];
        }
    }

    public int SumRange(int i, int j)
    {
        return data[j + 1] - data[i];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(i,val);
 * int param_2 = obj.SumRange(i,j);
 */

 // 352 ms,  15.74%
 // 38.4MB,  10.19%
 