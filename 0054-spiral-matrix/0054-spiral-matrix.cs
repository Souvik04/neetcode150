public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> result = new List<int>();
        
        if (matrix.Length == 0 || matrix[0].Length == 0) {
            return result; // Return an empty list if the matrix is empty
        }

        int top = 0;
        int bottom = matrix.Length - 1;
        int left = 0;
        int right = matrix[0].Length - 1;

        while (top <= bottom && left <= right) {
            // Traverse from left to right
            for (int i = left; i <= right; i++) {
                result.Add(matrix[top][i]);
            }
            top++; // Move the top boundary down

            // Traverse from top to bottom
            for (int i = top; i <= bottom; i++) {
                result.Add(matrix[i][right]);
            }
            right--; // Move the right boundary left

            // Check if we still have rows to traverse
            if (top <= bottom) {
                // Traverse from right to left
                for (int i = right; i >= left; i--) {
                    result.Add(matrix[bottom][i]);
                }
                bottom--; // Move the bottom boundary up
            }

            // Check if we still have columns to traverse
            if (left <= right) {
                // Traverse from bottom to top
                for (int i = bottom; i >= top; i--) {
                    result.Add(matrix[i][left]);
                }
                left++; // Move the left boundary right
            }
        }

        return result;
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(1)

*/
