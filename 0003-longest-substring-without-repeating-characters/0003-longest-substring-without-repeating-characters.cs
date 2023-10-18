public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int longest = 0;
        int l = 0;

        for(int r = 0; r < s.Length; r++){
            if(map.ContainsKey(s[r])){
                l = Math.Max(l, map[s[r]] + 1);
                map.Remove(s[r]);
            }

            map.Add(s[r], r);
            longest = Math.Max(longest, r - l + 1); // since 0 based index, e.g. a b -> 2
        }

        return longest;
    }
}