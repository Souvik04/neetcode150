public class Solution {
    public bool Exist(char[][] board, string word) {
        // Iterate through each cell on the board
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                // If a valid path for the word is found, return true
                if(DFS(board, word, i, j, 0)){
                    return true;
                }
            }
        }

        // If no valid path is found, return false
        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int idx){
        // If the current index matches the length of the word, we've found a valid path
        if(idx == word.Length){
            return true;
        }

        // Check boundary conditions to avoid going out of bounds
        if(r < 0 || r >= board.Length || c < 0 || c >= board[0].Length){
            return false;
        }

        // If the current cell does not match the corresponding character in the word, it's not a valid path
        if(board[r][c] != word[idx]){
            return false;
        }

        // Temporarily mark the current cell as visited
        char temp = board[r][c];
        board[r][c] = '*';

        // Define the possible directions: down, right, up, left
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, 1, 0, -1};

        bool val = false;

        // Explore each direction recursively to find a valid path
        for(int i = 0; i < 4; i++){
            val = val || DFS(board, word, dr[i] + r, dc[i] + c, idx + 1);
        }

        // Restore the original value of the cell
        board[r][c] = temp;

        // Return whether a valid path was found
        return val;
    }
}
