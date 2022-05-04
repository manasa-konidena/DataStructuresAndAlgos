using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class LongestCommonPrefix
{
    [Test]
    public void Test_LongestCommonPrefix()
    {
        
    }


    private string GetLongestCommonPrefix(string[] strs)
    {
        var first = strs[0];
        for (int i = 0; i < first.Length; i++)
        {
            // CHeck each string in strs for the ith char
            // if even one doest have resutl first.substring
            // else return first
            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length) return first.Substring(0, i);
                if (first[i] != strs[j][i]) return first.Substring(0, i);
            }
        }

        return first;

    }

}