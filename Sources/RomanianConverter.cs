using System.Text;

public class RomanianConverter
{
    public static string Convert(int numberToConvert)
    {
        if (numberToConvert < 0)
        {
            throw new ArgumentOutOfRangeException("Negative integers are not convertible");
        }

        if (numberToConvert == 0)
        {
            return "PASSIERSCHEIN A-XXXVIII";
        }

        string number = numberToConvert.ToString().TrimStart('0');
        int length = number.Length;

        int einer = int.Parse(number[length - 1].ToString());

        int zehner = -1;
        int hunderter = -1;
        int tausender = -1;

        if (length >= 2)
        {
            zehner = int.Parse(number[length - 2].ToString()) * 10;
        }
        if (length >= 3)
        {
            hunderter = int.Parse(number[length - 3].ToString()) * 100;
        }
        if (length >= 4)
        {
            tausender = int.Parse(number[length - 4].ToString()) * 1000;
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

        var s = new StringBuilder();

        if (tausender < 4000)
        {
            for (int k = 0; k < tausender / 1000; k++)
            {
                s.Append("M");
            }
        }
        else if (tausender >= 4000)
        {
            throw new ArgumentOutOfRangeException("Integer greater than 3999 are not supported.");
        }

        if (hunderter < 400)
        {
            for (int k = 0; k < hunderter / 100; k++)
            {
                s.Append("C");
            }
        }
        else if (hunderter == 400)
        {
            s.Append("CD");
        }
        else if (hunderter == 900)
        {
            s.Append("CM");
        }
        else
        {
            s.Append("D");
            for (int k = 0; k < (hunderter - 500) / 100; k++)
            {
                s.Append("C");
            }
        }


        if (zehner < 40)
        {
            for (int k = 0; k < (zehner / 10); k++)
            {
                s.Append("X");
            }
        }
        else if (zehner == 40)
        {
            s.Append("XL");
        }
        else if (zehner == 90)
        {
            s.Append("XC");
        }
        else
        {
            s.Append("L");
            for (int k = 0; k < (zehner - 50) / 10; k++)
            {
                s.Append("X");
            }
        }

        if (einer < 4)
        {
            for (int k = 0; k < einer; k++)
            {
                s.Append("I");
            }
        }
        else if (einer == 4)
        {
            s.Append("IV");
        }
        else if (einer == 9)
        {
            s.Append("IX");
        }
        else
        {
            s.Append("V");
            for (int k = 0; k < einer - 5; k++)
            {
                s.Append("I");
            }
        }

        return s.ToString();
    }
}