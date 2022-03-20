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

        //var actual = InsertNewInterval(input, newInterval);
        
        
        var input2 = new int[][]
            {new int[] {1, 3}, new int[] {6, 9}};

        var newInterval2 = new int[] {2, 5};
        var result2 = new int[][] {new int[] {1, 5}, new int[] {6, 9}};
        
        //var actual2 = InsertNewInterval(input2, newInterval2);

        var new1Start = SearchForTime(input, 4, 0, input.Length - 1);
        var new1End = SearchForTime(input, 8, 0, input.Length - 1);
        
        var new2Start = SearchForTime(input2, 2, 0, input2.Length - 1);
        var new2End = SearchForTime(input2, 5, 0, input2.Length - 1);
        
        var input3 = new int[][]
            {new int[] {1, 2}, new int[] {3, 5}, new int[] {6, 7}, new int[] {8, 10}, new int[] {13, 16}};
        
        var new3Start = SearchForTime(input3, 11, 0, input3.Length - 1);
        var new3End = SearchForTime(input3, 12, 0, input3.Length - 1);


    }

    private int[][] InsertNewInterval(int[][] schedule, int[] newInterval)
    {
        var intervalMatchingStart = SearchForTime(schedule, newInterval[0], 0, schedule.Length - 1);
        var intervalMatchingEnd = SearchForTime(schedule, newInterval[1], 0, schedule.Length - 1);
        
        // if the new interval is inside interval matching start time return schedule
        if (intervalMatchingStart == intervalMatchingEnd)
        {
            if(newInterval[0])
            
            return schedule;
        }
        
        // if new interval does not overlap, add new and return
        

        // if new interval start if overlapping with one and end with another , merge start and end

        // if new interval overlaps only with start, update start and return

        return null;


    }

    private int SearchForTime(int[][] schedule, int time, int start, int end)
    {
        if (start == end) return start;
        var mid = (start + end) / 2;
        if (time <= schedule[mid][1]) return SearchForTime(schedule, time, start, mid);
        else return SearchForTime(schedule, time, mid + 1, end);
    }
}