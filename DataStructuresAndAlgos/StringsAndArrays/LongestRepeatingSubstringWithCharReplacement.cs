using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class LongestRepeatingSubstringWithCharReplacement
{
    [Test]
    public void Test_LongestRepeatingSubstring()
    {
        Assert.That(LongestRepeatingSubstring("AABABBA", 1), Is.EqualTo(4));
        Assert.That(LongestRepeatingSubstring("ABAB", 2), Is.EqualTo(4));
    }

    private int LongestRepeatingSubstring(string s, int k)
    {
        if (s.Length == 1) return 1;
        int start = 0, end = 0;
        
        // Keep a count of occurences of each character
        var countOfChars = new int[26];
        
        // Keep a count of maximum number of character occurences
        int countOfMaxUniques = 0;
        int result = 0;

        while (end < s.Length)
        {
            // Get the current char
            int currChar = s[end];
            
            // Increment the occurrence of current char in the window
            countOfChars[currChar - 'A']++;

            // update max occurrences for any char to check for minimum flips needed
            countOfMaxUniques = Math.Max(countOfMaxUniques, countOfChars[currChar - 'A']);

            // If the number of flips is greater than k, this window is not possible
            if (end - start + 1 - countOfMaxUniques > k)
            {
                // If moving window ahead, adjust thw occurrences in window
                countOfChars[s[start] - 'A']--;
                start++;
            }

            // Keep a count of max window
            result = Math.Max(result, end - start + 1);
            
            end++;

        }

        return result;
    }
}