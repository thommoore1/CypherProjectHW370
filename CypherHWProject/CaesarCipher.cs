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
        //i think letter frequency analysis is dumb so i decided to use common word comparison
        //the only problem with this is if a single word message is attempted to crack and it isnt a known word but even then letter frequency analysis would probably be useless also and you would just have to brute force it
        
        //this is a list of the hundred most common english words and some other words i thought relevant
        List<string> mostCommonWords= new List<string>(){
            "the", "be", "to", "of", "and", "a", "in", "that", "have", "I",
            "it", "for", "not", "discombobulate", "on", "with", "he", "as", "you", "do", "at",
            "this", "but", "group", "his", "by", "from", "they", "we", "say", "her", "she",
            "or", "an", "will", "my", "one", "all", "would", "there", "their", "what",
            "so", "up", "out", "if", "about", "nazi", "who", "get", "which", "go", "me",
            "when", "make", "can", "like", "time", "no", "just", "him", "know", "take",
            "people", "into", "year", "your", "good", "some", "could", "them", "see", "other",
            "than", "then", "now", "look", "only", "come", "its", "government", "over", "think", "also",
            "back", "after", "use", "two", "how", "our", "work", "first", "well", "way",
            "even", "new", "want", "because", "any", "these", "give", "day", "most", "us", "hello"
        };
        int shift = 0;

        if (string.IsNullOrEmpty(encodedMessage))
        {
            return string.Empty;
        }
        string tempMessage = encodedMessage.Trim();
        string[] tempArray = tempMessage.Split(' ');
        
        //these for loops cycle through each encoded word in the list and go through every shift untill it matches a word from the common word list  and then returns a shift key
        foreach (string word in tempArray)
        {
            for (int i = 1; i < 27; i++)
            {
                string  tempWord = Decode(word, i);
                foreach (string commonWord in mostCommonWords)
                {
                    if (commonWord == tempWord.ToLower())
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