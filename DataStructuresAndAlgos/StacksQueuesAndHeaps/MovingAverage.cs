namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class MovingAverage {
    Queue<int> slidingWindow;
    int currSize;
    int maxSize;
    int currentWindowSum;

    public MovingAverage(int size) {
        slidingWindow = new Queue<int>();
        maxSize = size;
        currSize = 0;
    }
    
    public double Next(int val) {
        if(currSize < maxSize)
        {
            slidingWindow.Enqueue(val);
            currSize++;
        }
        else
        {
            var toRemove = slidingWindow.Dequeue();
            currentWindowSum -= toRemove;
            
            slidingWindow.Enqueue(val);
            
        }
        currentWindowSum += val;
        return (double)currentWindowSum / (double)currSize;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */