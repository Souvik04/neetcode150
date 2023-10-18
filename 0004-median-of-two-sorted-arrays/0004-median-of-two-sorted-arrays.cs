public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // Get the lengths of nums1 and nums2, handling null arrays
        int x = nums1?.Length ?? 0;
        int y = nums2?.Length ?? 0;

        // Ensure that nums1 is the shorter array
        if (x > y)
            return FindMedianSortedArrays(nums2, nums1);

        // Initialize variables for binary search
        int start = 0;
        int end = Math.Min(x, y);

        // Variables for partition and elements
        int partitionX, partitionY;
        int maxLeftX, maxLeftY, minRightX, minRightY;

        while (start <= end) {
            // Calculate the partition positions
            partitionX = (start + end) / 2;
            partitionY = (x + y + 1) / 2 - partitionX;

            // Find the elements on the left and right sides of the partitions
            maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            minRightX = partitionX == x ? int.MaxValue : nums1[partitionX];
            minRightY = partitionY == y ? int.MaxValue : nums2[partitionY];

            // Check if the partitions are correct
            if (maxLeftX <= minRightY && maxLeftY <= minRightX) {
                // Check if the total number of elements is even or odd
                if ((x + y) % 2 == 0)
                    return (double)(Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                else
                    return Math.Max(maxLeftX, maxLeftY);
            }
            else if (maxLeftX > minRightY) {
                // Adjust the partition positions and continue the binary search
                end = partitionX - 1;
            }
            else {
                // Adjust the partition positions and continue the binary search
                start = partitionX + 1;
            }
        }

        return 0.0; // Default return value if arrays are empty 
    }
}
