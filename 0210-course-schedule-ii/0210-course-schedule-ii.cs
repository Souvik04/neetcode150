public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        IList<int> output = new List<int>();
        Queue<int> queue = new Queue<int>();
        IList<int>[] adjacencyList = new List<int>[numCourses];
        int[] inDegrees = new int[numCourses];

        // create adjacency list
        for(int i = 0; i < numCourses; i++){
            adjacencyList[i] = new List<int>();
        }

        // reverse the dependencies
        foreach(var p in prerequisites){
            adjacencyList[p[1]].Add(p[0]);
            inDegrees[p[0]]++;
        }

        for(int i = 0; i < numCourses; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int cur = queue.Dequeue();
            output.Add(cur);

            foreach(var c in adjacencyList[cur]){
                inDegrees[c]--;
                if(inDegrees[c] == 0){
                    queue.Enqueue(c);
                }
            }
        }

        if(output.Count == numCourses){
            return output.ToArray();
        }

        return new int[0];
    }
}