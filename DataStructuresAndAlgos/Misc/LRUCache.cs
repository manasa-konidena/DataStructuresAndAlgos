using System.Collections.Specialized;
using NUnit.Framework;

namespace DataStructuresAndAlgos.Misc;

public class TestSol
{
    [Test]
    public void Test_LRUCache()
    {
        /*["LRUCache","put","put","get","put","get","put","get","get","get"]
[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]*/

        var lruCache = new LRUCache(2);
        lruCache.Put(1,1); // [1, (1,1)] ----- (1,1)
        lruCache.Put(2,2); // [(1, (1,1)), (2, (2,2))] ----- (2,2) -> (1, 1)
        lruCache.Get(1); // re 1 [(1, (1,1)), (2, (2,2))] ----- (1,1) -> (2,2) 
        lruCache.Put(3,3); // [(3, (3,3)), (1, (1,1))] ----- (3,3) -> (1,1)
        lruCache.Get(2); // -1
        lruCache.Put(4,4); // [(4, (4,4)), (1, (1,1))] ----- (4,4) -> (3, 3)
        lruCache.Get(1); // re -1
        lruCache.Get(3);
        lruCache.Get(4);
    }
}


public class LRUCache
{

    private LinkedList<(int, int)> _listOfEntries;
    private Dictionary<int, LinkedListNode<(int, int)>> _cache;
    private int _capacity;
    
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<(int, int)>>();
        _listOfEntries = new LinkedList<(int, int)>();
    }
    
    public int Get(int key)
    {
        if (!_cache.ContainsKey(key)) return -1;

        var toReturn = _cache[key];

        _listOfEntries.Remove(toReturn);
        _listOfEntries.AddFirst(toReturn);

        return toReturn.Value.Item2;

    }
    
    public void Put(int key, int value) 
    {
        if (_cache.ContainsKey(key))
        {
            var currVal = _cache[key];
            _listOfEntries.Remove(currVal);

            _cache[key] = new LinkedListNode<(int, int)>((key, value));
            _listOfEntries.AddFirst(_cache[key]);
        }
        else
        {
            if (_cache.Count == _capacity)
            {
                var toRemove = _listOfEntries.Last;
                _cache.Remove(toRemove.Value.Item1);
                _listOfEntries.Remove(toRemove);
            }
            
            var toAdd = new LinkedListNode<(int, int)>((key, value));
            _cache.Add(key, toAdd);
            _listOfEntries.AddFirst(toAdd);
        }

    }
}