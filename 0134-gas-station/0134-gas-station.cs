public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalGas = 0, totalCost = 0, currentTank = 0;
        int startingStation = 0;

        for (int i = 0; i < gas.Length; i++) {
            totalGas += gas[i];
            totalCost += cost[i];
            currentTank += gas[i] - cost[i];

            // If currentTank drops below 0, we cannot start from startingStation
            if (currentTank < 0) {
                startingStation = i + 1; // Try starting from the next station
                currentTank = 0; // Reset currentTank
            }
        }

        // If total gas is less than total cost, return -1
        return totalGas < totalCost ? -1 : startingStation;
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/