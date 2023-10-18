public class Solution {
    public int FindMin(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;

        if(nums.Length == 1 || nums[left] < nums[right]){
            return nums[left];
        }

        while(left <= right){
            int mid = left + (right - left) / 2;

            if(nums[mid] > nums[right]){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }

            if(nums[mid] > nums[mid + 1]){
                return nums[mid + 1];
            }
            else if(nums[mid - 1] > nums[mid]){
                return nums[mid];
            }
        }

        return - 1;
    }
}