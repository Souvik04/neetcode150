public class Solution {
    public int Trap(int[] height) {
        int sum = 0;
        int n = height.Length;
        int left = 0;
        int right = n - 1;
        int leftMax = height[left];
        int rightMax = height[right];

        while(left < right){
            if(leftMax < rightMax){
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                sum += leftMax - height[left];
            }
            else{
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                sum += rightMax - height[right];
            }
        }

        return sum;
    }

    /* 
    public int Trap(int[] height) {
        int output = 0;
        int n = height.Length;
        int[] left = new int[n];
        int[] right = new int[n];

        left[0] = height[0];
        right[n - 1] = height[n - 1];

        for(int i = 1; i < n; i++)
            left[i] = Math.Max(height[i], left[i - 1]);

        for(int i = n - 2; i >= 0; i--)
            right[i] = Math.Max(height[i], right[i + 1]);

        for(int i = 0; i < n; i++)
            output += Math.Min(left[i], right[i]) - height[i];

        return output;
    }    
    */
}