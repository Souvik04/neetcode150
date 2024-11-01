public class Solution {
    private int[][] directions = new int[][] {
        new int[] { 0, 1 }, new int[] { 1, 0 },
        new int[] { 0, -1 }, new int[] { -1, 0 }
    };
    
    public int LongestIncreasingPath(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[,] memo = new int[rows, cols];
        int longestPath = 0;
        
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                longestPath = Math.Max(longestPath, DFS(matrix, i, j, memo));
            }
        }
        
        return longestPath;
    }
    
    private int DFS(int[][] matrix, int row, int col, int[,] memo) {
        if (memo[row, col] != 0) {
            return memo[row, col];
        }
        
        int maxLength = 1;
        foreach (var direction in directions) {
            int newRow = row + direction[0];
            int newCol = col + direction[1];
            if (newRow >= 0 && newRow < matrix.Length &&
                newCol >= 0 && newCol < matrix[0].Length &&
                matrix[newRow][newCol] > matrix[row][col]) {
                maxLength = Math.Max(maxLength, 1 + DFS(matrix, newRow, newCol, memo));
            }
        }
        
        memo[row, col] = maxLength;
        return maxLength;
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(m * n)

*/