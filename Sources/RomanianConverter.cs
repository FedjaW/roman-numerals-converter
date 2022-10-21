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

        Dictionary<int, string> m = new Dictionary<int, string>();
        m.Add(1, "I");
        m.Add(5, "V");
        m.Add(10, "X");
        m.Add(50, "L");
        m.Add(100, "C");
        m.Add(500, "D");
        m.Add(1000, "M");

        if (m.TryGetValue(numberToConvert, out string value))
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
                for (int k = 0; k < thousands / 1000; k++)
                {
                    s.Append("M");
                }
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
                for (int k = 0; k < hundreds / 100; k++)
                {
                    s.Append("C");
                }
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
                for (int k = 0; k < (hundreds - 500) / 100; k++)
                {
                    s.Append("C");
                }
            }
        }

        if (length >= 2)
        {
            int tens = int.Parse(number[length - 2].ToString()) * 10;
            if (tens < 40)
            {
                for (int k = 0; k < (tens / 10); k++)
                {
                    s.Append("X");
                }
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
                for (int k = 0; k < (tens - 50) / 10; k++)
                {
                    s.Append("X");
                }
            }
        }

        int units = int.Parse(number[length - 1].ToString());
        if (units < 4)
        {
            for (int k = 0; k < units; k++)
            {
                s.Append("I");
            }
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
            for (int k = 0; k < units - 5; k++)
            {
                s.Append("I");
            }
        }

        return s.ToString();
    }
}