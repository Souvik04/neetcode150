public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> output = new List<int>();
        LinkedList<int> linkedList = new LinkedList<int>();

        for(int i = 0; i < nums.Length; i++){
            if(linkedList.Count > 0 && linkedList.First.Value == i - k){
                linkedList.RemoveFirst();
            }

            while(linkedList.Count > 0 && nums[linkedList.Last.Value] <= nums[i]){
                linkedList.RemoveLast();
            }

            linkedList.AddLast(i);

            if(i >= k - 1){
                output.Add(nums[linkedList.First.Value]);
            }
        }

        return output.ToArray();
    }
}