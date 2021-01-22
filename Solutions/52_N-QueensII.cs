/*(Hard)
The n-queens puzzle is the problem of placing n queens on an n x n chessboard 
such that no two queens attack each other.

Given an integer n, return the number of distinct solutions to the n-queens puzzle.
*/

public class Solution {
    public bool CanPlace(int[][] grid, int x, int y, int n)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    if (i==x || j==y || (x-i==y-j) || (x-i==j-y))
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public void ArrayToString(int[][] grid, int n, IList<IList<string>> resList)
    {
        IList<string> tempList = new List<string>();

        for (int i = 0; i < n; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    sb.Append("Q");
                }
                else
                {
                    sb.Append(".");
                }
            }
            tempList.Add(sb.ToString());
        }
        resList.Add(tempList);
    }

    public void PlaceNext(int[][] grid, int x, int n, IList<IList<string>> resList)
    {
        if (x == n)
        {
            // N皇后都被正确放置
            ArrayToString(grid, n, resList);
            return;
        }

        for (int j = 0; j < n; j++)
        {
            if (CanPlace(grid, x, j, n))
            {
                grid[x][j] = 1;
                PlaceNext(grid, x + 1, n, resList);
                grid[x][j] = 0;
            }
        }
    }

    public IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> resList = new List<IList<string>>();
        int[][] grid = new int[n][];
        for (int i = 0; i < n; i++)
        {
            grid[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                grid[i][j] = 0;
            }
        }

        // 放置第一个皇后
        PlaceNext(grid, 0, n, resList);

        return resList;
    }

    public int TotalNQueens(int n) {
        IList<IList<string>> resList = SolveNQueens(n);
        return resList.Count;
    }
}

// 44  ms,  93.89%
// 15.8MB,  27.69%
