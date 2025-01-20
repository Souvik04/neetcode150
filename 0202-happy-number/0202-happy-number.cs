public class Solution {
    public bool IsHappy(int n) {
        int slow = n;
        int fast = GetNext(n);

        while(fast != 1 && slow != fast){
            fast = GetNext(fast);
            fast = GetNext(fast);
            slow = GetNext(slow);
        }

        return fast == 1;
    }

    private int GetNext(int n){
        int sum = 0;

        while(n > 0){
            int dig = n % 10;
            sum += (dig * dig);
            n = n / 10;
        }

        return sum;
    }
}

/*

Time complexity: O(logn)
Space complexity: O(1)

*/