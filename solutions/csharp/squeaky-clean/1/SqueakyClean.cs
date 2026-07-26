using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder s = new StringBuilder();
        bool isDash = false;
        

        foreach(char c in identifier)
        {
            if(c == '-')
            {
                isDash = true;
                continue;
            }
            else if(c >= 'α' && c <= 'ω' )
            {
                continue;
            }
            else if(char.IsControl(c))
            {
                s.Append("CTRL");
            }
            else if(c == ' ')
            {
                s.Append('_');
            }
            else if(!char.IsLetter(c))
            {
                continue;
            }
            else if(isDash)
            {    
                
                s.Append(char.ToUpper(c));
                isDash = false;
            }
            else
            {
                s.Append(c);
            }
        }
        
        string result = s.ToString();

        return result;
    }
}
