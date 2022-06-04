namespace DataStructuresAndAlgos.StringsAndArrays;

public class NestedIterator
{
    private IList<NestedInteger> _nestedList;
    private int _outerListSize = 0;
    private int _innerListSIze = 0;
    private int _indexInOuterList;
    private int _indexInInnerList;
    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _nestedList = nestedList;
        _indexInInnerList = 0;
        _indexInOuterList = 0;
        _outerListSize = _nestedList.Count;

    }

    public bool HasNext()
    {
        if (_indexInOuterList >= _outerListSize) return false;
        if (_nestedList[_indexInOuterList].IsInteger()) return true;
        if (_indexInInnerList >= _nestedList[_indexInOuterList].GetList().Count) return false;
        return true;
    }

    public int Next()
    {
        if (_indexInOuterList < _outerListSize)
        {
            if (_nestedList[_indexInOuterList].IsInteger()) return _nestedList[_indexInOuterList].GetInteger();

            if (_indexInInnerList < _nestedList[_indexInOuterList].GetList().Count)
                return _nestedList[_indexInOuterList].GetList()[_indexInInnerList].GetInteger();
        }

        return -1;
    }
}