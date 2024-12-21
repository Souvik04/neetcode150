public class Solution {
    TrieNode root = null;
    int[] dr = null;
    int[] dc = null;
    IList<string> output = null;

    public IList<string> FindWords(char[][] board, string[] words) {
        root = new TrieNode();
        dr = new int[4]{1, 0, -1, 0};
        dc = new int[4]{0, -1, 0, 1};
        output = new List<string>();

        // build trie from words
        foreach(string w in words){
            Insert(w, root);
        }

        // seach for words in board
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                // start PrefixSearch
                DFS(board, i, j, root);
            }
        }

        return output;
    }

    private void DFS(char[][] board, int row, int col, TrieNode node){
        char ch = board[row][col];

        if(ch == '#' || !node.children.ContainsKey(ch)){
            return;
        }

        // mark as visited
        board[row][col] = '#';
        node = node.children[ch];

        if(node.word != null){
            output.Add(node.word);
            node.word = null;
        }

        // check newighbors
        for(int i = 0; i < 4; i++){
            int newR = dr[i] + row;
            int newC = dc[i] + col;

            // check boundary conditons
            if(newR >= 0 && newR < board.Length && newC >= 0 && newC < board[0].Length && board[newR][newC] != '#'){
                DFS(board, newR, newC, node);
            }
        }

        // restore cell
        board[row][col] = ch;
    }

    private void Insert(string word, TrieNode root){
        TrieNode node = root;

        foreach(char c in word){
            if(!node.children.ContainsKey(c)){
                node.children[c] = new TrieNode();
            }

            node = node.children[c];
        }

        node.word = word;
    }
}

public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public string? word;

    public TrieNode(){
        this.children = new Dictionary<char, TrieNode>();
        this.word = null;
    }
}

/*

Time complexity: O(k * m + m * n * l)
Space complexity: O(k * l)

*/