using System.Text;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class IntegerToRoman
{
    [Test]
    public void Test_IntegerToRoman()
    {
        Assert.That(ConvertIntegerToRoman(58), Is.EqualTo("LVIII"));
    }

    /// <summary>
    /// Another approach
    /// Map of all the values
    /// get thousands digit, hundreds digit, tens and ones digits to map to the right alphabet
    /// </summary>
    private string ConvertIntToRoman(int num)
    {
        string[] thousands = {"", "M", "MM", "MMM"};
        string[] hundreds = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
        string[] tens = {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
        string[] ones = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};

        return thousands[num / 1000] + hundreds[(num / 1000) % 100] + tens[(num / 100) % 10] + ones[(num % 10)];
    }

    private string ConvertIntegerToRoman(int num)
    {

        string[] romans = new string[] {"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};
        int[] values = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};

        // 1994
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < romans.Length && num > 0; i++)
        {
            while (values[i] <= num)
            {
                num -= values[i];
                sb.Append(romans[i]);
            }
        }

        return sb.ToString();

    }

}