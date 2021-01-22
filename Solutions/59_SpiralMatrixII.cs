/*(Medium)
Given a positive integer n, 
generate an n x n matrix filled with elements from 1 to n2 in spiral order.
*/

public class Solution {
    public int[][] GenerateMatrix(int n) {
        int left = 0, right = n - 1, top = 0, bottom = n - 1;
        int[][] matrix = new int[n][];
        int num = 1, target = n * n;
        for (int i = 0; i < n; i++)
            matrix[i] = new int[n];
        while (num <= target)
        {
            for (int i = left; i <= right; i++)
                matrix[top][i] = num++;
            top++;
            for (int i = top; i <= bottom; i++)
                matrix[i][right] = num++;
            right--;
            for (int i = right; i >= left; i--)
                matrix[bottom][i] = num++;
            bottom--;
            for (int i = bottom; i >= top; i--)
                matrix[i][left] = num++;
            left++;
        }

        return matrix;
    }
}

// 236 ms,  88.52%
// 25.8MB,  95.00%
