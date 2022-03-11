using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class Anagram
{

    [Test]
    public void Test_Anagram()
    {
        Assert.IsTrue(IsAnagram("anagram", "nagaram"));
    }

    public bool IsAnagram(string s, string t)
    {

        var firstCount = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (firstCount.TryGetValue(c, out var ct)) firstCount[c] = ct + 1;
            else firstCount.Add(c, 1);
        }

        foreach (var c in t)
        {
            if (firstCount.TryGetValue(c, out var ct))
            {
                if (ct - 1 < 0) return false;
                firstCount[c] = ct - 1;
            }

            else return false;
        }

        return firstCount.Values.ToHashSet().Count == 1 && firstCount.Values.ToHashSet().First() == 0;
    }
}