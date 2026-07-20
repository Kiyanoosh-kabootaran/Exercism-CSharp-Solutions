using System.Collections.Generic;

public static class MatchingBrackets
{
    private static readonly Dictionary<char,char> bracketPairs = new Dictionary<char,char>
    {
        {'}' , '{'},
        {')' , '('},
        {']' , '['}        
    };
    
    public static bool IsPaired(string input)
    {
        Stack<char> stack = new Stack<char>();
        
        foreach(char c in input)
        {
            if(bracketPairs.ContainsValue(c)) stack.Push(c);

            else if(bracketPairs.ContainsKey(c))
            {
                if(!stack.TryPop(out char last) || last != bracketPairs[c]) return false;
            }
        }

        return stack.Count == 0;
    }
}
