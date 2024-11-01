public class Solution {
    public int[][] Merge(int[][] intervals) {
        // Step 1: Sort intervals by their start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = new List<int[]>();

        // Step 2: Iterate through the sorted intervals and merge
        foreach (var interval in intervals) {
            // If the merged list is empty or there's no overlap, add the interval
            if (merged.Count == 0 || merged[merged.Count - 1][1] < interval[0]) {
                merged.Add(interval);
            } else {
                // There is an overlap, merge the current interval with the last merged interval
                merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], interval[1]);
            }
        }

        // Step 3: Convert List<int[]> to int[][]
        return merged.ToArray();
    }
}

/*

Time complexity: O(nlogn)
Space complexity: O(1)

*/