public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(nums);

        for(int i = 0; i < nums.Length - 2; i++){
            if(i == 0 || (i > 0 && nums[i] != nums[i - 1])){
                int left = i + 1;
                int right = nums.Length - 1;

                while(left < right){
                    int sum = nums[i] + nums[left] + nums[right];
                    if(sum == 0){
                        output.Add(new List<int>(){nums[i], nums[left], nums[right]});

                        while(left < right && nums[left] == nums[left + 1]) 
                            left++;
                        while(left < right && nums[right] == nums[right - 1])
                            right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                        left++;
                    else
                        right--;
                }
            }
        }

        return output;
    }
}