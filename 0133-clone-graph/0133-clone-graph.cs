/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<Node, Node> map = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        if(node == null){
            return null;
        }

        if(!map.ContainsKey(node)){
            map.Add(node, new Node(node.val));

            foreach(var n in node.neighbors){
                map[node].neighbors.Add(CloneGraph(n));
            }
        }

        return map[node];
    }
}

/*

1. Begin by creating a class named `Solution` to implement the solution for cloning a graph.

2. Define a dictionary named `map` that will be used to map the original nodes to their corresponding cloned nodes. This dictionary is used to keep track of nodes that have already been cloned to avoid infinite recursion.

3. Create a method named `CloneGraph` that takes a single parameter `node`, which is the starting node of the original graph. The goal is to clone the entire graph and return the corresponding starting node of the cloned graph.

4. Check if the input `node` is null. If it is, return `null` because there is no graph to clone.

5. Within the `CloneGraph` method, implement the graph cloning process:

   a. Check if the `map` dictionary does not contain the current `node`. If it doesn't, this means that the node has not been cloned yet. In this case, create a new node with the same value as the original node (using `node.val`) and add it to the `map` dictionary, mapping the original node to its clone.

   b. Iterate over the neighbors of the current `node` using a `foreach` loop. For each neighbor `n`, call the `CloneGraph` method recursively on `n` to clone the neighbor node. Add the cloned neighbor to the `neighbors` list of the current cloned node (i.e., `map[node]`). This ensures that the cloned graph maintains the same structure as the original graph.

6. Finally, return the cloned starting node, which can be accessed from the `map` dictionary using the original `node` as the key (i.e., `map[node]`).

*/