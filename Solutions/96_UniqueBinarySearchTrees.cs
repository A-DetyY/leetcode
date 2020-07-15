using System.Collections;

public class Solution {
    int[][] allInfo;

    public int GenerateBST(int min, int max)
    {
        if (min >= max)
        {
            return min == max ? 1 : 0;
        }

        if (allInfo[min][max] > 0)
        {
            return allInfo[min][max];
        }

        int num = 0;
        for (int i = min; i <= max; i++)
        {
            int left = GenerateBST(min, i - 1);
            int right = GenerateBST(i + 1, max);
            if (left > 0)
            {
                allInfo[min][i - 1] = left;
            }
            if (right > 0)
            {
                allInfo[i + 1][max] = right;
            }
            if(left > 0 && right > 0)
            {
                num += left * right;
            }
            else if(left > 0)
            {
                num += left;
            }
            else if(right > 0)
            {
                num += right;
            }
        }
        allInfo[min][max] = num;
        return num;
    }

    public int NumTrees(int n)
    {
        allInfo = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            allInfo[i] = new int[n + 1];
            for (int j = 0; j < n + 1; j++)
            {
                allInfo[i][j] = 0;
            }
        }
        int totalNum = GenerateBST(1, n);
        return totalNum;
    }
}

// 40   ms,  71.36%
// 14.6 MB,  13.28%
