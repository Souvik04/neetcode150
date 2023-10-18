public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Backtrack(nums, output, new List<int>());
        return output;
    }

    private void Backtrack(int[] nums, IList<IList<int>> output, List<int> temp){
        // Goal
        if(temp.Count == nums.Length){
            output.Add(new List<int>(temp));
        }
        else{
            // Choice
            for(int i = 0; i < nums.Length; i++){
                // Constraint
                if(temp.Contains(nums[i])){
                    continue;
                }

                temp.Add(nums[i]);
                Backtrack(nums, output, temp);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}