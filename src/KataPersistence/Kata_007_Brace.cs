namespace KataPersistence;

public class Kata_007_Brace
{
    public static bool ValidBraces(string braces)
    {
        if (braces.Length % 2 != 0)
        {
            return false;
        }

        List<char> bracesStack = new List<char>();
        foreach (char c in braces)
        {
            if (bracesStack.Count == 0)
            {
                bracesStack.Add(c);
            }
            else
            {
                var previous = bracesStack.Last();
                if (previous == GetOpeningBrace(c))
                {
                    bracesStack.RemoveAt(bracesStack.Count - 1);
                }
                else
                {
                    bracesStack.Add(c);
                }
            }
        }

        return bracesStack.Count == 0;
    }

    private static char GetOpeningBrace(char c)
    {
        if (c == ')') { return '('; }
        if (c == ']') { return '['; }
        if (c == '}') { return '{'; }

        return '0';
    }
}
