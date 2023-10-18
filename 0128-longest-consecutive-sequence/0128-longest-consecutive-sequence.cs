public class Solution {
    public int LongestConsecutive(int[] nums) {
        int longest = 0;
        HashSet<int> set = nums.ToHashSet();

        foreach(int n in set){
            int cur = n - 1;
            int temp = 0;

            if(!set.Contains(cur)){
                while(set.Contains(cur + 1)){
                    temp++;
                    cur++;
                }
            }

            longest = Math.Max(longest, temp);
        }

        return longest;
    }
}