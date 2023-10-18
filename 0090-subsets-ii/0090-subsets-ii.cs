public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(nums);
        Backtrack(nums, output, new List<int>(), 0);
        return output;
    }

    private void Backtrack(int[] nums, IList<IList<int>> output, List<int> temp, int start){
        output.Add(new List<int>(temp));

        for(int i = start; i < nums.Length; i++){
            if(i > start && nums[i] == nums[i - 1]){
                continue;
            }

            temp.Add(nums[i]);
            Backtrack(nums, output, temp, i + 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}