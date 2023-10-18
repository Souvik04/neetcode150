public class Solution {
    public int NumIslands(char[][] grid) {
        int output = 0;

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == '1'){
                    DFS(grid, i, j);
                    output++;
                }
            }
        }

        return output;
    }

    private void DFS(char[][] grid, int r, int c){
        // check boundary conditions
        if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '0'){
            return;
        }

        // mark current visited cell as 0
        grid[r][c] = '0';

        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, 1, 0, -1};

        // DFS in all four directions
        for(int i = 0; i < 4; i++){
            DFS(grid, r + dr[i], c);
            DFS(grid, r, c + dc[i]);
        }
    }
}