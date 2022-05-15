namespace DataStructuresAndAlgos.Misc;

/// <summary>
///  Maintain a linkedlist to get access to first and last
/// keep updating totalhits and linked lists when you get hits
/// when you are asked to get total hits, ensure the diff is < 300(the max time for the hits)
///     while there are timestamp entries in the linkedlist
///     caclulate the current diff in timestamps
///     if its more than required, update total hits and remove from linked list
///     if not break and return total hits
/// </summary>
public class HitCounter
{
    private LinkedList<(int, int)> _hitCountByTimestamp;
    private int _totalHits;

    public HitCounter()
    {
        _hitCountByTimestamp = new LinkedList<(int, int)>();
        _totalHits = 0;
    }
    
    public void Hit(int timestamp)
    {
        if (_hitCountByTimestamp.Count == 0) _hitCountByTimestamp.AddLast((timestamp, 1));
        else
        {
            var recentMostHit = _hitCountByTimestamp.Last;
            if (recentMostHit.Value.Item1 == timestamp)
            {
                _hitCountByTimestamp.RemoveLast();
                _hitCountByTimestamp.AddLast((recentMostHit.Value.Item1, recentMostHit.Value.Item2 + 1));
            }
            else
            {
                _hitCountByTimestamp.AddLast((timestamp, 1));
            }
        }

        _totalHits += 1;
    }
    
    public int GetHits(int timestamp)
    {
        while(_hitCountByTimestamp.Count != 0)
        {
            var currFirst = _hitCountByTimestamp.First;
            var diff = timestamp - currFirst.Value.Item1;
            if (diff >= 300)
            {
                _totalHits -= currFirst.Value.Item2;
                _hitCountByTimestamp.RemoveFirst();
            }
            else break;
        }

        return _totalHits;
    }
}