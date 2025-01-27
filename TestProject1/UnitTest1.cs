using CypherHWProject;
using NuGet.Frameworks;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void TestEncodeOneWord()
    {
        string result = CaesarCipher.Encode("hello", 1);
        Assert.Equal(result, "ifmmp");
    }
    
    [Fact]
    public void TestDecodeOneWord()
    {
        string result = CaesarCipher.Decode("ifmmp", 1);
        Assert.Equal(result, "hello");
    }

    [Fact]
    public void TestEncodeMultipleShifts()
    {
        string result = CaesarCipher.Encode("hello", 3);
        Assert.Equal(result, "khoor");
    }
    
    [Fact]
    public void TestDecodeMultipleShifts()
    {
        string result = CaesarCipher.Decode("khoor", 3);
        Assert.Equal(result, "hello");
    }

    [Fact]
    public void TestEncodeMultipleWords()
    {
        string result = CaesarCipher.Encode("hello there guy", 1);
        Assert.Equal(result, "ifmmp uifsf hvz");
    }
    
    [Fact]
    public void TestDecoddeMultipleWords()
    {
        string result = CaesarCipher.Decode("ifmmp uifsf hvz", 1);
        Assert.Equal(result, "hello there guy");
    }

    [Fact]
    public void TestEncodeUpperAndLower()
    {
        string result = CaesarCipher.Encode("ooOOoo", 1);
        Assert.Equal(result, "ppPPpp");
    }
    
    [Fact]
    public void TestDecodeUpperAndLower()
    {
        string result = CaesarCipher.Decode("ppPPpp", 1);
        Assert.Equal(result, "ooOOoo");
    }

    [Fact]
    public void TestEncodeLeadingSpaces()
    {
        string result = CaesarCipher.Encode("   afdsjkfads", 1);
        Assert.Equal(result, "   bgetklgbet");
    }
    
    [Fact]
    public void TestDecodeLeadingSpaces()
    {
        string result = CaesarCipher.Decode("   bgetklgbet", 1);
        Assert.Equal(result, "   afdsjkfads");
    }
    
    [Fact]
    public void TestEncodeTrailingSpaces()
    {
        string result = CaesarCipher.Encode("afdsjkfads   ", 1);
        Assert.Equal(result, "bgetklgbet   ");
    }
    
    [Fact]
    public void TestDecodeTrailingSpaces()
    {
        string result = CaesarCipher.Decode("bgetklgbet   ", 1);
        Assert.Equal(result, "afdsjkfads   ");
    }

    [Fact]
    public void TestEncodeNumbers()
    {
        string result = CaesarCipher.Encode("1234", 1);
        Assert.Equal(result, "1234");
    }

    [Fact]
    public void TestDecodeNumbers()
    {
        string result = CaesarCipher.Decode("1234", 1);
        Assert.Equal(result, "1234");
    }

    [Fact]
    public void TestEncodePunctuation()
    {
        string result = CaesarCipher.Encode("<,>.?/:;'|}]{[+=_-)(*&^%$#@!`~", 1);
        Assert.Equal(result, "<,>.?/:;'|}]{[+=_-)(*&^%$#@!`~");
    }
    
    [Fact]
    public void TestDecodePunctuation()
    {
        string result = CaesarCipher.Decode("<,>.?/:;'|}]{[+=_-)(*&^%$#@!`~", 1);
        Assert.Equal(result, "<,>.?/:;'|}]{[+=_-)(*&^%$#@!`~");
    }

    [Fact]
    public void TestEncodeReturnsNull()
    {
        string result = CaesarCipher.Encode("", 1);
        Assert.Equal(result, String.Empty);
    }
    
    [Fact]
    public void TestDecodeReturnsNull()
    {
        string result = CaesarCipher.Decode("", 1);
        Assert.Equal(result, String.Empty);
    }

    [Fact]
    public void TestEncodeShiftIsZero()
    {
        string result = CaesarCipher.Encode("hello", 0);
        Assert.Equal(result, "hello");
    }
    
    [Fact]
    public void TestDecodeShiftIsZero()
    {
        string result = CaesarCipher.Decode("hello", 0);
        Assert.Equal(result, "hello");
    }

    [Fact]
    public void TestEncodeShiftIsNegative()
    {
        string result = CaesarCipher.Encode("hello", -1);
        Assert.Equal(result, "gdkkn");
    }
    
    [Fact]
    public void TestDecodeShiftIsNegative()
    {
        string result = CaesarCipher.Decode("gdkkn", -1);
        Assert.Equal(result, "hello");
    }

    [Fact]
    public void TestEncodeShiftIsHuge()
    {
        string result = CaesarCipher.Encode("hello", 100);
        Assert.Equal(result, "dahhk");
    }
    
    [Fact]
    public void TestDecodeShiftIsHuge()
    {
        string result = CaesarCipher.Decode("dahhk", 100);
        Assert.Equal(result, "hello");
    }

    [Fact]
    public void TestEncodeShiftIsNaN()
    {
        Assert.True(false);
    }
    
    [Fact]
    public void TestDecodeShiftIsNaN()
    {
        Assert.True(false);
    }

/*
 * 1.What if only one word is being encoded?
   2. What if multiple words?
   3. What about upper and lower case?
   4. What if there are leading or trailing spaces?
   5. How will you handle non-alpha characters like numbers or punctuation?
   6. What if the text to encode or decode is null?
   7. What if the shift is 0? Negative? Some huge number? Not a number?
 */
}