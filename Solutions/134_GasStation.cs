/*(Medium)
There are N gas stations along a circular route, where the amount of gas at station i is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). 
You begin the journey with an empty tank at one of the gas stations.

Return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1.

Note:

If there exists a solution, it is guaranteed to be unique.
Both input arrays are non-empty and have the same length.
Each element in the input arrays is a non-negative integer.
*/

public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) 
    {
        int length = gas.Length;
        int start = 0, end = length;
        int gasNum = 0;
        while(start != end)
        {
            if(gas[start] + gasNum >= cost[start])
            {
                gasNum = gas[start] + gasNum - cost[start];
                start ++;
            }
            else
            {
                end --;
                gasNum += gas[end] - cost[end];
            }
        }
        return (gasNum >= 0) ? (start == length ? 0 : start) : -1;
    }
}

// 116  ms,  56.32%
// 24.4 MB,  90.80%
