public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (intervals.Length == 0) return 0;

        // Step 1: Sort the intervals by their end times
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int count = 0; // Count of non-overlapping intervals
        int end = intervals[0][1]; // End time of the last added interval

        // Step 2: Iterate through the sorted intervals
        for (int i = 1; i < intervals.Length; i++) {
            if (intervals[i][0] >= end) {
                // No overlap, so we can keep this interval
                end = intervals[i][1]; // Update the end time
                count++; // Increment count of non-overlapping intervals
            } else {
                // There is an overlap, so we count this interval for removal
                // No need to update the end time since we are removing this interval
            }
        }

        // The number of intervals to remove is total intervals minus the non-overlapping ones
        return intervals.Length - count - 1; // subtracting 1 because we started count from 0
    }
}

/*

Time complexity: O(nlogn)
Space complexity: O(1)

*/