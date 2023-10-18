public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        /*
            1. Create a priority queue (min heap)
            2. iterate over the input array and insert each element in PQ
            3. during insertion check, if PQ count == k and top element value less than current element (array[i]) then dequeue the element
            4. return PQ.Peek()
        */

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int n in nums) {
            minHeap.Enqueue(n, n);
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}