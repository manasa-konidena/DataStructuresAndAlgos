using System.Collections;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MergeIntervals
{
    [Test]
    public void Test_MergeIntervals()
    {
        var input = new int[][]{new int[] {1, 4}, new int[] {0, 2}, new int[]{3, 5}};
        var output = new int[][] {new int[] {0, 5}};

        var actual = Merge(input);
        
        var input2 = new int[][] {new int[] {0, 30}, new[] {5, 10}, new[] {15, 20}};
        var actual2 = Merge(input2);

    }

    private static int CompareArrays(int[] one, int[] two)
    {
        return one[0].CompareTo(two[0]) == 0 ? one[1].CompareTo(two[1]) : one[0].CompareTo(two[0]);
    }

    
    /// <summary>
    /// Complexity is nlogn - sorting plus iterating through the array once
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, CompareArrays);
        var result = new List<int[]>();

        if (intervals.Length == 0 || intervals.Length == 1) return intervals;

        var currInterval = intervals[0];
        int i = 1;
        while(i < intervals.Length)
        {
            if (currInterval[0] <= intervals[i][1] && intervals[i][0] <= currInterval[1])
            {
                currInterval = new int[]
                    {Math.Min(currInterval[0], intervals[i][0]), Math.Max(currInterval[1], intervals[i][1])};
                i++;
            }
            
            else
            {
                result.Add(currInterval);
                currInterval = intervals[i];
                i++;
            }

        }
        result.Add(currInterval);
        return result.ToArray();

    }
}