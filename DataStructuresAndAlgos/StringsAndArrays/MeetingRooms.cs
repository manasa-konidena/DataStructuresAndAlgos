using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MeetingRooms
{
    [Test]
    public void Test_MeetingRooms()
    {
        var input = new int[][] {new int[] {0, 30}, new[] {5, 10}, new[] {15, 20}};
        var output = false;
        
        Assert.IsFalse(CanAttendAllMeetings(input));
    }
    
    private static int CompareArrays(int[] one, int[] two)
    {
        return one[0].CompareTo(two[0]) == 0 ? one[1].CompareTo(two[1]) : one[0].CompareTo(two[0]);
    }

    private bool CanAttendAllMeetings(int[][] intervals)
    {
        Array.Sort(intervals, CompareArrays);

        if (intervals.Length == 0 || intervals.Length == 1) return true;

        var currInterval = intervals[0];
        int i = 1;
        while(i < intervals.Length)
        {
            if (currInterval[0] < intervals[i][1] && intervals[i][0] < currInterval[1])
            {
                return false;
            }
            
            currInterval = intervals[i];
            i++;
        }

        return true;


    }
}