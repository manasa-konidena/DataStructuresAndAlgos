namespace DataStructuresAndAlgos.StringsAndArrays;

public class PallindromePermutation
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsPalindromePossible("aab"));
    }

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
}