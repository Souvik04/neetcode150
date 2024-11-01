public class Solution {
    public bool CheckValidString(string s) {
        int open = 0; // Count of open parentheses
        int close = 0; // Count of close parentheses
        
        // First pass: Count open and close parentheses
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                open++;
            } else if (s[i] == ')') {
                close++;
            } else { // s[i] == '*'
                open++; // Treat '*' as '('
            }
            
            // If we have more closing than opening, it's invalid
            if (close > open) {
                return false;
            }
        }
        
        // Reset counts for the second pass
        open = 0;
        close = 0;

        // Second pass: Count open and close parentheses from the end
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == ')') {
                close++;
            } else if (s[i] == '(') {
                open++;
            } else { // s[i] == '*'
                close++; // Treat '*' as ')'
            }

            // If we have more opening than closing, it's invalid
            if (open > close) {
                return false;
            }
        }

        return true; // If neither pass fails, it's valid
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/