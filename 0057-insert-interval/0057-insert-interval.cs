public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> result = new List<int[]>();
        int i = 0;
        
        // Step 1: Add all intervals that come before the new interval
        while (i < intervals.Length && intervals[i][1] < newInterval[0]) {
            result.Add(intervals[i]);
            i++;
        }
        
        // Step 2: Merge overlapping intervals
        while (i < intervals.Length && intervals[i][0] <= newInterval[1]) {
            // Update the newInterval to merge with the current interval
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }
        
        // Add the merged interval
        result.Add(newInterval);
        
        // Step 3: Add remaining intervals
        while (i < intervals.Length) {
            result.Add(intervals[i]);
            i++;
        }
        
        return result.ToArray();
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/
