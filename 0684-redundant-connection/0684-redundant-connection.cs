public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        /*
            1. create adjacency list (n + 1, as 1 based nodes)
            2. create a visited array (n + 1, as 1 based nodes)
            3. iterate over each edges list and perform DFS
            4. mark destination node as visited in DFS
            5. if any node has already been visited, return true, else false
            6. return the edge for which DFS returns true or return empty array
        */

        IList<int>[] adjacencyList = new List<int>[edges.Length + 1];
        
        foreach(var e in edges){
            if(adjacencyList[e[0]] == null){
                adjacencyList[e[0]] = new List<int>();
            }

            adjacencyList[e[0]].Add(e[1]);

            if(adjacencyList[e[1]] == null){
                adjacencyList[e[1]] = new List<int>();
            }

            adjacencyList[e[1]].Add(e[0]);

            // reset visited array before DFS
            bool[] visited = new bool[edges.Length + 1];
            
            if(DFS(adjacencyList, visited, e[1], e[0])){
                return e;
            }
        }

        return new int[0];
    }

    private bool DFS(IList<int>[] adjacencyList, bool[] visited, int destination, int source){
        if(visited[destination]){
            return true;
        }

        visited[destination] = true;

        foreach(int node in adjacencyList[destination]){
            if(source != node && DFS(adjacencyList, visited, node, destination)){
                return true;
            }
        }

        return false;
    }
}