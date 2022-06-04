using System.Diagnostics.Tracing;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ShortestDistance
{
    public int GetShortestDistance(string[] wordsDict, string word1, string word2)
    {
        Dictionary<string, List<int>> wordsToIndices = new Dictionary<string, List<int>>();
        
        for ( int i = 0; i < wordsDict.Length; i++)
        {
            if (wordsToIndices.TryGetValue(wordsDict[i], out var indices))
            {
                indices.Add(i);
            }
            else wordsToIndices.Add(wordsDict[i], new List<int> {i});
        }

        var loc1 = wordsToIndices[word1];
        var loc2 = wordsToIndices[word2];

        int p = 0, q = 0;
        int shortestDic = Int32.MaxValue;
        while (p < loc1.Count && q < loc2.Count)
        {
            shortestDic = Math.Min(shortestDic, Math.Abs(loc1[p] - loc2[q]));
            if (loc1[p] < loc2[q]) p++;
            else q++;
        }

        return shortestDic;
    }

    public int ShortestDistanceSimpler(string[] wordsDict, string word1, string word2)
    {
        int l1 = -1, l2 = -1;
        int minDist = Int32.MaxValue;
        for (int i = 0; i < wordsDict.Length; i++)
        {
            if (wordsDict[i] == word1) l1 = i;
            if (wordsDict[i] == word2) l2 = i;

            if (l1 != -1 && l2 != -1)
            {
                minDist = Math.Min(minDist, Math.Abs(l1 - l2));
            }
            
        }

        return minDist;
    }
}