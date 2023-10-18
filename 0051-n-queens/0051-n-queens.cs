public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        IList<IList<string>> output = new List<IList<string>>();
        char[][] board = new char[n][];
        InitBoard(board);
        Backtrack(n, board, output, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), 0);
        return output;
    }

    private void Backtrack(int n, char[][] board, IList<IList<string>> output, HashSet<int> col, HashSet<int> posDiag, HashSet<int> negDiag, int r){
        // add board to output if row pos met board length
        if(r == n){
            List<string> rowToAdd = new List<string>();
            foreach(var row in board){
                rowToAdd.Add(new string(row));
            }

            output.Add(rowToAdd.ToList());
            return;
        }

        // iterate over columns in board
        for(int c = 0; c < n; c++){
            if(col.Contains(c) || posDiag.Contains(r + c) || negDiag.Contains(r - c)){
                continue;
            }

            col.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            Backtrack(n, board, output, col, posDiag, negDiag, r + 1);

            col.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }

    private void InitBoard(char[][] board){
        for(int i = 0; i < board.Length; i++){
            board[i] = new char[board.Length];

            for(int j = 0; j < board[0].Length; j++){
                board[i][j] = '.';
            }
        }
    }
}

/*

1. Create a class named `Solution` to implement the solution for finding all distinct solutions to the N-Queens problem.

2. Define a method named `SolveNQueens` that takes an integer `n` as input and returns a list of lists of strings representing the solutions.

3. Initialize an empty list of lists of strings named `output` to store the solutions.

4. Create a 2D character array named `board` of size `n x n` to represent the chessboard. Initialize the board using the `InitBoard` method.

5. Call the `Backtrack` method to find solutions, passing `n`, `board`, `output`, and three hash sets `col`, `posDiag`, and `negDiag`. These hash sets will be used to keep track of occupied columns, positive diagonals, and negative diagonals.

6. Implement the `Backtrack` method:

   a. Check if the current row `r` is equal to `n`. If it is, this means that a valid solution has been found. Create a list of strings `rowToAdd` to store the solution for this board configuration.

   b. Iterate through the rows in the `board` array, convert each row to a string, and add it to `rowToAdd`.

   c. Add `rowToAdd` to the `output` list, representing a valid N-Queens solution.

   d. Return from the method to explore other possible solutions.

   e. If the current row `r` is not equal to `n`, iterate over the columns `c` in the board:

      - Check if the column `c` is in the `col` set or if the positive diagonal `r + c` or the negative diagonal `r - c` is in the corresponding sets `posDiag` and `negDiag`. If any of these conditions are met, skip this column `c` and continue to the next one.

      - If the column `c` is not in `col` and both positive and negative diagonals are not in the corresponding sets, mark this position on the board with a 'Q', indicating the placement of a queen.

      - Recursively call the `Backtrack` method for the next row, incrementing `r` by 1.

      - After the recursive call, backtrack by removing the queen from the current position, reset the state, and continue with the next column by removing `c` from `col`, `r + c` from `posDiag`, and `r - c` from `negDiag`.

7. Define a helper method named `InitBoard` that initializes the `board` by filling it with periods ('.') to represent empty spaces.

8. The `SolveNQueens` method returns the `output`, which contains all the distinct solutions for the N-Queens problem.

*/