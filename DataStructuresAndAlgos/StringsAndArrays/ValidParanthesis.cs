

using System.Collections.Generic;

namespace DataStructuresAndAlgos.StringsAndArrays;


public class ValidParanthesis
{
    public bool IsValid(string s) {
        
    var stackForlefts = new Stack<char>();
    HashSet<char> lefts = new HashSet<char>{'{', '(', '['};
    HashSet<char> rights = new HashSet<char>{'}', ')', ']'};
    Dictionary<char, char> mapParanthesis = new Dictionary<char, char>
    {
        {')', '('},
        {'}', '{'},
        {']', '['},
    };
    
    
    foreach(var c in s)
    {
        if(lefts.Contains(c)) stackForlefts.Push(c);
        else
        {
            if(stackForlefts.Count == 0) return false;
            var fromStack = (char)stackForlefts.Pop();
            if(fromStack != mapParanthesis[c]) return false;
        }
    }
    
    return stackForlefts.Count == 0;
        
    }
}
