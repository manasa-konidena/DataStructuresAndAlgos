using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class PalindromePermutation
{
    [Test]
    public void Test_PalindromePerm()
    {
        Assert.IsTrue(IsPalindromePossible("aab"));
        Assert.IsTrue(IsPalindromePossibleV2("aab"));
    }

    /// <summary>
    ///  Checks if any permutation of a string can be a palindrome
    /// SC O(n) TC (O(n))t
    /// </summary>
    private static bool IsPalindromePossible(string s)
    {
        Dictionary<char, int> countOfChars = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if(countOfChars.TryGetValue(c, out var count)) countOfChars[c] = count+1 ;
            else countOfChars.Add(c, 1);
        }

        int oddsCount = 0;
        foreach (var count in countOfChars.Values)
        {
            if (count % 2 == 1) oddsCount++;
        }

        if (oddsCount > 1) return false;

        return true;
    }

    /// <summary>
    /// This approach uses a Set to keep track of the extra letters. If at the end only 1 or nonw remains, its possible
    /// </summary>
    private static bool IsPalindromePossibleV2(string s)
    {
        HashSet<char> charSet = new HashSet<char>();

        foreach (char c in s)
        {
            if (!charSet.Add(c)) charSet.Remove(c);
            else charSet.Add(c);
        }

        return charSet.Count <= 1;
    }
}