using NUnit.Framework;

namespace DataStructuresAndAlgos.Graphs;

public class LadderLengthGraph
{
    [Test]
    public void Test_LadderLength()
    {
        // beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
        Assert.AreEqual(5, LadderLength("hit", "cog", new List<string> {"hot", "dot", "dog", "lot", "log", "cog"}));
    }
    
    /// <summary>
    /// BFS
    /// create an adjacency list for each intermediate word wildcards to a list of word that have 1 hop to them
    /// Once done, start with the begin word and get to the end word by doing a BFS and looking through the adjacent list of
    /// all possible wild cards
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        int wordLen = beginWord.Length;
        var intermediateWordsDict = new Dictionary<string, List<string>>();
        foreach(var word in wordList)
        {
            for(int i = 0; i < wordLen; i++)
            {
                var newOption = (i == wordLen - 1) ? $"{word.Substring(0, i)}*" :  $"{word.Substring(0, i)}*{word.Substring(i + 1)}";
                if(intermediateWordsDict.TryGetValue(newOption, out List<string> intermediatesList))
                {
                    intermediatesList.Add(word);
                }
                else intermediateWordsDict.Add(newOption, new List<string>{word});
            }    
        }
        
        var visited = new HashSet<string>();
        var wordAndLevelQueue = new Queue<(string, int)>();
        
        wordAndLevelQueue.Enqueue((beginWord, 1));
        
        while(wordAndLevelQueue.Count != 0)
        {
            var currNode = wordAndLevelQueue.Dequeue();
            var currWord = currNode.Item1;
            var currLevel = currNode.Item2;
            
            if(visited.Contains(currWord)) continue;
            visited.Add(currWord);
            
            for(int i = 0; i < wordLen; i++)
            {
                var possibleOption = (i == wordLen - 1) ? $"{currWord.Substring(0, i)}*" : $"{currWord.Substring(0, i)}*{currWord.Substring(i + 1)}";
                if(intermediateWordsDict.TryGetValue(possibleOption, out var adjacentNodes))
                {
                    foreach(var node in adjacentNodes)
                    {
                        if(node.Equals(endWord)) return currLevel + 1;
                        wordAndLevelQueue.Enqueue((node, currLevel + 1));
                    }
                }
            }  
        }
        
        return 0;
    }
}