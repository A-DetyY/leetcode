/*(Medium)
Given an m x n matrix, return all elements of the matrix in spiral order.
*/

public class Solution {
    public IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> order = new List<int>();
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            return order;
        int rows = matrix.Length, columns = matrix[0].Length;
        int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
        while (left <= right && top <= bottom)
        {
            for(int column = left; column<=right; column++)
                order.Add(matrix[top][column]);
            for(int row = top+1; row<=bottom; row++)
                order.Add(matrix[row][right]);
            if (left < right && top < bottom)
            {
                for(int column = right-1; column>left; column--)
                    order.Add(matrix[bottom][column]);
                for(int row = bottom; row>top; row--)
                    order.Add(matrix[row][left]);
            }

            left++;
            right--;
            top++;
            bottom--;
        }

        return order;
    }
}

// 276 ms,  73.53%
// 29.6MB,  41.04%
