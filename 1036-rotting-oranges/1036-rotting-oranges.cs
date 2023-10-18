public class Solution {
    public int OrangesRotting(int[][] grid) {
        /*
            1. iterate over the matrix to get initial count of fresh oranges
            2. pick the rotten oranges and enqueue the coordinates into queue
            3. Dequeue from queue and perform BFS and increment the minute counter
            4. return the minute if no fresh oranges left or return -1
        */

        int minutes = 0;
        int freshOranges = 0;
        Queue<int[]> queue = new Queue<int[]>();        

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                // count initial fresh oranges
                if(grid[i][j] == 1){
                    freshOranges++;
                }
                // enqueue initial rotten oranges
                else if(grid[i][j] == 2){
                    queue.Enqueue(new int[2]{i, j});
                }
            }
        }

        if(freshOranges == 0){
            return 0;
        }

        // perform BFS
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, 1, 0, -1};

        while(queue.Count > 0){
            minutes++;
            int count = queue.Count;

            for(int i = 0; i < count; i++){
                int[] cur = queue.Dequeue();
                
                for(int d = 0; d < 4; d++){
                    int row = cur[0] + dr[d];
                    int col = cur[1] + dc[d];

                    // check boundary conditions and if fresh orange
                    if(row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length && grid[row][col] == 1){
                        grid[row][col] = 2;
                        queue.Enqueue(new int[2]{row, col});
                        freshOranges--;
                    }
                }
            }
        }
        
        return freshOranges == 0 ? minutes - 1 : -1;        
    }
}