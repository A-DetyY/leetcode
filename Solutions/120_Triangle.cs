/*(Medium)
Given a triangle, find the minimum path sum from top to bottom. 
Each step you may move to adjacent numbers on the row below.

For example, given the following triangle

[
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3]
]
The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

Note:

Bonus point if you are able to do this using only O(n) extra space, 
where n is the total number of rows in the triangle.
*/

using System.Collections.Generic;

public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) 
    {
        if(triangle.Count == 0)
        {
            return 0;
        }

        IList<int> calList = new List<int>();
        for(int i=0; i<triangle.Count; i++)
        {
            IList<int> rowList = triangle[i];
            IList<int> tempList = new List<int>();
            for(int j=0; j<rowList.Count; j++)
            {
                if(i == 0)
                {
                    tempList.Add(rowList[j]);
                }
                else if(j == 0)
                {
                    tempList.Add(calList[j] + rowList[j]);
                }
                else if(j == rowList.Count - 1)
                {
                    tempList.Add(calList[j-1] + rowList[j]);
                }
                else
                {
                    int val1 = (calList[j-1] < calList[j]) ? calList[j-1] : calList[j];
                    tempList.Add(val1 + rowList[j]);
                }
            }
            calList = tempList;
        }
        int minValue = calList[0];
        for(int i=1; i<calList.Count; i++)
        {
            if(calList[i] < minValue)
            {
                minValue = calList[i];
            }
        }

        return minValue;
    }
}

// 96  ms,  96.05%
// 25  MB,  40.00%
