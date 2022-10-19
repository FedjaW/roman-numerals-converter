using System;
using NUnit.Framework;

public class Tests
{
    [TestCase(1, ExpectedResult = "I")]
    [TestCase(001, ExpectedResult = "I")]
    [TestCase(3, ExpectedResult = "III")]
    [TestCase(4, ExpectedResult = "IV")]
    [TestCase(5, ExpectedResult = "V")]
    [TestCase(9, ExpectedResult = "IX")]
    [TestCase(10, ExpectedResult = "X")]
    [TestCase(23, ExpectedResult = "XXIII")]
    [TestCase(43, ExpectedResult = "XLIII")]
    [TestCase(49, ExpectedResult = "XLIX")]
    [TestCase(000049, ExpectedResult = "XLIX")]
    [TestCase(50, ExpectedResult = "L")]
    [TestCase(67, ExpectedResult = "LXVII")]
    [TestCase(99, ExpectedResult = "XCIX")]
    [TestCase(100, ExpectedResult = "C")]
    [TestCase(120, ExpectedResult = "CXX")]
    [TestCase(123, ExpectedResult = "CXXIII")]
    [TestCase(480, ExpectedResult = "CDLXXX")]
    [TestCase(500, ExpectedResult = "D")]
    [TestCase(730, ExpectedResult = "DCCXXX")]
    [TestCase(880, ExpectedResult = "DCCCLXXX")]
    [TestCase(888, ExpectedResult = "DCCCLXXXVIII")]
    [TestCase(900, ExpectedResult = "CM")]
    [TestCase(949, ExpectedResult = "CMXLIX")]
    [TestCase(1000, ExpectedResult = "M")]
    [TestCase(01000, ExpectedResult = "M")]
    [TestCase(1984, ExpectedResult = "MCMLXXXIV")]
    [TestCase(2678, ExpectedResult = "MMDCLXXVIII")]
    [TestCase(3900, ExpectedResult = "MMMCM")]
    [TestCase(3999, ExpectedResult = "MMMCMXCIX")]
    public string Convert(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act
        var romanianNumber = RomanianConverter.Convert(numberToConvert);

        // Assert
        return romanianNumber;
    }

    [TestCase(4000)]
    [TestCase(99999)]
    public void Convert_NumberBiggerThan3999_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<Exception>(() => RomanianConverter.Convert(numberToConvert));
    }

    //[Test]
    public void Convert_NumberEqualsZero_ThrowsException()
    {
        // Arrange
        int numberToConvert = 0;

        // Act & Assert
        Assert.Throws<Exception>(() => RomanianConverter.Convert(numberToConvert));
    }

    //[TestCase(-1)]
    //[TestCase(-9999)]
    public void Convert_NumberLowerThanZero_ThrowsException(int numberToConvert)
    {
        // Arrange (See TestCase Attribute)

        // Act & Assert
        Assert.Throws<Exception>(() => RomanianConverter.Convert(numberToConvert));
    }
}