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

    /// <summary>
    /// Sliding window approach
    /// start with start and end at 0
    /// as you go along, up the count of the character in an int array of 26 length
    /// update the maxOccurences of any character
    /// if the window size - maxOccurence is less than k, we have exhausted our flips and need to move window ahead
    /// when moving window ahead, move start and decrement the count of start number
    /// keep track of maxiumum result at the end by calculating window size and comparing with maximum
    /// </summary>
    /// <param name="s"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private int LongestRepeatingSubstring(string s, int k)
    {
        if (s.Length == 1) return 1;
        int start = 0, end = 0;
        
        // Keep a count of occurences of each character
        var countOfChars = new int[26];
        
        // Keep a count of maximum number of character occurences
        int countOfMaxOccurrencesPerChar = 0;
        int result = 0;

        while (end < s.Length)
        {
            // Get the current char
            int currChar = s[end];
            
            // Increment the occurrence of current char in the window
            countOfChars[currChar - 'A']++;

            // update max occurrences for any char to check for minimum flips needed
            countOfMaxOccurrencesPerChar = Math.Max(countOfMaxOccurrencesPerChar, countOfChars[currChar - 'A']);

            // If the number of flips is greater than k, this window is not possible
            if (end - start + 1 - countOfMaxOccurrencesPerChar > k)
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