using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class RansomNote
{

    [Test]
    public void Test_CanConstructRansomNote()
    {
        var ransomNote = "hello";
        var magazine = "hellomate";
        
        Assert.IsTrue(CanConstruct(ransomNote, magazine));
    }

    public bool CanConstruct(string ransomNote, string magazine)
    {

        var magazineCount = new Dictionary<char, int>();

        foreach (var c in magazine)
        {
            if (magazineCount.TryGetValue(c, out var ct)) magazineCount[c] = ct + 1;
            else magazineCount.Add(c, 1);
        }

        foreach (var c in ransomNote)
        {
            if (magazineCount.TryGetValue(c, out var ct))
            {
                if (ct <= 0) return false;
                magazineCount[c] = ct - 1;
            }
            else return false;
        }

        return true;

    }
}