using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class RomanToInteger
{
    [Test]
    public void Test_RomanToInteger()
    {
        Assert.That(ConvertRomanToInteger("MCMXCIV"), Is.EqualTo(1994));
        Assert.That(ConvertRomanToInteger("MCDLXXVI"), Is.EqualTo(1476));

    }


    public int ConvertRomanToInteger(string roman)
    {
        int result = 0;

        var romanToValueDict = new Dictionary<char, int>();
        romanToValueDict.Add('I', 1);
        romanToValueDict.Add('V', 5);
        romanToValueDict.Add('X', 10);
        romanToValueDict.Add('L', 50);
        romanToValueDict.Add('C', 100);
        romanToValueDict.Add('D', 500);
        romanToValueDict.Add('M', 1000);
        
        result += romanToValueDict[roman[roman.Length - 1]];
        

        //MCMXCIV
        // 5 + (-1) + 100 + (-10) + 1000 + (-100) + 1000
        for (int i = roman.Length - 2; i >= 0; i--)
        {
            switch (roman[i])
            {
                case 'I':
                    if (roman[i + 1] == 'V') result--;
                    else if (roman[i + 1] == 'X') result--;
                    else result++;
                    break;
                case 'V':
                    result += 5;
                    break;
                case 'X':
                    if (roman[i + 1] == 'L') result -= 10;
                    else if (roman[i + 1] == 'C') result -= 10;
                    else result += 10;
                    break;
                case 'L':
                    result += 50;
                    break;
                case 'C':
                    if (roman[i + 1] == 'D') result -= 100;
                    else if (roman[i + 1] == 'M') result -= 100;
                    else result += 100;
                    break;
                case 'D':
                    result += 500;
                    break;
                case 'M':
                    result += 1000;
                    break;
            }
        }

        return result;
    }
}