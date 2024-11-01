public class Solution {
    private class TrieNode {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
        public string Word { get; set; } = null;
    }

    private TrieNode root = new TrieNode();
    private IList<string> result = new List<string>();
    private int[][] directions = new int[][] {
        new int[] { 0, 1 }, new int[] { 1, 0 },
        new int[] { 0, -1 }, new int[] { -1, 0 }
    };
    
    public IList<string> FindWords(char[][] board, string[] words) {
        BuildTrie(words);

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                DFS(board, i, j, root);
            }
        }
        
        return result;
    }

    private void BuildTrie(string[] words) {
        foreach (var word in words) {
            var node = root;
            foreach (var c in word) {
                if (!node.Children.ContainsKey(c)) {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.Word = word; // Mark the end of a word
        }
    }

    private void DFS(char[][] board, int row, int col, TrieNode node) {
        char c = board[row][col];
        if (c == '#' || !node.Children.ContainsKey(c)) return;

        node = node.Children[c];
        if (node.Word != null) {
            result.Add(node.Word);
            node.Word = null; // Avoid duplicate entries
        }

        board[row][col] = '#'; // Mark the cell as visited
        foreach (var direction in directions) {
            int newRow = row + direction[0];
            int newCol = col + direction[1];
            if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length) {
                DFS(board, newRow, newCol, node);
            }
        }
        board[row][col] = c; // Restore the cell
    }
}

/*

Time complexity: O(m * n * 4^l)
Space complexity: O(w * l + m * n)

*/