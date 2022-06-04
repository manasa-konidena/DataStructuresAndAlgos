namespace DataStructuresAndAlgos.StringsAndArrays;

public class FindDuplicateFilePaths
{
    public IList<IList<string>> FindDuplicate(string[] paths) {
        
        Dictionary<string, List<string>> contentToFilePaths = new Dictionary<string, List<string>>();
        foreach(var fileInfo in paths)
        {
            var splits = fileInfo.Split(' ');
            var directory = splits[0];
            for(int i = 1; i < splits.Length; i++)
            {
                var fileAndContent = splits[i];
                var contentStart = fileAndContent.IndexOf('(');
                var content = fileAndContent.Substring(contentStart + 1);
                var extractedContent = content.Substring(0, content.Length - 1);
                if(contentToFilePaths.TryGetValue(extractedContent, out var currentPaths))
                {
                    currentPaths.Add($"{directory}/{fileAndContent.Substring(0, contentStart)}");
                }
                else contentToFilePaths.Add(extractedContent, new List<string>{$"{directory}/{fileAndContent.Substring(0, contentStart)}"});
            }
        }
        
        var result = new List<IList<string>>();
        
        foreach(var val in contentToFilePaths.Values)
        {
            if(val.Count > 1) result.Add(new List<string>(val));
        }
        
        return result;
    }
}