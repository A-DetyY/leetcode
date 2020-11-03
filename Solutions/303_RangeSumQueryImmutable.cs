/*(Easy)
Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

Implement the NumArray class:

NumArray(int[] nums) Initializes the object with the integer array nums.
int sumRange(int i, int j) Return the sum of the elements of the nums array in the range [i, j] 
inclusive (i.e., sum(nums[i], nums[i + 1], ... , nums[j]))
 

Example 1:

Input
["NumArray", "sumRange", "sumRange", "sumRange"]
[[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
Output
[null, 1, -1, -3]

Explanation
NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
numArray.sumRange(0, 2); // return 1 ((-2) + 0 + 3)
numArray.sumRange(2, 5); // return -1 (3 + (-5) + 2 + (-1)) 
numArray.sumRange(0, 5); // return -3 ((-2) + 0 + 3 + (-5) + 2 + (-1))
 

Constraints:

0 <= nums.length <= 104
-105 <= nums[i] <= 105
0 <= i <= j < nums.length
At most 104 calls will be made to sumRange.
*/

public class NumArray {
    private int length;
    private int[] nums;

    public NumArray(int[] nums) {
        this.length = nums.Length;
        this.nums = new int[this.length];
        for(int i=0; i<this.length; i++)
        {
            this.nums[i] = nums[i];
        }
    }
    
    public int SumRange(int i, int j) {
        int numSum = 0;
        i = (i >= 0) ? i : 0;
        j = (j < this.length) ? j : this.length-1;
        for(int k=i; k<=j; k++)
        {
            numSum += this.nums[k];
        }
        return numSum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */

// 240 ms,  37.74%
// 36.1MB,  13.21%
