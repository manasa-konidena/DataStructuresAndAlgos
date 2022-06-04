namespace DataStructuresAndAlgos.StringsAndArrays;

public class LongestConsecutiveSequence
{
    public int GetLongestConsecutiveSequence(int[] nums)
    {
        var numToSequenceDict = new Dictionary<int, int>();
        int result = 0;

        foreach(int num in nums)
        {
            if(!numToSequenceDict.ContainsKey(num))
            {
                 int left = numToSequenceDict.ContainsKey(num - 1) ? numToSequenceDict[num - 1] : 0;
                int right = numToSequenceDict.ContainsKey(num + 1) ? numToSequenceDict[num + 1] : 0;

                var currSum = left + right + 1;
                numToSequenceDict.Add(num, currSum);

                result = Math.Max(currSum, result);

                numToSequenceDict[num - left] = currSum;
                numToSequenceDict[num + right] = currSum;
            }

        }

        return result;
    }
    
    public int GetLongestConsecutiveSequence_Simpler(int[] nums)
    {
        var numsSet = new HashSet<int>(nums);
        int maxSeq = 0;

        foreach (var num in nums)
        {
            if (!numsSet.Contains(num - 1))
            {
                var currSeq = 1;
                var currNum = num;
                while (numsSet.Contains(currNum + 1))
                {
                    currSeq++;
                    currNum++;
                }

                maxSeq = Math.Max(currSeq, maxSeq);
            }

        }

        return maxSeq;

    }

    public int LongestConsecutiveSeq_Revision(int[] nums)
    {
        var dictOfSeqCount = new Dictionary<int, int>();
        var result = 0;

        foreach (var num in nums)
        {
            if (!dictOfSeqCount.ContainsKey(num))
            {
                var leftSeq = dictOfSeqCount.ContainsKey(num - 1) ? dictOfSeqCount[num - 1] : 0;
                var rightSeq = dictOfSeqCount.ContainsKey(num + 1) ? dictOfSeqCount[num + 1] : 0;

                var sum = leftSeq + rightSeq + 1;
                
                dictOfSeqCount.Add(num, sum);

                dictOfSeqCount[num - leftSeq] = sum;
                dictOfSeqCount[num + rightSeq] = sum;

                result = Math.Max(result, sum);
            }
            
        }

        return result;


    }
}