public class Solution {
    public int Jump(int[] nums) {
        if (nums.Length <= 1) return 0; // No jumps needed for 0 or 1 element

        int jumps = 0; // Number of jumps made
        int currentEnd = 0; // Farthest index that can be reached with the current number of jumps
        int farthest = 0; // Farthest index that can be reached with the next jump

        for (int i = 0; i < nums.Length - 1; i++) {
            // Update the farthest index we can reach
            farthest = Math.Max(farthest, i + nums[i]);

            // If we have come to the end of the current jump range
            if (i == currentEnd) {
                jumps++; // We need to make a jump
                currentEnd = farthest; // Update the end for the next jump

                // If we can reach or exceed the last index
                if (currentEnd >= nums.Length - 1) {
                    break;
                }
            }
        }

        return jumps; // Return the total number of jumps made
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/