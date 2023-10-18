public class Solution {
    public IList<string> LetterCombinations(string digits) {
        IList<string> output = new List<string>();

        Dictionary<char, string> keyPad = new Dictionary<char, string>();
        keyPad.Add('2', "abc");
        keyPad.Add('3', "def");
        keyPad.Add('4', "ghi");
        keyPad.Add('5', "jkl");
        keyPad.Add('6', "mno");
        keyPad.Add('7', "pqrs");
        keyPad.Add('8', "tuv");
        keyPad.Add('9', "wxyz");

        if(!string.IsNullOrEmpty(digits)){
            Backtrack(digits, output, "", keyPad , 0);
        }
        
        return output;
    }

    private void Backtrack(string digits, IList<string> output, string temp, Dictionary<char, string> keyPad, int start){
         if(temp.Length == digits.Length){
             output.Add(temp.ToString());
             return;
         }

         foreach(char c in keyPad[digits[start]]){
             Backtrack(digits, output, temp + c, keyPad, start + 1);
         }
    }
}