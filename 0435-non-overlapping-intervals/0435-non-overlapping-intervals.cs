public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        int count = 0;
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int prevEnd = 0;

        for(int i = 0; i < intervals.Length; i++){
            int curStart = intervals[i][0];
            int curEnd = intervals[i][1];

            if(curStart >= prevEnd){
                prevEnd = curEnd;
            }
            else{
                count++;
            }
        }

        return count;
    }
}

/*

1. initialize count = 0, prevEnd = 0
2. sort the input array by end time
3. iterate over intervals
    - check if curStart >= prevEnd, then set prevEnd = curEnd
    - else increment count by 1
4. return count as output

Time complexity: O(nlogn)
Space complexity: O(logn)

*/