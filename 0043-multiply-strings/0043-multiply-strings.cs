public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0"; // Handle multiplication with zero

        int m = num1.Length;
        int n = num2.Length;
        int[] result = new int[m + n]; // Maximum possible length of the result

        // Reverse iterate through both strings
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                // Multiply the digits
                int mul = (num1[i] - '0') * (num2[j] - '0');

                // Position in the result array
                int p1 = i + j; // Position for carry
                int p2 = i + j + 1; // Current position

                // Add multiplication result and carry to the corresponding positions
                int sum = mul + result[p2];

                result[p2] = sum % 10; // Current digit
                result[p1] += sum / 10; // Carry
            }
        }

        // Convert result array to string
        StringBuilder sb = new StringBuilder();

        foreach (int num in result) {
            if (!(sb.Length == 0 && num == 0)) { // Skip leading zeros
                sb.Append(num);
            }
        }

        return sb.Length == 0 ? "0" : sb.ToString(); // Return result or "0" if empty
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(m + n)

*/