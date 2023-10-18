public class MedianFinder {
    PriorityQueue<int, int> minHeap = null;
    PriorityQueue<int, int> maxHeap = null;
    bool isEven = true;

    public MedianFinder() {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        if(isEven){
            maxHeap.Enqueue(num, -num);
            int v = maxHeap.Dequeue();
            minHeap.Enqueue(v, v);
        }
        else{
            minHeap.Enqueue(num, num);
            int v = minHeap.Dequeue();
            maxHeap.Enqueue(v, -v);
        }

        isEven = !isEven;
    }
    
    public double FindMedian() {
        if(isEven){
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
        else{
            return minHeap.Peek();
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

 /*
 
1. Create a class named `MedianFinder` to implement the solution for finding the median of a stream of numbers.

2. Define two priority queues, `minHeap` and `maxHeap`, to store numbers. The `minHeap` will store the larger half of the numbers, while the `maxHeap` will store the smaller half. The heaps are initialized as empty.

3. Initialize a boolean variable `isEven` to `true`. This variable will help determine whether the number of elements is even or odd.

4. Create a constructor for the `MedianFinder` class. In the constructor, initialize the `minHeap` and `maxHeap` as priority queues.

5. Define a method named `AddNum(int num)` to add a number to the stream:

   a. Check if `isEven` is `true`. If it is, this means the number of elements is even, so add the number to the `maxHeap`.

   b. To maintain the ordering of elements, enqueue the number into the `maxHeap` with its negative value. This effectively reverses the priority of the `maxHeap`. Dequeue the maximum value from the `maxHeap` and enqueue it into the `minHeap`.

   c. Set `isEven` to `false` to track that the number of elements is now odd.

   d. If `isEven` is `false`, add the number to the `minHeap` as it's an odd number of elements.

   e. Similarly, enqueue the minimum value from the `minHeap` into the `maxHeap`.

   f. Set `isEven` to `true` to track that the number of elements is now even.

6. Define a method named `FindMedian()` to find the median of the stream:

   a. Check if `isEven` is `true`. If it is, this means the number of elements is even.

   b. Calculate the median as the average of the maximum value in the `maxHeap` and the minimum value in the `minHeap`. Return the median as a double.

   c. If `isEven` is `false`, this means the number of elements is odd, so the median is the minimum value in the `minHeap`. Return this value as the median.

7. The `MedianFinder` class is now complete and can be instantiated to create a `MedianFinder` object. You can call the `AddNum` method to add numbers to the stream and the `FindMedian` method to find the median.

 */