public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        IList<int[]> output = new List<int[]>();
        PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();

        foreach(var p in points){
            int d = p[0] * p[0] + p[1] * p[1];
            pq.Enqueue(p, d);
        }

        for(int i = 0; i < k; i++){
            output.Add(pq.Dequeue());
        }

        return output.ToArray();
    }
}