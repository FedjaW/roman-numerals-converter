using System;
using NUnit.Framework;


// Q: write unit tests for the numerals converter.
// A: Sure! Here are some unit tests for the RomanNumeralConverter class in the code I provided:
// These unit tests cover the basic functionality of the ConvertToRomanNumeral method, including conversion of single-digit, double-digit, triple-digit, and four-digit numbers. 
// The last test checks that the method throws an ArgumentOutOfRangeException when given a number outside the valid range (1 to 3999).
[TestFixture]
public class RomanNumeralConverterTests
{
    [Test]
    public void TestConversionForSingleDigit()
    {
        string romanNumeral = RomanNumeralConverter.ConvertToRomanNumeral(3);
        Assert.AreEqual("III", romanNumeral);
    }

    [Test]
    public void TestConversionForDoubleDigit()
    {
        string romanNumeral = RomanNumeralConverter.ConvertToRomanNumeral(42);
        Assert.AreEqual("XLII", romanNumeral);
    }

    [Test]
    public void TestConversionForTripleDigit()
    {
        string romanNumeral = RomanNumeralConverter.ConvertToRomanNumeral(357);
        Assert.AreEqual("CCCLVII", romanNumeral);
    }

    [Test]
    public void TestConversionForFourDigit()
    {
        string romanNumeral = RomanNumeralConverter.ConvertToRomanNumeral(2019);
        Assert.AreEqual("MMXIX", romanNumeral);
    }

    [Test]
    public void TestConversionForOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumeralConverter.ConvertToRomanNumeral(4000));
        Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumeralConverter.ConvertToRomanNumeral(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumeralConverter.ConvertToRomanNumeral(-1));
    }
}