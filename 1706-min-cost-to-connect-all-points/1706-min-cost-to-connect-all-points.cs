public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        /*
            1. create adjacency list: Dictionary<int, Tuple<int, int>> : point1, (point1, dist)]
            2. create priority queue (min-heap): PriorityQueue<Tuple<int, int>>, int>
            3. create visited set to store points visited
            4. iterate from i: 0 to n - 1 and inner loop j: i + 1 to n - 1 and calculate manhattan distance
            5. store the mahattan distance in the adjacency list for point i to j and j to i
            6. enqueue, (0, 0), 0 to priority queue
            7. while queue not empty, dequeue and and check if visited, then continue
            9. else add cost to output and mark as visited
            10. perform BFS and enqueue points and cost into queue
        */

        Dictionary<int, IList<Tuple<int, int>>> map = new Dictionary<int, IList<Tuple<int, int>>>();
        HashSet<int> visited = new HashSet<int>();
        PriorityQueue<Tuple<int, int>, int> minHeap = new PriorityQueue<Tuple<int, int>, int>();

        int output = 0;

        int n = points.Length;

        if(n == 0){
            return 0;
        }

        for(int i = 0; i < n; i++){
            map.Add(i, new List<Tuple<int, int>>());
        }

        for(int i = 0; i < n; i++){
            int x1 = points[i][0];
            int y1 = points[i][1];

            for(int j = i; j < n; j++){
                int x2 = points[j][0];
                int y2 = points[j][1];

                int dist = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                
                map[j].Add(new Tuple<int, int>(i, dist));
                map[i].Add(new Tuple<int, int>(j, dist));
            }
        }

        minHeap.Enqueue(new Tuple<int, int>(0, 0), 0);

        while(minHeap.Count > 0){
            Tuple<int, int> cur = minHeap.Dequeue();

            if(visited.Contains(cur.Item1)){
                continue;
            }

            visited.Add(cur.Item1);
            output += cur.Item2;

            foreach(var p in map[cur.Item1]){
                if(!visited.Contains(p.Item1)){
                    minHeap.Enqueue(new Tuple<int, int>(p.Item1, p.Item2), p.Item2);
                }
            }
        }

        return output;
    }
}