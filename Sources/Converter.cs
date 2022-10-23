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
                // 4 * 10 = 40
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


    private static StringBuilder output = new StringBuilder();

    public static string ConvertRecursive(int numberToConvert)
    {
        if (numberToConvert < 0)
        {
            throw new ArgumentOutOfRangeException("Negative integers are not convertible");
        }

        if (numberToConvert == 0)
        {
            return "PASSIERSCHEIN A-XXXVIII";
        }

        if (numberToConvert >= 4000)
        {
            throw new ArgumentOutOfRangeException("Integer greater than 3999 are not supported.");
        }

        var dict = new Dictionary<int, char>();
        dict.Add(1, 'I');
        dict.Add(5, 'V');
        dict.Add(10, 'X');
        dict.Add(50, 'L');
        dict.Add(100, 'C');
        dict.Add(500, 'D');
        dict.Add(1000, 'M');

        var stringifiedNumber = numberToConvert.ToString();
        int frontNumber = int.Parse(stringifiedNumber[0].ToString());

        int placeValue = (int)Math.Pow(10, (stringifiedNumber.Length - 1));
        // if (stringifiedNumber.Length == 1) placeValue = 1;
        // if (stringifiedNumber.Length == 2) placeValue = 10;
        // if (stringifiedNumber.Length == 3) placeValue = 100;
        // if (stringifiedNumber.Length == 4) placeValue = 1000;

        int number = frontNumber * placeValue;
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
            output.Append(dict[(4 + 1) * placeValue]);
            output.Append(RepeatChar(dict[placeValue], (number - 5 * placeValue) / placeValue));
        }

        var rest = stringifiedNumber.Remove(0, 1);

        if (rest.Length > 0)
        {
            var restNumber = int.Parse(rest);
            ConvertRecursive(restNumber);
        }

        return output.ToString();
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
}