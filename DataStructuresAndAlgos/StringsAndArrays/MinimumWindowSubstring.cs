using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MinimumWindowSubstring
{
    [Test]
    public void Test_MinimumWindowSubstring()
    {
        var input = "ADOBECODEBANC";
        var subInput = "ABC";
        //Assert.That(MinimumWindowSub(input, subInput), Is.EqualTo("BANC"));
        
        input = "abc";
        subInput = "bc";
        Assert.That(MinimumWindowSub(input, subInput), Is.EqualTo(""));
    }

    private string MinimumWindowSub(string s, string t)
    {
        if(s == t) return s;
        if (t.Length > s.Length) return "";
        
        int start = 0;
        var minHeap = new PriorityQueue<(char, int), int>();

        var countInS = new int[26];
        var countInT = new int[26];
        
        if((Char.IsLower(s, 0) && Char.IsUpper(t, 0)) || (Char.IsUpper(s, 0) && Char.IsLower(t, 0))) return "";

        var charToSubtract = Char.IsLower(s, 0) ? 'a' : 'A';

        var resultSubstring = "";
        var currSubstring = "";
        
        foreach (var c in t)
        {
            countInT[(int) c - charToSubtract]++;
        }

        int end;
        for (end = 0; end < s.Length; end++)
        {
            int charVal = s[end] - charToSubtract;
            if (countInT[charVal] > 0)
            {
                countInS[charVal]++;
                minHeap.Enqueue((s[end], end), end);

                if (CheckIfAllAreFilled(t, countInS, countInT))
                {
                    currSubstring = s.Substring(start, end - start + 1);

                    if (resultSubstring == "") resultSubstring = currSubstring;
                    else resultSubstring = resultSubstring.Length > currSubstring.Length ? currSubstring : resultSubstring;

                    if (minHeap.Count > 1)
                    {
                        var toRemoveFromWin = minHeap.Dequeue();
                        var toMoveStartTo = minHeap.Peek();

                        countInS[toRemoveFromWin.Item1 - charToSubtract]--;
                        start = toMoveStartTo.Item2;
                    }
                }
            }
        }
        
        if (CheckIfAllAreFilled(t, countInS, countInT))
        {
            currSubstring = s.Substring(start, end - start);

            if (resultSubstring == "") resultSubstring = currSubstring;
            else resultSubstring = resultSubstring.Length > currSubstring.Length ? currSubstring : resultSubstring;
            
            if (minHeap.Count > 1)
            {
                var toRemoveFromWin = minHeap.Dequeue();
                var toMoveStartTo = minHeap.Peek();

                countInS[toRemoveFromWin.Item1 - charToSubtract]--;
                start = toMoveStartTo.Item2;
                
                if(CheckIfAllAreFilled(t, countInS, countInT))
                {
                    currSubstring = s.Substring(start, end - start);

                    if (resultSubstring == "") resultSubstring = currSubstring;
                    else resultSubstring = resultSubstring.Length > currSubstring.Length ? currSubstring : resultSubstring;
                }
                
            }
            
        }

        if (resultSubstring.Length > t.Length && t.Length == 1)
        {
            return t;
        }

        return resultSubstring;
    }

    private bool CheckIfAllAreFilled(string t, int[] occurrenceInS, int[] occurrenceInT)
    {
        var charToSubtract = Char.IsLower(t, 0) ? 'a' : 'A';
        foreach (var c in t)
        {
            if (occurrenceInS[c - charToSubtract] < occurrenceInT[c - charToSubtract]) return false;
        }

        return true;

    }

}