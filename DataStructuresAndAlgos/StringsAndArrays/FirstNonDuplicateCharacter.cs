using NUnit.Framework;
using System.Collections.Specialized;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class FirstNonDuplicateCharacter
{
    [Test]
    public void Test_FirstNonRepChar()
    {
        var input = "itwasagrimdaytoday";
        Assert.That(FirstUniqChar(input), Is.EqualTo(2));

    }
    
    public int FirstUniqChar(string s)
    {

        var charDict = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (charDict.TryGetValue(c, out var ct)) charDict[c] = ct + 1;
            else charDict.Add(c, 1);
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (charDict[s[i]] == 1) return i;
        }

        return -1;

    }
}