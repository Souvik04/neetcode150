public class WordDictionary {
    public TrieNode root = null;

    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode node = root;

        foreach(char c in word){
            if(!node.children.ContainsKey(c)){
                node.children.Add(c, new TrieNode());
            }

            node = node.children[c];
        }

        node.isEndOfWord = true;
    }

    public bool Search(string word){
        return Search(root, word, 0);
    }
    
    private bool Search(TrieNode node, string word, int index) {
        if(index == word.Length){
            return node.isEndOfWord;
        }

        char ch = word[index];

        if(ch == '.'){
            foreach(TrieNode child in node.children.Values){
                if(Search(child, word, index + 1)){
                   return true; 
                }
            }

            return false;
        }
        else{
            if(!node.children.ContainsKey(ch)){
                return false;
            }

            return Search(node.children[ch], word, index + 1);
        }
    }
}

public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;

    public TrieNode(){
        this.children = new Dictionary<char, TrieNode>();
        this.isEndOfWord = false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);

 Time complexity: O(m * n)
 Space complexity: O(m * n)
 
 */