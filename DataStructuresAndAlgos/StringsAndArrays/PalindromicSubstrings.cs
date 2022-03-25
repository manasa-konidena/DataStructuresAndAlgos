using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class PalindromicSubstrings
{
    [Test]
    public void Test_PalindromincSubstrings()
    {
        Assert.That(CountSubstrings("aaa"), Is.EqualTo(6));
        Assert.That(CountSubstrings("xabax"), Is.EqualTo(7));
    }

    public int CountSubstrings(string s)
    {
        int[][] matrixForMemo = new int[s.Length][];
        int result = s.Length;
        int len = s.Length;
        int i = 0;
        while (i < len)
        {
            matrixForMemo[i] = new int[s.Length];
            i++;
        }

        int starts = 0, ends = 0;
        while (starts < len && ends < len)
        {
            matrixForMemo[starts][ends] = 1;
            starts++;
            ends++;
        }

        starts = ends = 0;
        while (ends < len)
        {
            while (starts <= ends)
            {
                if (ends - starts == 1 && s[starts] == s[ends])
                {
                    matrixForMemo[starts][ends] = 1;
                    result++;
                }
                else if(ends - starts > 1)
                {
                    var nextsmaller = matrixForMemo[starts + 1][ends - 1];
                    if (nextsmaller == 1 && s[starts] == s[ends])
                    {
                        matrixForMemo[starts][ends] = 1;
                        result++;
                    }
                }
                
                starts++;
            }
            ends++;
            starts = 0;
        }

        return result;
    }
    
}