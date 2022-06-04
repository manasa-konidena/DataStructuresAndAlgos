namespace DataStructuresAndAlgos.StringsAndArrays;

public interface NestedInteger
{
 // This is the interface that allows for creating nested lists.
  // You should not implement it, or speculate about its implementation

  // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<NestedInteger> GetList();
}