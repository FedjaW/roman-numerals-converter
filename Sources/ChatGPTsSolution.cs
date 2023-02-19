// Q: Write a roman numerals converter in C#
// A: In this example, the ConvertToRomanNumeral method takes an integer as input and returns a string representing the Roman numeral equivalent of that number. 
// The method uses arrays to store the symbols for the different powers of 10 and combines them to form the final Roman numeral. 
// The Main method prompts the user for input, calls the ConvertToRomanNumeral method, and displays the result on the console.
public class RomanNumeralConverter
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number to convert to Roman numerals: ");
        int number = int.Parse(Console.ReadLine());

        string romanNumeral = ConvertToRomanNumeral(number);

        Console.WriteLine("Roman numeral: {0}", romanNumeral);
        Console.ReadKey();
    }

    public static string ConvertToRomanNumeral(int number)
    {
        if (number < 1 || number > 3999)
            throw new ArgumentOutOfRangeException("Number must be between 1 and 3999.");

        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        string romanNumeral = thousands[number / 1000] +
            hundreds[(number % 1000) / 100] +
            tens[(number % 100) / 10] +
            ones[number % 10];

        return romanNumeral;
    }
}