public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> output = new List<IList<string>>();
        Backtrack(s, output, new List<string>(), 0);
        return output;
    }

    private void Backtrack(string s, IList<IList<string>> output, List<string> temp, int idx){
        if(idx == s.Length){
            output.Add(temp.ToList());
        }
        else{
            for(int i = idx; i < s.Length; i++){
                if(IsPalindrome(s, idx, i)){
                    temp.Add(s.Substring(idx, i - idx + 1));
                    Backtrack(s, output, temp, i + 1);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }

    private bool IsPalindrome(string s, int l, int r){
        while(l <= r){
            if(s[l++] != s[r--]){
                return false;
            }
        }

        return true;
    }
}