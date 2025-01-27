namespace CypherHWProject;

using System;
using System.Text;

public static class CaesarCipher
{
    public static string Encode(string input, int? shift)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        if (shift == null)
        {
            throw new ArgumentException("Invalid value", "shift"); 
        }

        StringBuilder result = new StringBuilder();
        
        // Normalize the shift to avoid unnecessary cycles
        shift = shift % 26;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char translated = (char)((((c - offset) + (int)shift + 26) % 26) + offset);
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

    public static string Decode(string encoded, int? shift)
    {
        if (string.IsNullOrEmpty(encoded))
        {
            return string.Empty;
        }
        
        if (shift == null)
        {
            throw new ArgumentException("Invalid value", "shift"); 
        }
        
        StringBuilder result = new StringBuilder();
        
        // Normalize the shift to avoid unnecessary cycles
        shift = shift % 26;
        
        foreach (char c in encoded)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char translated = (char)((((c - offset) - (int)shift + 26) % 26) + offset);
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

    public static string Crack(string encodedMessage)
    {
        //uses this list of 100 most common words in english to figure out the shift, so it only works if the message has one of these words
        List<string> mostCommonWords= new List<string>(){
            "the", "be", "to", "of", "and", "a", "in", "that", "have", "I",
            "it", "for", "not", "on", "with", "he", "as", "you", "do", "at",
            "this", "but", "his", "by", "from", "they", "we", "say", "her", "she",
            "or", "an", "will", "my", "one", "all", "would", "there", "their", "what",
            "so", "up", "out", "if", "about", "who", "get", "which", "go", "me",
            "when", "make", "can", "like", "time", "no", "just", "him", "know", "take",
            "people", "into", "year", "your", "good", "some", "could", "them", "see", "other",
            "than", "then", "now", "look", "only", "come", "its", "over", "think", "also",
            "back", "after", "use", "two", "how", "our", "work", "first", "well", "way",
            "even", "new", "want", "because", "any", "these", "give", "day", "most", "us"
        };
        int shift = 0;

        if (string.IsNullOrEmpty(encodedMessage))
        {
            return string.Empty;
        }
        string tempMessage = encodedMessage.Trim();
        string[] tempArray = tempMessage.Split(' ');
        foreach (string word in tempArray)
        {
            for (int i = 1; i < 27; i++)
            {
                string  tempWord = Decode(word, i);
                foreach (string commonWord in mostCommonWords)
                {
                    if (commonWord == tempWord)
                    {
                        shift = i;
                        break;
                    }
                }
            }
        }
        
        
        return Decode(encodedMessage, shift);
    }
}