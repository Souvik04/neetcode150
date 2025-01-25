public class Solution {
    Node[] nodes = null;
    public int[] FindRedundantConnection(int[][] edges) {
        nodes = new Node[edges.Length + 1];

        for(int i = 0; i <= edges.Length; i++){
            nodes[i] = new Node(i);
        }

        foreach(int[] edge in edges){
            if(Find(edge[0]) != Find(edge[1])){
                Union(edge[0], edge[1]);
            }
            else{
                return edge;
            }
        }

        return new int[2];
    }

    private int Find(int n){
        if(nodes[n].parent != n){
            nodes[n].parent = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY){
            return true;
        }

        if(nodes[rootX].rank > nodes[rootY].rank){
            nodes[rootY].parent = rootX;
        }
        else if(nodes[rootX].rank < nodes[rootY].rank){
            nodes[rootX].parent = rootY;
        }
        else{
            nodes[rootX].parent = rootY;
            nodes[rootY].rank++;
        }

        return false;
    }
}

public class Node{
    public int parent {get; set;}
    public int rank {get; set;}

    public Node(int parent){
        this.parent = parent;
        this.rank = 0;
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/