public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        /*
            - create 2 maps to store frequencies of s1 and s2
            - iterate s1 and store frequencies in first map
            - initialize to pointer l and r, starting at 0
            - iterate r till s length
            - store frequencies in second map for s2\
            - check if current window size reached s1 length and return true if both maps match
            - if not then check if current window length < s1 then decrement frequency from second map
            - keep incrementing r
        */

        if(s1.Length > s2.Length)
            return false;

        int[] s1Freq = new int[26];
        int[] s2Freq = new int[26];

        foreach(char c in s1)
            s1Freq[c - 'a']++;

        int l = 0;
        int r = 0;

        while(r < s2.Length){
            s2Freq[s2[r] - 'a']++;

            if(r - l + 1 == s1.Length){
                // if frequency of s1 & s2 matches in maps, permutation found, return true
                if(MatchMap(s1Freq, s2Freq))
                    return true;
            }

            if(r - l + 1 < s1.Length){
                r++; // expand window by 1 on right if window size is less than s1 length
            }
            else{
                s2Freq[s2[l] - 'a']--; // discard from left, slide window to right by 1
                l++;
                r++;
            }
        }

        return false;
    }

    private bool MatchMap(int[] m1, int[] m2){
        for(int i = 0; i < m1.Length; i++)
            if(m1[i] != m2[i])
                return false;
        return true;
    }
}