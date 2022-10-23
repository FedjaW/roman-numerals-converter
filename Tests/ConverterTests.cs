using System;
using NUnit.Framework;

public class Tests
{
    # region ConvertToRoman

    [TestCase(1, ExpectedResult = "I")]
    [TestCase(001, ExpectedResult = "I")]
    [TestCase(3, ExpectedResult = "III")]
    [TestCase(4, ExpectedResult = "IV")]
    [TestCase(5, ExpectedResult = "V")]
    [TestCase(8, ExpectedResult = "VIII")]
    [TestCase(9, ExpectedResult = "IX")]
    [TestCase(10, ExpectedResult = "X")]
    [TestCase(23, ExpectedResult = "XXIII")]
    [TestCase(30, ExpectedResult = "XXX")]
    [TestCase(40, ExpectedResult = "XL")]
    [TestCase(43, ExpectedResult = "XLIII")]
    [TestCase(49, ExpectedResult = "XLIX")]
    [TestCase(000049, ExpectedResult = "XLIX")]
    [TestCase(50, ExpectedResult = "L")]
    [TestCase(67, ExpectedResult = "LXVII")]
    [TestCase(99, ExpectedResult = "XCIX")]
    [TestCase(100, ExpectedResult = "C")]
    [TestCase(120, ExpectedResult = "CXX")]
    [TestCase(123, ExpectedResult = "CXXIII")]
    [TestCase(300, ExpectedResult = "CCC")]
    [TestCase(400, ExpectedResult = "CD")]
    [TestCase(480, ExpectedResult = "CDLXXX")]
    [TestCase(500, ExpectedResult = "D")]
    [TestCase(730, ExpectedResult = "DCCXXX")]
    [TestCase(800, ExpectedResult = "DCCC")]
    [TestCase(880, ExpectedResult = "DCCCLXXX")]
    [TestCase(888, ExpectedResult = "DCCCLXXXVIII")]
    [TestCase(900, ExpectedResult = "CM")]
    [TestCase(949, ExpectedResult = "CMXLIX")]
    [TestCase(1000, ExpectedResult = "M")]
    [TestCase(01000, ExpectedResult = "M")]
    [TestCase(1555, ExpectedResult = "MDLV")]
    [TestCase(1984, ExpectedResult = "MCMLXXXIV")]
    [TestCase(2678, ExpectedResult = "MMDCLXXVIII")]
    [TestCase(2900, ExpectedResult = "MMCM")]
    [TestCase(3000, ExpectedResult = "MMM")]
    [TestCase(3900, ExpectedResult = "MMMCM")]
    [TestCase(3999, ExpectedResult = "MMMCMXCIX")]
    public string ConvertToRoman_Integer_ReturnsRoman(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act
        var romanNumber = Converter.ConvertToRoman(numberToConvert);

        // Assert
        return romanNumber;
    }

    [Test]
    public void ConvertToRoman_Integer_ReturnsEasterEgg()
    {
        // Arrange
        var numberToConvert = 38;

        // Act
        var romanNumber = Converter.ConvertToRoman(numberToConvert);

        // Assert
        Assert.AreEqual("PASSIERSCHEIN A-XXXVIII", romanNumber);
    }

    [TestCase(4000)]
    [TestCase(99999)]
    public void ConvertToRoman_GreaterThan3999_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRoman(numberToConvert));
    }

    [TestCase(0)]
    [TestCase(000)]
    public void ConvertToRoman_Zero_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRoman(numberToConvert));
    }

    [TestCase(-1)]
    [TestCase(-480)]
    [TestCase(-9999)]
    public void ConvertToRoman_NegativeNumber_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRoman(numberToConvert));
    }

    # endregion

    # region ConvertToRomanRecursive

    [TestCase(1, ExpectedResult = "I")]
    [TestCase(001, ExpectedResult = "I")]
    [TestCase(3, ExpectedResult = "III")]
    [TestCase(4, ExpectedResult = "IV")]
    [TestCase(5, ExpectedResult = "V")]
    [TestCase(8, ExpectedResult = "VIII")]
    [TestCase(9, ExpectedResult = "IX")]
    [TestCase(10, ExpectedResult = "X")]
    [TestCase(23, ExpectedResult = "XXIII")]
    [TestCase(30, ExpectedResult = "XXX")]
    [TestCase(40, ExpectedResult = "XL")]
    [TestCase(43, ExpectedResult = "XLIII")]
    [TestCase(49, ExpectedResult = "XLIX")]
    [TestCase(000049, ExpectedResult = "XLIX")]
    [TestCase(50, ExpectedResult = "L")]
    [TestCase(67, ExpectedResult = "LXVII")]
    [TestCase(99, ExpectedResult = "XCIX")]
    [TestCase(100, ExpectedResult = "C")]
    [TestCase(120, ExpectedResult = "CXX")]
    [TestCase(123, ExpectedResult = "CXXIII")]
    [TestCase(300, ExpectedResult = "CCC")]
    [TestCase(400, ExpectedResult = "CD")]
    [TestCase(480, ExpectedResult = "CDLXXX")]
    [TestCase(500, ExpectedResult = "D")]
    [TestCase(730, ExpectedResult = "DCCXXX")]
    [TestCase(800, ExpectedResult = "DCCC")]
    [TestCase(880, ExpectedResult = "DCCCLXXX")]
    [TestCase(888, ExpectedResult = "DCCCLXXXVIII")]
    [TestCase(900, ExpectedResult = "CM")]
    [TestCase(949, ExpectedResult = "CMXLIX")]
    [TestCase(1000, ExpectedResult = "M")]
    [TestCase(01000, ExpectedResult = "M")]
    [TestCase(1555, ExpectedResult = "MDLV")]
    [TestCase(1984, ExpectedResult = "MCMLXXXIV")]
    [TestCase(2678, ExpectedResult = "MMDCLXXVIII")]
    [TestCase(2900, ExpectedResult = "MMCM")]
    [TestCase(3000, ExpectedResult = "MMM")]
    [TestCase(3900, ExpectedResult = "MMMCM")]
    [TestCase(3999, ExpectedResult = "MMMCMXCIX")]
    public string ConvertToRomanRecusrive_Integer_ReturnsRoman(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act
        var romanNumber = Converter.ConvertToRomanRecursive(numberToConvert);

        // Assert
        return romanNumber;
    }

    //[Test]
    public void ConvertToRomanRecursive_Integer_ReturnsEasterEgg()
    {
        // Arrange
        var numberToConvert = 38;

        // Act
        var romanNumber = Converter.ConvertToRomanRecursive(numberToConvert);

        // Assert
        Assert.AreEqual("PASSIERSCHEIN A-XXXVIII", romanNumber);
    }

    [TestCase(4000)]
    [TestCase(99999)]
    public void ConvertToRomanRecursive_GreaterThan3999_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRomanRecursive(numberToConvert));
    }

    //[TestCase(0)]
    //[TestCase(000)]
    public void ConvertToRomanRecursive_Zero_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRomanRecursive(numberToConvert));
    }

    [TestCase(-1)]
    [TestCase(-480)]
    [TestCase(-9999)]
    public void ConvertToRomanRecursive_NegativeNumber_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Converter.ConvertToRomanRecursive(numberToConvert));
    }

    # endregion
}