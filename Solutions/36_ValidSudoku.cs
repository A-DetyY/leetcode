/*(Medium)
Determine if a 9 x 9 Sudoku board is valid. 
Only the filled cells need to be validated according to the following rules:

Each row must contain the digits 1-9 without repetition.
Each column must contain the digits 1-9 without repetition.
Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
Note:

A Sudoku board (partially filled) could be valid but is not necessarily solvable.
Only the filled cells need to be validated according to the mentioned rules.
*/

public class Solution {
    public bool IsValidSudoku(char[][] board)
    {
        Dictionary<int, int>[] rows = new Dictionary<int, int>[9];
        Dictionary<int, int>[] columns = new Dictionary<int, int>[9];
        Dictionary<int, int>[] boxes = new Dictionary<int, int>[9];
        for (int i = 0; i < 9; i++)
        {
            rows[i] = new Dictionary<int, int>();
            columns[i] = new Dictionary<int, int>();
            boxes[i] = new Dictionary<int, int>();
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                char num = board[i][j];
                if (num != '.')
                {
                    int n = num - '0';
                    int boxIdx = (i / 3) * 3 + j / 3;
                    int value = 0;
                    if (rows[i].TryGetValue(n, out value))
                        rows[i][n] = value + 1;
                    else
                        rows[i].Add(n, 1);

                    if (columns[j].TryGetValue(n, out value))
                        columns[j][n] = value + 1;
                    else
                        columns[j].Add(n, 1);

                    if (boxes[boxIdx].TryGetValue(n, out value))
                        boxes[boxIdx][n] = value + 1;
                    else
                        boxes[boxIdx].Add(n, 1);

                    if (rows[i][n] > 1 || columns[j][n] > 1 || boxes[boxIdx][n] > 1)
                        return false;
                }
            }
        }
        return true;
    }
}

// 124 ms,  89.11%
// 27.6MB,  28.87%
