namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class MaxStack
{
    private Stack<int> maxStack;
    private Stack<int> regularStack;

    public MaxStack()
    {
        maxStack = new Stack<int>();
        regularStack = new Stack<int>();

    }
    
    public void Push(int x)
    {
        int currMax = maxStack.Count == 0 ? x : maxStack.Peek();
        int newMax = x > currMax ? x : currMax;
        
        maxStack.Push(newMax);
        regularStack.Push(x);
    }
    
    public int Pop()
    {
        maxStack.Pop();
        return regularStack.Pop();
    }
    
    public int Top()
    {
        return regularStack.Count == 0 ? 0 : regularStack.Peek();
    }
    
    public int PeekMax()
    {
        return maxStack.Count == 0 ? 0  : maxStack.Peek();
    }
    
    public int PopMax()
    {
        var tempStack = new Stack<int>();
        int max = PeekMax();

        while (Top() != max)
        {
            tempStack.Push(Pop());
        }

        Pop();
        while(tempStack.Count != 0) Push(tempStack.Pop());

        return max;
    }
}