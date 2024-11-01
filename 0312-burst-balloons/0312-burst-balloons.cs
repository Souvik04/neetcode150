public class Solution {
    public int MaxCoins(int[] nums) {
        // Pad the nums array with 1s on both sides
        int n = nums.Length;
        int[] balloons = new int[n + 2];
        balloons[0] = 1;
        balloons[n + 1] = 1;
        for (int i = 0; i < n; i++) {
            balloons[i + 1] = nums[i];
        }

        // Create a DP array
        int[,] dp = new int[n + 2, n + 2];

        // Fill the DP table
        for (int len = 1; len <= n; len++) { // Length of the interval
            for (int left = 0; left <= n - len; left++) { // Left boundary
                int right = left + len + 1; // Right boundary
                for (int k = left + 1; k < right; k++) { // k is the last balloon to burst
                    dp[left, right] = Math.Max(dp[left, right], 
                        dp[left, k] + dp[k, right] + balloons[left] * balloons[k] * balloons[right]);
                }
            }
        }

        return dp[0, n + 1]; // The result for bursting all balloons
    }
}

/*

Time complexity: O(n^3)
Space complexity: O(n^2)

*/