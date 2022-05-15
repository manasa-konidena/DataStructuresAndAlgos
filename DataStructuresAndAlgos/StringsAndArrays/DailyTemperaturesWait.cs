using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class DailyTemperaturesWait
{
    [Test]
    public void Test_DailyTemperatures()
    {
        var result = DailyTemperatures(new int[] {73, 74, 75, 71, 69, 72, 76, 73});
    }
    
    public int[] DailyTemperatures(int[] temperatures) {
        
        int[] result = new int[temperatures.Length];
        int[] targetTempIndices = new int[temperatures.Length];
        result[temperatures.Length - 1] = 0;
        targetTempIndices[temperatures.Length - 1] = -1;
        
        for(int i = temperatures.Length - 2; i >= 0; i--)
        {
            if(temperatures[i] < temperatures[i + 1])
            {
                result[i] = 1;
                targetTempIndices[i] = i + 1;
            }
            else
            {
                int indexForNextPossibleDay = i + 1;
                
                while(indexForNextPossibleDay < temperatures.Length - 1)
                {
                    if (targetTempIndices[indexForNextPossibleDay] == -1)
                    {
                        break;
                    }

                    int nextPossibleDayTempIndex = targetTempIndices[indexForNextPossibleDay];
                    int nextPossibleDayTemp = temperatures[nextPossibleDayTempIndex];
                    if(nextPossibleDayTemp > temperatures[i])
                    {
                        result[i] = nextPossibleDayTempIndex - i;
                        targetTempIndices[i] = nextPossibleDayTempIndex;
                        break;
                    }
                    indexForNextPossibleDay++;
                }
                
                if(result[i] == 0) targetTempIndices[i] = -1;
            }
        }
        
        return result;
        
    }
}