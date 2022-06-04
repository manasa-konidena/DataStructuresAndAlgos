namespace DataStructuresAndAlgos.StringsAndArrays;

public class UserPatterns
{
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {

        List<(string, int, string)> groupedInput = new List<(string, int, string)>();

        for (int i = 0; i < username.Length; i++)
        {
            groupedInput.Add((username[i], timestamp[i], website[i]));   
        }
        
        var sortedGroupedInput = groupedInput.OrderBy(gr => gr.Item2);
        Dictionary<string, List<string>> userToWebsiteVisits = new Dictionary<string, List<string>>();

        foreach (var visit in sortedGroupedInput)
        {
            if (userToWebsiteVisits.TryGetValue(visit.Item1, out var websites))
            {
                websites.Add(visit.Item3);
            }
            else userToWebsiteVisits.Add(visit.Item1, new List<string>{ visit.Item3 });
        }

        Dictionary<string, int> webSeqVisitCount = new Dictionary<string, int>();

        foreach (var entry in userToWebsiteVisits)
        {
            if(entry.Value.Count < 3) continue;
            // Get all possible website sequences for this user
            var sequences = GetAllSequencesForUser(entry.Value);
            
        }
        
        // Once dictionary is filled, get the max count website sequence to return, if two are there return the smaller one lexicographically

        return new List<string>();
    }

    HashSet<string> GetAllSequencesForUser(List<string> websiteVisits)
    {
        var result = new HashSet<string>();
        
        for (int i = 0; i < websiteVisits.Count; i++)
        {
            for (int j = i+1; j < websiteVisits.Count; j++)
            {
                for (int k = j + 1; k < websiteVisits.Count; k++)
                {
                    result.Add($"{websiteVisits[i]} {websiteVisits[j]} {websiteVisits[k]}");
                }
            }
        }

        return result;
    }
}