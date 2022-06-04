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

    public bool IsAnagramRevision(string s, string t)
    {
        Dictionary<char, int> charDict = new Dictionary<char, int>();
        
        if(s.Length != t.Length) return false;
        
        for(int i = 0; i < s.Length; i++)
        {
            if(charDict.TryGetValue(s[i], out int occurrs)) charDict[s[i]] += 1;
            else charDict.Add(s[i], 1);
            
            if(charDict.TryGetValue(t[i], out int tOccurrs)) charDict[t[i]] -= 1;
            else charDict.Add(t[i], -1);
        }
        
        foreach(var count in charDict.Values)
        {
            if(count != 0) return false;
        }
        
        return true;
    }
}