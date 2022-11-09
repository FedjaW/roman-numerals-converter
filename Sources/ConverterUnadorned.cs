using System.Text;

public class ConverterUnadorned
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