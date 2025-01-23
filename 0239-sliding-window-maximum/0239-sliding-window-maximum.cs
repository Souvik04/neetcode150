public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> output = new List<int>();
        LinkedList<int> list = new LinkedList<int>();
        
        for(int i = 0; i < nums.Length; i++){
            // remove indices outside the current window from front
            if(list.Count > 0 && list.First.Value < i - k + 1){
                list.RemoveFirst();
            }
            
            // maintain decreasing order by removing smaller elements from the back
            while(list.Count > 0 && nums[list.Last.Value] <= nums[i]){
                list.RemoveLast();
            }
            
            // add the current index into the back
            list.AddLast(i);
            
            // add maximum for the current window to output
            if(i >= k - 1){
                output.Add(nums[list.First.Value]);
            }
        }
        
        return output.ToArray();
    }
}