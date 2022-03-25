using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MeetingRoomsII
{
    [Test]
    public void Test_MeetingRooms()
    {
        var input = new int[][] {new int[] {0, 30}, new[] {5, 10}, new[] {15, 20}};
        var output = 2;
        
        Assert.That(MinMeetingRooms(input), Is.EqualTo(2));
    }
    

    private static int CompareArrays(int[] one, int[] two)
    {
        return one[0].CompareTo(two[0]) == 0 ? one[1].CompareTo(two[1]) : one[0].CompareTo(two[0]);
    }

    private int MinMeetingRooms(int[][] intervals)
    {
        Array.Sort(intervals, CompareArrays);

        if (intervals.Length == 0) return 0;
        if (intervals.Length == 1) return 1;


        var minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(intervals[0][1], intervals[0][1]);

        int i = 1;
        while (i < intervals.Length)
        {
            var lastRoom = minHeap.Peek();

            if (intervals[i][0] >= lastRoom)
            {
                minHeap.Dequeue();
                minHeap.Enqueue(intervals[i][1], intervals[i][1]);
            }
            else
            {
                minHeap.Enqueue(intervals[i][1], intervals[i][1]);
            }

            i++;
        }

        return minHeap.Count;

    }
}