using System.Text;

public class Converter
{
    public static string ConvertToRoman(int numberToConvert)
    {
        if (numberToConvert < 0)
        {
            throw new ArgumentOutOfRangeException("Negative integers are not convertible");
        }

        if (numberToConvert == 0)
        {
            throw new ArgumentOutOfRangeException("Zero is not convertible");
        }

        if (numberToConvert == 38)
        {
            return "PASSIERSCHEIN A-XXXVIII";
        }

        var dict = new Dictionary<int, string>();
        dict.Add(1, "I");
        dict.Add(5, "V");
        dict.Add(10, "X");
        dict.Add(50, "L");
        dict.Add(100, "C");
        dict.Add(500, "D");
        dict.Add(1000, "M");

        if (dict.TryGetValue(numberToConvert, out string value))
        {
            return value;
        }

        string number = numberToConvert.ToString().TrimStart('0');
        int length = number.Length;

        var s = new StringBuilder();

        if (length >= 4)
        {
            int thousands = int.Parse(number[length - 4].ToString()) * 1000;
            if (thousands < 4000)
            {
                s.Append(RepeatChar('M', thousands / 1000));
            }
            else if (thousands >= 4000)
            {
                throw new ArgumentOutOfRangeException("Integer greater than 3999 are not supported.");
            }
        }

        if (length >= 3)
        {
            int hundreds = int.Parse(number[length - 3].ToString()) * 100;
            if (hundreds < 400)
            {
                s.Append(RepeatChar('C', hundreds / 100));
            }
            else if (hundreds == 400)
            {
                s.Append("CD");
            }
            else if (hundreds == 900)
            {
                s.Append("CM");
            }
            else
            {
                s.Append("D");
                s.Append(RepeatChar('C', (hundreds - 500) / 100));
            }
        }

        if (length >= 2)
        {
            int tens = int.Parse(number[length - 2].ToString()) * 10;
            if (tens < 40)
            {
                s.Append(RepeatChar('X', tens / 10));
            }
            else if (tens == 40)
            {
                s.Append("XL");
            }
            else if (tens == 90)
            {
                s.Append("XC");
            }
            else
            {
                s.Append("L");
                s.Append(RepeatChar('X', (tens - 50) / 10));
            }
        }

        int units = int.Parse(number[length - 1].ToString());
        if (units < 4)
        {
            s.Append(RepeatChar('I', units));
        }
        else if (units == 4)
        {
            s.Append("IV");
        }
        else if (units == 9)
        {
            s.Append("IX");
        }
        else
        {
            s.Append("V");
            s.Append(RepeatChar('I', units - 5));
        }

        return s.ToString();
    }

    public static string ConvertToRomanRecursive(int numberToConvert)
    {
        Validate(numberToConvert);

        if (IsEasterEgg(numberToConvert))
        {
            return "PASSIERSCHEIN A-XXXVIII";
        }

        return ConvertRecursive(numberToConvert);
    }

    # region Helper

    private static bool IsEasterEgg(int number)
    {
        if (number == 38)
        {
            return true;
        }

        return false;
    }

    private static void Validate(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Negative integers are not convertible");
        }

        if (number == 0)
        {
            throw new ArgumentOutOfRangeException("Zero is not convertible");
        }

        if (number >= 4000)
        {
            throw new ArgumentOutOfRangeException("Integer greater than 3999 are not supported.");
        }
    }

    private static string ConvertRecursive(int numberToConvert)
    {
        var dict = new Dictionary<int, char>();
        dict.Add(1, 'I');
        dict.Add(5, 'V');
        dict.Add(10, 'X');
        dict.Add(50, 'L');
        dict.Add(100, 'C');
        dict.Add(500, 'D');
        dict.Add(1000, 'M');

        var output = new StringBuilder();

        int leftDigit = GetLeftDigit(numberToConvert);
        int placeValue = CalculatePlaceValue(numberToConvert);
        int number = leftDigit * placeValue;

        if (number < (4 * placeValue))
        {
            output.Append(RepeatChar(dict[placeValue], number / placeValue));
        }
        else if (number == (4 * placeValue))
        {
            output.Append(dict[placeValue]);
            output.Append(dict[5 * placeValue]);
        }
        else if (number == (9 * placeValue))
        {
            output.Append(dict[placeValue]);
            output.Append(dict[10 * placeValue]);
        }
        else
        {
            output.Append(dict[5 * placeValue]);
            output.Append(RepeatChar(dict[placeValue], (number - 5 * placeValue) / placeValue));
        }

        var remainingNumber = GetRemainingNumber(numberToConvert);
        if (remainingNumber != -1)
        {
            return output.ToString() + ConvertRecursive(remainingNumber);
        }

        return output.ToString();
    }

    private static int GetRemainingNumber(int number)
    {
        var stringifiedNumber = number.ToString();
        var rest = RemoveFirstCharacter(stringifiedNumber);

        // todo: get rid of this hack
        if (rest.Length == 0)
        {
            return -1;
        }

        return int.Parse(rest);
    }

    private static int GetLeftDigit(int number)
    {
        var stringifiedNumber = number.ToString();
        return int.Parse(stringifiedNumber[0].ToString());

        // 3791 -> 3
        // 420 -> 4
        // 3 -> 3
    }

    private static int CalculatePlaceValue(int number)
    {
        var stringifiedNumber = number.ToString();
        return (int)Math.Pow(10, (stringifiedNumber.Length - 1));

        // same as:
        // if (stringifiedNumber.Length == 1) placeValue = 1;
        // if (stringifiedNumber.Length == 2) placeValue = 10;
        // if (stringifiedNumber.Length == 3) placeValue = 100;
        // if (stringifiedNumber.Length == 4) placeValue = 1000;
    }

    private static string RemoveFirstCharacter(string text)
    {
        return text.Remove(0, 1);
    }

    private static string RepeatChar(char character, int repetitions)
    {
        var s = new StringBuilder();

        for (int k = 0; k < repetitions; k++)
        {
            s.Append(character);
        }

        return s.ToString();
    }

    # endregion
}