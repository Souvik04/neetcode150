public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Backtrack(nums, output, new List<int>());

        return output;
    }

    private void Backtrack(int[] nums, IList<IList<int>> output, List<int> temp){
        if(temp.Count == nums.Length){
            output.Add(temp.ToList());
            return;
        }

        for(int i = 0; i < nums.Length; i++){
            if(!temp.Contains(nums[i])){
                temp.Add(nums[i]);
                Backtrack(nums, output, temp);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}

/*

1. initialize IList<IList<int>> output
2. perform backtrack(nums, output, temp)
    - if temp.length == nums.length, add temp to output and return
    - iterate over nums from 0 to n - 1
    - add to temp and backtrack
3. return output

-----

Time complexity: O(n * n!)
Space complexity: O(n * n!)

*/