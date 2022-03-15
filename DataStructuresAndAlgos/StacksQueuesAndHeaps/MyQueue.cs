namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class MyQueue
{
    private Stack<int> first;
    private Stack<int> second;
    
    public MyQueue()
    {
        first = new Stack<int>();
        second = new Stack<int>();
    }
    
    public void Push(int x) {
        while (first.Count != 0)
        {
            second.Push(first.Pop());
        }
        
        first.Push(x);
        
        while (second.Count != 0)
        {
            first.Push(second.Pop());
        }
    }
    
    public int Pop()
    {
        return first.Pop();
    }
    
    public int Peek()
    {
        return first.Peek();
    }
    
    public bool Empty()
    {
        return first.Count == 0;
    }
}