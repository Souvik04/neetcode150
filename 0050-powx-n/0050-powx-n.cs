public class Solution {
    public double MyPow(double x, int n) {
        if(x == 0){
            return 0;
        }

        if(n == 0){
            return 1;
        }

        double res = GetPow(x, n);
        
        return n >= 0 ? res : 1 / res;
    }

    private double GetPow(double x, int n){
        if(n == 0){
            return 1;
        }

        double res = GetPow(x, n / 2);

        return n % 2 == 0 ? res * res : x * res * res;
    }
}