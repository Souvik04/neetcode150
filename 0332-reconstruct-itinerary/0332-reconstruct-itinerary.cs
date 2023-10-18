public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        /*
            1. create a map <string, PriorityQueue<string, string>> to represent the adjacency list
            2. create a queue<string> and enqueue the starting airport "JFK"
            3. while queue is not empty perform DFS
            4. in DFS, check if current airport (current) is in map and if it has any adjacent items
            5. while count of adjacency items not 0, dequeue each item from priority queue nad push to call DFS for dequeued item
            priority queue
            5. push the current airport (current) to stack
            6. return stack.ToList() as output at the end
        */

        Stack<string> output = new Stack<string>();
        Dictionary<string, PriorityQueue<string, string>> map = new Dictionary<string, PriorityQueue<string, string>>();

        foreach(var t in tickets){
            if(!map.ContainsKey(t[0])){
                map.Add(t[0], new PriorityQueue<string, string>());
            }

            map[t[0]].Enqueue(t[1], t[1]);
        }

        DFS("JFK", map, output);

        return output.ToList();
    }

    private void DFS(string current, Dictionary<string, PriorityQueue<string, string>> map, Stack<string> stack){
        if(map.ContainsKey(current)){
            var tempList = map[current];

            while(tempList.Count > 0){
                string temp = tempList.Dequeue();
                DFS(temp, map, stack);
            }
        }

        stack.Push(current);
    }
}