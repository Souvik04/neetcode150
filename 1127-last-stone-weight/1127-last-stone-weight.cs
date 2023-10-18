public class Solution {
    public int LastStoneWeight(int[] stones) {
        /*
            1. insert all the  stone weights into a priority queue in the order where the highest weight stays on top
            2. While the priority queue has elements, dequeue 2 elements and check the difference in their weight
            3. if both has same weight, then just ignore them after dequeue but if they have a differene, enqueue the difference in weight back to the priority queue
            4. repeat this until a single stone weight is present in the priority queue
        */

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach(int s in stones){
            maxHeap.Enqueue(s, s * -1);
        }

        while(maxHeap.Count > 1){
            int a = maxHeap.Dequeue();
            int b = maxHeap.Dequeue();

            if((a - b) > 0){
                maxHeap.Enqueue(a - b, (a - b) * -1);
            }
        }

        return maxHeap.Count > 0 ? maxHeap.Dequeue() : 0;
    }
}