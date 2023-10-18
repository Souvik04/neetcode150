public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
        HashSet<int> visited = new HashSet<int>();

        for(int i = 0; i < numCourses; i++){
            map.Add(i, new List<int>());
        }

        // add dependencies
        foreach(var p in prerequisites){
            map[p[0]].Add(p[1]);
        }

        for(int i = 0; i < numCourses; i++){
            if(!DFS(map, visited, i)){
                return false;
            }
        }

        return true;
    }

    private bool DFS(Dictionary<int, IList<int>> map, HashSet<int> visited, int c){
        if(visited.Contains(c)){
            return false;
        }

        // condition for topological sort (node with no dependencies)
        if(map[c].Count == 0){
            return true;
        }

        visited.Add(c);

        foreach(var course in map[c]){
            if(!DFS(map, visited, course)){
                return false;
            }
        }

        visited.Remove(c);
        map[c] = new List<int>();
        return true;
    }
}