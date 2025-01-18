public class Solution {
    public void WallsAndGates(int[][] rooms) {
        int m = rooms.Length;
        int n = rooms[0].Length;
        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

        // enqueue gates
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(rooms[i][j] == 0){
                    queue.Enqueue((i, j));
                }
            }
        }

        // perform BFS
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, -1, 0, 1};

        while(queue.Count > 0){
            var cur = queue.Dequeue();

            // explore neighbours
            for(int i = 0; i < 4; i++){
                int newX = cur.x + dr[i];
                int newY = cur.y + dc[i];

                // boundary conditions
                if(newX >= 0 && newX < m && newY >= 0 && newY < n && rooms[newX][newY] > rooms[cur.x][cur.y] + 1){
                    rooms[newX][newY] = rooms[cur.x][cur.y] + 1;
                    queue.Enqueue((newX, newY));
                }
            }
        }
    }
}

/*

1. iterate over the gates and enqueue to queue the coordinates
2. perform BFS, check neoghbours (newX, newY)
3. if rooms[newX][newY] > rooms[cur.x][cur.y] + 1, update distance and enqueue (newX, newY) to queue

Time complexity: O(m * n)
Space complexity: O(m * n)

*/