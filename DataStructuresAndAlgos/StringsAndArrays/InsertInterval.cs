using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class InsertInterval
{
    [Test]
    public void Test_InsertInterval()
    {
        var input = new int[][]
            {new int[] {1, 2}, new int[] {3, 5}, new int[] {6, 7}, new int[] {8, 10}, new int[] {12, 16}};

        var newInterval = new int[] {4, 8};
        var result = new int[][] {new int[] {1, 2}, new int[] {3, 10}, new int[] {12, 16}};

        var actual = InsertNewInterval(input, newInterval);

        var input2 = new int[][]
            {new int[] {1, 3}, new int[] {6, 9}};

        var newInterval2 = new int[] {2, 5};
        var result2 = new int[][] {new int[] {1, 5}, new int[] {6, 9}};
        
        var actual2 = InsertNewInterval(input2, newInterval2);

    }

    private int[][] InsertNewInterval(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        bool added = false;

        foreach (var interval in intervals)
        {
            // If there is an overlap - one starts before the other ends
            if (newInterval[1] >= interval[0] && newInterval[0] <= interval[1])
            {
                newInterval = new int[] {Math.Min(interval[0], newInterval[0]), Math.Max(interval[1], newInterval[1])};
            }
            else if (newInterval[0] > interval[1])
            {
                result.Add(interval);
            }
            else if (newInterval[1] < interval[0])
            {
                if (!added)
                {
                    result.Add(newInterval);
                    added = true;
                }

                result.Add(interval);
            }
        }

        if(!added) result.Add(newInterval);
        return result.ToArray();
    }
}