public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> output = new List<string>();
        Backtrack(output, "", 0, 0, n);
        return output;
    }
    
    private void Backtrack(IList<string> output, string value, int open, int close, int max)
    {
        IList<string> paranthesis = new List<string>();
        if (value.Length == max * 2)
        {
            output.Add(value);
            return;
        }

        if (open < max)
        {
            Backtrack(output, value + '(', open + 1, close, max);
        }
        if (close < open)
        {
            Backtrack(output, value + ')', open, close + 1, max);
        }
    }
}