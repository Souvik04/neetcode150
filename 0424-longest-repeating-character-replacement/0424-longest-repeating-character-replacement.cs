public class Solution {
    public int CharacterReplacement(string s, int k) {
        /*
            - keep a left pointer and loop through the string
            - keep incrementing the counts of each character in a map or int array
            - at every iteration check max char char count of any character in the current window
            - if the number of replacements needed exceeds the value of k then decerease/remove element from the map or int array (based on left index) and increment the left pointer by 1
                - this is done by checking: r - l + 1 - max > k
            - update longest as Max(longest, r - l + 1)
        */

        int longest = 0;
        int[] counts = new int[26];
        int l = 0;
        int max = 0;

        for(int r = 0; r < s.Length; r++){
            counts[s[r] - 'A']++;
            max = Math.Max(max, counts[s[r] - 'A']);

            if(r - l + 1 - max > k){
                counts[s[l] - 'A']--;
                l++;
            }

            longest = Math.Max(longest, r - l + 1);
        }

        return longest;
    }
}