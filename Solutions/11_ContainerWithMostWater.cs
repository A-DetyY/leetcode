/*(Medium)
Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). 
n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.
*/
 
public class Solution {
   public int MaxArea(int[] height)
    {
        int i = 0, j = height.Length - 1, maxArea = 0;
        while(i < j)
        {
            int h = height[i] <= height[j] ? height[i] : height[j];
            maxArea = Math.Max(maxArea, h * (j - i));
            if (h==height[i])
            {
                i++;
            }
            else
            {
                j--;
            }
        }

        return maxArea;
    }
}

// 104  ms,  82.56%
// 27.4 MB,  94.71%
