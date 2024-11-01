public class Solution {
    public bool CanJump(int[] nums) {
        int farthest = 0; // The farthest index we can reach
        
        for (int i = 0; i < nums.Length; i++) {
            if (i > farthest) {
                // If we cannot reach index i
                return false;
            }
            // Update the farthest index we can reach
            farthest = Math.Max(farthest, i + nums[i]);
            // If we can reach or exceed the last index
            if (farthest >= nums.Length - 1) {
                return true;
            }
        }
        
        return false; // Return false if we exit the loop without reaching the last index
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/