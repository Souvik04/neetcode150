public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach(int n in nums){
            minHeap.Enqueue(n, n);

            if(minHeap.Count > k){
                minHeap.Dequeue();
            }
        }

        return minHeap.Dequeue();
    }
}

/*

1. create a min-heap to store the nums
2. iterate over nums and enqueue them in min-heap
3. if queue count > k dequeue
4. return queue.dequeue();

Time complexity: O(logn)
Space complexity: O(n)

*/