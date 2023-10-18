public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int output = 0;
        IList<(int node, int weight)>[] adjList = new List<(int node, int weight)>[n + 1];
        HashSet<int> visited = new HashSet<int>();

        for(int i = 0; i <= n; i++){
            adjList[i] = new List<(int node, int weight)>();
        }

        foreach(var t in times){
            int source = t[0];
            int destination = t[1];
            int cost = t[2];

            adjList[source].Add((destination, cost));
        }

        PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>();

        pQueue.Enqueue(k, 0);

        while(pQueue.TryDequeue(out int node, out int weight)){
            if(visited.Contains(node)){
                continue;
            }

            visited.Add(node);

            output = Math.Max(output, weight);

            foreach(var adj in adjList[node]){
                int totalWeight = weight + adj.weight;
                pQueue.Enqueue(adj.node, totalWeight);
            }
        }

        return visited.Count == n ? output : -1;
    }
}

/*

1. Create a class named `Solution` to implement the solution for calculating network delay time.

2. Define a method named `NetworkDelayTime` that takes three parameters: `times`, `n`, and `k`. `times` is a list of time intervals between nodes, `n` is the total number of nodes, and `k` is the source node from which we want to calculate the network delay time.

3. Initialize an integer variable `output` to 0. This variable will store the network delay time.

4. Create an array of lists named `adjList` of size `n + 1` to represent the adjacency list of the graph. Each list will store tuples containing the destination node and the corresponding time interval. Initialize it as an empty list for each node.

5. Initialize a `HashSet` named `visited` to keep track of nodes that have been visited during traversal.

6. Initialize the adjacency list `adjList` by iterating through the `times` array. For each time interval in `times`, extract the source node, destination node, and the time interval. Add a tuple containing the destination node and time interval to the `adjList` at the index of the source node.

7. Create a priority queue (min-heap) named `pQueue` to keep track of nodes that need to be explored during the traversal. Enqueue the source node `k` with a weight of 0 into the `pQueue`.

8. Start a loop that continues as long as there are elements in the `pQueue`. The loop will explore nodes in order of increasing time interval.

9. Inside the loop, use `TryDequeue` to remove the node with the smallest weight from the `pQueue`. If the node has already been visited, skip it and continue to the next iteration.

10. Mark the current node as visited by adding it to the `visited` set.

11. Update the `output` by taking the maximum of its current value and the weight of the current node. This ensures that `output` will represent the maximum time interval encountered during traversal.

12. Iterate through the neighbors of the current node from the `adjList`. For each neighbor, calculate the total time interval by adding the weight of the current node to the time interval of the neighbor.

13. Enqueue the neighbor node and its total time interval into the `pQueue`.

14. After the loop finishes, check if the number of nodes visited is equal to `n`, which means all nodes have been visited. If they have, return the calculated `output` as the network delay time. If not, return -1, indicating that it was not possible to reach all nodes from the source node.

*/