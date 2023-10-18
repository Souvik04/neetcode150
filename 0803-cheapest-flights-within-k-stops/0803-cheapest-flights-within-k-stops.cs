public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        /*
            Bellman-Ford algorithm with k iterations
            Time complexity: O(n*k)
            Space: O(n)

        - create a prices array of size n to store best known costs for each destination
        - initialize elements to infinity, except prices[src] which should be 0
        - loop from 0 to k + 1 
            - create tempPrices array to store best known costs for each destination in each iteration (upto k) and set tempPrices = prices
            - explore all edges e in flights[src]
                - if prices[e.s] == INF, continue
                - tempPrices[e.d] = prices[e.s] + e.c < tempPrices[e.d] ? prices[e.s] + e.c : tempPrices[e.d]
            - prices = tempPrices
        - return prices[dst] == int.MaxValue ? -1 : prices[dst]

        */

        int[] prices = new int[n];

        for(int i = 0; i < n; i++){
            prices[i] = int.MaxValue;
        }

        prices[src] = 0;

        for(int i = 0; i < k + 1; i++){
            int[] tempPrices = prices.Clone() as int[];

            foreach(var e in flights){
                int s = e[0];
                int d = e[1];
                int c = e[2];

                if(prices[s] == int.MaxValue){
                    continue;
                }
                else{
                    tempPrices[d] = prices[s] + c < tempPrices[d] ? prices[s] + c : tempPrices[d];
                }
            }

            prices = tempPrices;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}