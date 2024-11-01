public class Solution {
    public int NumDistinct(string s, string t) {
        int m = t.Length, n = s.Length;
        if (m > n) return 0; // If t is longer than s, t can't be a subsequence of s
        
        int[,] dp = new int[m + 1, n + 1];

        // Initialize base case
        for (int j = 0; j <= n; j++) {
            dp[0, j] = 1; // An empty t can be formed from any prefix of s
        }

        // Fill the dp array
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (t[i - 1] == s[j - 1]) {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i, j - 1];
                } else {
                    dp[i, j] = dp[i, j - 1];
                }
            }
        }

        return dp[m, n];
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(m * n)

*/