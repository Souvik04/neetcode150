public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, output, new List<int>(), target, 0);
        return output;
    }

    private void Backtrack(int[] candidates, IList<IList<int>> output, List<int> temp, int target, int start){
        // Goal
        if(temp.Sum() > target){
            return;
        }
        else if(temp.Sum() == target){
            output.Add(new List<int>(temp));
        }
        else{
            for(int i = start; i < candidates.Length; i++){
                if(i > start && candidates[i] == candidates[i - 1]){
                    continue;
                }

                temp.Add(candidates[i]);
                Backtrack(candidates, output, temp, target, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }            
        }

        // Constraint
    }
}