/*(Hard)
Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it can trap after raining.
*/

public class Solution {
    public int Trap(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int answer = 0;
        int leftMax = 0, rightMax = 0;
        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    answer += (leftMax - height[left]);
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    answer += (rightMax - height[right]);
                right--;
            }
        }
        return answer;
    }
}

// 100 ms,  98.51%
// 25.1MB,  52.26%
