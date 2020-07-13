/*(Hard)
Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
*/

public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        IList<int[]> resList = new List<int[]>();

        bool alreadyInsert = false;
        int startPos = 0, endPos = 0, len = intervals.Length;

        if (len == 0)
        {
            resList.Add(newInterval);
            alreadyInsert = true;
        }

        while (startPos < len)
        {
            if (intervals[startPos][1] < newInterval[0] || alreadyInsert)
            {
                resList.Add(intervals[startPos]);
            }
            else if(intervals[startPos][0] > newInterval[1])
            {
                resList.Add(newInterval);
                alreadyInsert = true;
                continue;
            }
            else
            {
                int[] tempArray = new int[2];
                tempArray[0] = intervals[startPos][0] < newInterval[0] ? intervals[startPos][0] : newInterval[0];
                tempArray[1] = intervals[startPos][1] > newInterval[1] ? intervals[startPos][1] : newInterval[1];
                for (int i = startPos + 1; i < len; i++)
                {
                    if (intervals[i][0] > tempArray[1])
                    {
                        break;
                    }
                    else
                    {
                        tempArray[1] = tempArray[1] > intervals[i][1] ? tempArray[1] : intervals[i][1];
                        endPos = i;
                    }
                }
                resList.Add(tempArray);
                alreadyInsert = true;
            }
            startPos = endPos + 1;
            endPos = startPos;
        }

        if (!alreadyInsert)
        {
            resList.Add(newInterval);
        }

        int[][] resArray = new int[resList.Count][];
        for (int i = 0; i < resList.Count; i++)
        {
            resArray[i] = resList[i];
        }

        return resArray;
    }
}

// 264  ms,  55.33%
// 33.5 MB,  45.20%
