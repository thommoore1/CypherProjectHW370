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
        int? shift = null;
        var result = Assert.Throws<ArgumentException>(() => CaesarCipher.Encode("hello", shift));
        Assert.Equal("Invalid value (Parameter 'shift')", result.Message);
    }
    
    [Fact]
    public void TestDecodeShiftIsNaN()
    {
        int? shift = null;
        var result = Assert.Throws<ArgumentException>(() => CaesarCipher.Decode("hello", shift));
        Assert.Equal("Invalid value (Parameter 'shift')", result.Message);
    }

    [Fact]
    public void TestCrackExample()
    {
        string test = CaesarCipher.Crack(
            "Xli ibxirhih evq wepyxmrk kiwxyvi aew eppikih xs fi fewih sr er ergmirx Vsqer gywxsq, fyx rs orsar Vsqer asvo sj evx hitmgxw mx, rsv hsiw erc ibxerx Vsqer xibx hiwgvmfi mx. Lmwxsvmerw lezi mrwxieh hixivqmrih xlex xli kiwxyvi svmkmrexih jvsq Neguyiw-Psymw Hezmh'w 1784 temrxmrk Sexl sj xli Lsvexmm, almgl hmwtpecih e vemwih evq wepyxexsvc kiwxyvi mr er ergmirx Vsqer wixxmrk. Xli kiwxyvi erh mxw mhirxmjmgexmsr amxl ergmirx Vsqi aew ehzergih mr sxliv Jvirgl risgpewwmg evx.");
        Assert.Equal("The extended arm saluting gesture was alleged to be based on an ancient Roman custom, but no known Roman work of art depicts it, nor does any extant Roman text describe it. Historians have instead determined that the gesture originated from Jacques-Louis David's 1784 painting Oath of the Horatii, which displayed a raised arm salutatory gesture in an ancient Roman setting. The gesture and its identification with ancient Rome was advanced in other French neoclassic art.", test);
    }

    [Fact]
    public void OneKnownWordMessageCrack()
    {
        string result = CaesarCipher.Crack("Khoor");
        Assert.Equal(result, "Hello");
    }

    [Fact]
    public void OneUnknownWordMessageCrack()
    {
        string result = CaesarCipher.Crack("ixfn");
        Assert.NotEqual(result, "fuck");
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