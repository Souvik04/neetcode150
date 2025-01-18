public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;

        if(n == 0){
            return 0;
        }

        if(n == 1){
            return nums[0];
        }

        int maxProfit = 0;
        int profit1 = GetProfit(nums, 0, n - 2);
        int profit2 = GetProfit(nums, 1, n - 1);
        
        return Math.Max(profit1, profit2);
    }

    private int GetProfit(int[] nums, int start, int end){
        if(start == end){
            return nums[start];
        }

        int[] dp = new int[end - start + 1];
        dp[0] = nums[start];
        dp[1] = Math.Max(dp[start], nums[start + 1]);

        for(int i = 2; i <= end - start; i++){
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[start + i]);
        }

        return dp[dp.Length - 1];        
    }
}

/*

1. apply House Robber (1st version)
2. get prfit from o to n - 2 and 1 to n - 1
2. return max(profit1, profit2)

Time complexity: O(n)
Space complexity: O(n)

*/