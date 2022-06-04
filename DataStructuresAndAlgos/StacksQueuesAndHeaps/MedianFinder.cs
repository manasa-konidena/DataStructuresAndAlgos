using DataStructuresAndAlgos.LinkedLists;

namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class MedianFinder
{
    private PriorityQueue<int, int> _maxHeapToHoldSmaller;
    private PriorityQueue<int, int> _minHeapToHoldLarger;

    public MedianFinder()
    {
        _maxHeapToHoldSmaller = new PriorityQueue<int, int>();
        _minHeapToHoldLarger = new PriorityQueue<int, int>(new CustomComparerForMaxHeap());
    }
    
    public void AddNum(int num) {
        _maxHeapToHoldSmaller.Enqueue(num, num);
        var currMaxOfSmalls = _maxHeapToHoldSmaller.Dequeue();
        
        _minHeapToHoldLarger.Enqueue(currMaxOfSmalls, currMaxOfSmalls);

        if (_minHeapToHoldLarger.Count > _maxHeapToHoldSmaller.Count)
        {
            var valueToBalance = _minHeapToHoldLarger.Dequeue();
            _maxHeapToHoldSmaller.Enqueue(valueToBalance, valueToBalance);
        }
    }
    
    public double FindMedian() {
        if (_maxHeapToHoldSmaller.Count > _minHeapToHoldLarger.Count)
        {
            return (double)_maxHeapToHoldSmaller.Peek();
        }
        else
        {
            return (_maxHeapToHoldSmaller.Peek() + _minHeapToHoldLarger.Peek()) * 0.5;
        }
    }
}


class CustomComparerForMaxHeap : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}