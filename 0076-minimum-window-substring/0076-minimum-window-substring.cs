public class Solution {
    public string MinWindow(string s, string t) {
        // Beginning index of the current window
        int begin = 0;
        // Ending index of the current window
        int end = 0;
        // Starting index of the minimum window found so far
        int head = 0;
        // Counter to track the number of characters remaining in t
        int counter = t.Length;
        // Minimum length of a valid window
        int minLen = int.MaxValue;
        // Array to count characters in t
        int[] charCounts = new int[256];

        foreach(char c in t){
            // Count occurrence of each character in t
            charCounts[c]++;
        }

        while(end < s.Length){
            // Decrease the count of the current character in the window
            charCounts[s[end]]--;

            if(charCounts[s[end]] >= 0){
                // Found a character in t
                counter--;
            }

            // Found a valid window
            while(counter == 0){
                if(end - begin < minLen){
                    // Update the minimum length
                    minLen = end - begin;
                    // Update the starting index of the minimum window
                    head = begin;
                }

                char leftChar = s[begin];
                // Increase the count of the leftmost character in the window
                charCounts[leftChar]++;

                if(charCounts[leftChar] > 0){
                    // Make the window invalid
                    counter++;
                }

                // Move the beginning index to the right
                begin++;
            }

            // Move the ending index to the right
            end++;
        }
        
        // Return the minimum window found, or an empty string if no valid window exists
        return minLen == int.MaxValue ? "" : s.Substring(head, minLen + 1);
    }
}