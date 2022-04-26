using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class LongestSubstringWithUniqueChars
{
    [Test]
    public void Test_LongestSubstring()
    {
        Assert.That(LongestSubstring("abcabcbb"), Is.EqualTo(3));
        Assert.That(LongestSubstring("bbbbbb"), Is.EqualTo(1));
        Assert.That(LongestSubstring("pwwkew"), Is.EqualTo(3));
        Assert.That(LongestSubstring("dvdf"), Is.EqualTo(3));
    }

    /// <summary>
    /// Sliding window approach
    /// either add the next character to the window or move the start to the last occurence of the next character
    /// keep a maximum to return at the end
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private int LongestSubstring(string s)
    {
        int maxLen = 0;
        string currString = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (!currString.Contains(s[i]))
            {
                currString += s[i];
            }
            else
            {
                var prevOccurrence = s.Substring(0, i).LastIndexOf(s[i]);
                currString = s.Substring(prevOccurrence + 1, i - prevOccurrence);
                
            }
            maxLen = Math.Max(maxLen, currString.Length);
        }

        return maxLen;
    }
}