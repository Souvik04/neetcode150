public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        // Step 1: Sort intervals by their start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Step 2: Prepare a list of queries with their original indices
        var indexedQueries = new List<(int index, int value)>();
        for (int i = 0; i < queries.Length; i++) {
            indexedQueries.Add((i, queries[i]));
        }
        indexedQueries.Sort((a, b) => a.value.CompareTo(b.value));

        // Step 3: Min-heap to keep track of the intervals
        var minHeap = new SortedSet<(int length, int end)>();
        int intervalIndex = 0;
        int[] result = new int[queries.Length];

        for (int i = 0; i < indexedQueries.Count; i++) {
            int queryValue = indexedQueries[i].value;

            // Add all intervals that start before or at the query value
            while (intervalIndex < intervals.Length && intervals[intervalIndex][0] <= queryValue) {
                int start = intervals[intervalIndex][0];
                int end = intervals[intervalIndex][1];
                minHeap.Add((end - start + 1, end)); // Add interval length and end
                intervalIndex++;
            }

            // Remove intervals that cannot contain the current query
            while (minHeap.Count > 0 && minHeap.Min.end < queryValue) {
                minHeap.Remove(minHeap.Min);
            }

            // If the heap is not empty, the minimum length is the top of the heap
            result[indexedQueries[i].index] = minHeap.Count > 0 ? minHeap.Min.length : -1;
        }

        return result;
    }
}

/*

Time complexity: O(nlogn)
Space complexity: O(mlogm)

*/