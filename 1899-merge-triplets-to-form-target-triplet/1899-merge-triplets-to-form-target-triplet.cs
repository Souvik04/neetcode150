using System;
using System.Collections.Generic;

public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        int max1 = 0, max2 = 0, max3 = 0; // Initialize maximums for each coordinate
        
        foreach (var triplet in triplets) {
            // Check if the current triplet can contribute to the target
            if (triplet[0] > target[0] || triplet[1] > target[1] || triplet[2] > target[2]) {
                continue; // Skip if any value exceeds the target
            }
            // Update the maximum values
            max1 = Math.Max(max1, triplet[0]);
            max2 = Math.Max(max2, triplet[1]);
            max3 = Math.Max(max3, triplet[2]);
        }
        
        // Check if the maximums match the target triplet
        return max1 == target[0] && max2 == target[1] && max3 == target[2];
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/