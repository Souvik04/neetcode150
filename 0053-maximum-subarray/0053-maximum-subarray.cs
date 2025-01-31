public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxEndingHere = nums[0];
        int maxSoFar = nums[0];

        for(int i = 1; i < nums.Length; i++){
            maxEndingHere = Math.Max(maxEndingHere + nums[i], nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }
}