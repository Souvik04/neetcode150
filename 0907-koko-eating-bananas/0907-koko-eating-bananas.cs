public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = piles.Max();
        int minK = right;

        while(left <= right){
            int k = left + (right - left) / 2;
            long hours = 0;

            foreach(int p in piles){
                hours += (int)Math.Ceiling(p / (double)k);
            }

            if(hours <= h){
                minK = Math.Min(minK, k);
                right = k - 1;
            }
            else{
                left = k + 1;
            }
        }

        return minK;
    }
}