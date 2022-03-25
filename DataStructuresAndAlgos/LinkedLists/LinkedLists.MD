| Code                                                   | Notes                                                                                                        |
|:-------------------------------------------------------|:-------------------------------------------------------------------------------------------------------------|
| [ReverseLinkedList](ReverseLinkedList.cs)              | Need 3 pointers to break and make connections                                                                |
| [LinkedListCycle](LinkedListCycle.cs)                  | Need two pointers to check if they ever meet                                                                 |
| [MergeSortedLinkedLists](MergeTwoSortedLinkedLists.cs) | Trick is to let the first node of the result go                                                              |
| [RemoveElements](RemoveElements.cs)                    | Keep track of previous in case you have to delete a node and deal with when the first one matches separately |
| [RemoveNthFromLast](RemoveNthFromLast.cs)              | SLow fast to move as much as n and delete slow                                                               |
| [RemoveDuplicates](RemoveDuplicates.cs)                | Slow fast pointer to remove duplicates from sorted                                                           |
| [ReorderLinkedList](ReorderLinkedList.cs)              | Stack + iterate through the list again to make the result                                                    |