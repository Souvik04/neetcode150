public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // Hash cur + row + i   5row0
        // Hash cur + col + j   8col4
        // Hash cur + s + (i / 3) + : + (j / 3)  5s0:0

        HashSet<string> set = new HashSet<string>();

        // loop
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                char cur = board[i][j];

                // check 3 conditions
                if(cur != '.'){
                    if(!set.Add(cur + "r" + i) ||
                    !set.Add(cur + "c" + j) ||
                    !set.Add(cur + "s" + (i/3) + ":" + (j/3))){
                        return false;
                    }
                }
            }
        }

        return true;
    }
}