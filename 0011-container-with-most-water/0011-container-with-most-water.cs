public class Solution {
    public int MaxArea(int[] height) {
        int max = int.MinValue;
        int left = 0;
        int right = height.Length - 1;

        while(left < right){
            int level = Math.Min(height[left], height[right]);
            max = Math.Max(max, level * (right - left));

            if(height[left] < height[right])
                left++;
            else
                right--;
        }

        return max;
    }
} 