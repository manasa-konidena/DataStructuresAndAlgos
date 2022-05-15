using System.Text;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class GroupAnagrams
{
    public IList<IList<string>> GetGroupAnagrams(string[] strs) {
        
        if(strs.Length == 0) return new List<IList<string>>();
        var stringRepToList = new Dictionary<string, List<string>>();
        
        foreach(string s in strs)
        {
            var counts = new int[26];
            foreach(char c in s)
            {
                counts[c - 'a']++;
            }
            
            var sb = new StringBuilder();
            for(int i = 0;i < counts.Length; i++)
            {
                sb.Append(i);
                sb.Append(counts[i]);
                sb.Append('#');
            }
            
            var currkey = sb.ToString();
            
            if(stringRepToList.TryGetValue(currkey, out var existingList))
            {
                existingList.Add(s);
            }
            else
            {
                stringRepToList.Add(currkey, new List<string>{ s });
            }
        }
        
        var allSets = stringRepToList.Values;

        return new List<IList<string>>(allSets);

    }
}