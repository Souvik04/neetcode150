public class Solution {
    public IList<int> PartitionLabels(string s) {
        // Step 1: Create a dictionary to store the last occurrence of each character
        var lastOccurrence = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            lastOccurrence[s[i]] = i; // Store the last index for each character
        }

        var partitions = new List<int>();
        int start = 0;
        int end = 0;

        // Step 2: Iterate through the string to determine partitions
        for (int i = 0; i < s.Length; i++) {
            end = Math.Max(end, lastOccurrence[s[i]]); // Update the end of the current partition

            // When we reach the end of the partition
            if (i == end) {
                partitions.Add(end - start + 1); // Size of the current partition
                start = i + 1; // Move to the next partition
            }
        }

        return partitions;
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/