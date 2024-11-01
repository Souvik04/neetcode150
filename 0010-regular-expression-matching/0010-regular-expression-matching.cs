public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length, n = p.Length;
        bool[,] dp = new bool[m + 1, n + 1];

        // Base case: empty string and empty pattern match
        dp[0, 0] = true;

        // Handle patterns like a*, a*b*, a*b*c* that can match an empty string
        for (int j = 1; j <= n; j++) {
            if (p[j - 1] == '*') {
                dp[0, j] = dp[0, j - 2];
            }
        }

        // Fill the DP table
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                // Match current characters or if current pattern is '.' 
                if (p[j - 1] == s[i - 1] || p[j - 1] == '.') {
                    dp[i, j] = dp[i - 1, j - 1];
                } 
                // Handle '*' character
                else if (p[j - 1] == '*') {
                    // Zero occurrence of the character before '*'
                    dp[i, j] = dp[i, j - 2];
                    // One or more occurrences
                    if (p[j - 2] == s[i - 1] || p[j - 2] == '.') {
                        dp[i, j] = dp[i, j] || dp[i - 1, j];
                    }
                }
            }
        }

        return dp[m, n]; // Result: if the whole string matches the whole pattern
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(m * n)

*/