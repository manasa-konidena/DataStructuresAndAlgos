namespace DataStructuresAndAlgos.StringsAndArrays;

public class WordDistance
{
    private Dictionary<string, List<int>> wordToIndices;

    public WordDistance(string[] wordsDict)
    {
        wordToIndices = new Dictionary<string, List<int>>();
        for(int i = 0; i < wordsDict.Length; i++)
        {
            if (wordToIndices.TryGetValue(wordsDict[i], out var locations))
            {
                locations.Add(i);
            }
            else wordToIndices.Add(wordsDict[i], new List<int>{i});
        }
        
    }

    public int Shortest(string word1, string word2)
    {
        var loc1 = wordToIndices[word1];
        var loc2 = wordToIndices[word2];

        var shortedDist = Int32.MaxValue;
        int i = 0, j = 0;

        while (i < loc1.Count && j < loc2.Count)
        {
            var currDist = Math.Abs(loc1[i] - loc2[j]);
            shortedDist = Math.Min(currDist, shortedDist);

            if (loc1[i] < loc2[i]) i++;
            else j++;
        }

        return shortedDist;

    }
}