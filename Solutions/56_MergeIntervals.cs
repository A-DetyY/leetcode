/*(Medium)
Given an array of intervals where intervals[i] = [starti, endi], 
merge all overlapping intervals, 
and return an array of the non-overlapping intervals that cover all the intervals in the input.
*/

public class Solution {
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
            return new int[][] { };
        Array.Sort(intervals, (x, y) => (x[0] < y[0]) ? -1 : 1);
        List<int[]> merged = new List<int[]>();
        for (int i = 0; i < intervals.Length; i++)
        {
            int left = intervals[i][0], right = intervals[i][1];
            int count = merged.Count;
            if (count == 0 || merged[count - 1][1] < left)
            {
                merged.Add(new int[]{left, right});
            }
            else
            {
                merged[count - 1][1] = Math.Max(merged[count - 1][1], right);
            }
        }

        return merged.ToArray();
    }
}

// 312 ms,  53.68%
// 33.3MB,  56.38%
