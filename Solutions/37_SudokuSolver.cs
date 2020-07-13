/*(Hard)
Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy all of the following rules:

Each of the digits 1-9 must occur exactly once in each row.
Each of the digits 1-9 must occur exactly once in each column.
Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
Empty cells are indicated by the character '.'.

Note:

The given board contain only digits 1-9 and the character '.'.
You may assume that the given Sudoku puzzle will have a single unique solution.
The given board size is always 9x9.
*/

public class Solution {
    // solve sudoku
    readonly int n = 3;		// box size
    readonly int N = 9;     // row size

    int[][] rows;
    int[][] columns;
    int[][] boxes;

    char[][] board;

    bool sudokuSolved = false;

    public void InitAllVariable()
    {
        rows = new int[N][];
        columns = new int[N][];
        boxes = new int[N][];

        for(int i = 0; i < N; i++)
        {
            rows[i] = new int[N + 1];
            columns[i] = new int[N + 1];
            boxes[i] = new int[N + 1];
        }
    }

    public bool CouldPlace(int d, int row, int col)
    {
        // check if one could place a number d in (row, col) cell
        int idx = (row / n) * n + col / n;
        return rows[row][d] + columns[col][d] + boxes[idx][d] == 0;
    }

    public void PlaceNumber(int d, int row, int col)
    {
        // place a number d in (row, col) cell
        int idx = (row / n) * n + col / n;

        rows[row][d]++;
        columns[col][d]++;
        boxes[idx][d]++;
        board[row][col] = (char)(d + '0');
    }

    public void RemoveNumber(int d, int row, int col)
    {
        // remove a number shich didn't lead to a solution
        int idx = (row / n) * n + col / n;

        rows[row][d]--;
        columns[col][d]--;
        boxes[idx][d]--;
        board[row][col] = '.';
    }

    public void PlaceNextNumbers(int row, int col)
    {
        // call backtrack function in recursion to continue to place number till the moment we have a solution
        // if we're in the last cell that means we have the solution
        if((col == N-1) && (row == N-1))
        {
            sudokuSolved = true;
        }
        else
        {
            if(col == N-1)
            {
                Backtrack(row + 1, 0);
            }
            else
            {
                Backtrack(row, col + 1);
            }
        }
    }

    public void Backtrack(int row, int col)
    {
        // Backtracking
        if(board[row][col] == '.')
        {
            for(int d = 1; d < 10; d++)
            {
                if(CouldPlace(d, row, col))
                {
                    PlaceNumber(d, row, col);
                    PlaceNextNumbers(row, col);
                    if(!sudokuSolved)
                    {
                        RemoveNumber(d, row, col);
                    }
                }
            }
        }
        else
        {
            PlaceNextNumbers(row, col);
        }
    }

    public void SolveSudoku(char[][] board)
    {
        this.board = board;
        InitAllVariable();

        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                char num = board[i][j];
                if(num != '.')
                {
                    int d = num - '0';
                    PlaceNumber(d, i, j);
                }
            }
        }

        Backtrack(0, 0);
    }
}

// 356  ms,  34.72%
// 31.3 MB,  80.95%
