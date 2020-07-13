/*(Medium)
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

Example:

board =
[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]

Given word = "ABCCED", return true.
Given word = "SEE", return true.
Given word = "ABCB", return false.
 

Constraints:

board and word consists only of lowercase and uppercase English letters.
1 <= board.length <= 200
1 <= board[i].length <= 200
1 <= word.length <= 10^3
*/

public class Solution {
    public bool SearchGrid(char[][] board, string word, int m, int n, int pos, int i, int j, bool[][] visit)
    {
        if (pos == word.Length)
        {
            return true;
        }
        if (i<0 || i>=m || j<0|| j>=n || visit[i][j]==true)
        {
            return false;
        }
        if(board[i][j] == word[pos])
        {
            visit[i][j] = true;
            if(SearchGrid(board, word, m, n, pos+1, i-1, j, visit) ||
                SearchGrid(board, word, m, n, pos+1, i+1, j, visit) ||
                SearchGrid(board, word, m, n, pos+1, i, j-1, visit) ||
                SearchGrid(board, word, m, n, pos+1, i, j+1, visit))
            {
                return true;
            }
            visit[i][j] = false;
        }
        return false;
    }

    public bool Exist(char[][] board, string word)
    {
        int m = board.Length;
        if(m == 0)
        {
            return false;
        }
        int n = board[0].Length;
        bool[][] visit = new bool[m][];
        for(int i=0; i<m; i++)
        {
            visit[i] = new bool[n];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (SearchGrid(board, word, m, n, 0, i, j, visit))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

// 164  ms,  42.50%
// 28.8 MB,  70.77%
