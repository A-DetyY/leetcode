/*(Medium)
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

*/

public class Solution {
    public void SearchIsland(char[][] grid, bool[][] alreadySearch, int x, int y)
    {
        if (x < 0 || y < 0 || x > grid.Length - 1 || y > grid[0].Length - 1 || alreadySearch[x][y])
        {
            return;
        }

        alreadySearch[x][y] = true;
        if (grid[x][y] == '1')
        {
            // 上下左右四个方向查询
            SearchIsland(grid, alreadySearch, x - 1, y);
            SearchIsland(grid, alreadySearch, x + 1, y);
            SearchIsland(grid, alreadySearch, x, y - 1);
            SearchIsland(grid, alreadySearch, x, y + 1);
        }
    }

    public int NumIslands(char[][] grid)
    {
        int row = grid.Length;
        if (row == 0)
        {
            return 0;
        }
        int column = grid[0].Length;
        int islandNum = 0;
        bool[][] alreadySearch = new bool[row][];

        // 初始化
        for (int i = 0; i < row; i++)
        {
            alreadySearch[i] = new bool[column];
            for (int j = 0; j < column; j++)
            {
                alreadySearch[i][j] = false;
            }
        }

        // 深度优先DFS
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (alreadySearch[i][j] == false && grid[i][j] ==  '1')
                {
                    SearchIsland(grid, alreadySearch, i, j);
                    islandNum++;
                }
            }
        }

        return islandNum;
    }
}

// 136  ms,  33.00%
// 27.8 MB,  56.69%
