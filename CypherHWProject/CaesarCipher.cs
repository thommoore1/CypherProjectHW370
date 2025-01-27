namespace CypherHWProject;

using System;
using System.Text;

public static class CaesarCipher
{
    public static string Encode(string input, int shift)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder result = new StringBuilder();
        
        // Normalize the shift to avoid unnecessary cycles
        shift = shift % 26;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char translated = (char)((((c - offset) + shift + 26) % 26) + offset);
                result.Append(translated);
            }
            else
            {
                // Non-alphabetic characters are not modified
                result.Append(c);
            }
        }

        return result.ToString();
    }

    public static string Decode(string encoded, int shift)
    {
        if (string.IsNullOrEmpty(encoded))
        {
            return string.Empty;
        }
        
        StringBuilder result = new StringBuilder();
        
        // Normalize the shift to avoid unnecessary cycles
        shift = shift % 26;
        foreach (char c in encoded)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char translated = (char)((((c - offset) - shift + 26) % 26) + offset);
                result.Append(translated);
            }
            else
            {
                // Non-alphabetic characters are not modified
                result.Append(c);
            }
        }

        return result.ToString();
    }
}