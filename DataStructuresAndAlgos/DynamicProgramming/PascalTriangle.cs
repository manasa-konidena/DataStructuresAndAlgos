using System.Xml.Schema;
using NUnit.Framework;

namespace DataStructuresAndAlgos.DynamicProgramming;

public class PascalTriangle
{
    [Test]
    public void Test_GeneratePascal()
    {
        var inputRows = 5;
        var result = new List<List<int>> {new List<int>{1}, new List<int>{1,1}, new List<int>{1,2,1}, new List<int>(){1,3,3,1},new List<int>{1,4,6,4,1} };
        
        CollectionAssert.AreEquivalent(result, Generate(numRows: 5));
    }


    public IList<IList<int>> Generate(int numRows)
    {
        int elementsInRow = 1;
        IList<IList<int>> result = new List<IList<int>>();
        while (elementsInRow <= numRows)
        {
            if (elementsInRow == 1)
            {
                result.Add(new List<int>() {1});
                elementsInRow++;
                continue;;
            }

            if (elementsInRow == 2)
            {
                result.Add(new List<int>() {1, 1});
                elementsInRow++;
                continue;;
            }

            var addList = new List<int>();
            var prevList = result[elementsInRow - 2];
            addList.Add(1);
            
            for (int i = 1; i < elementsInRow - 1; i++)
            {
                addList.Add(prevList[i - 1] + prevList[i]);
            }
            addList.Add(1);
            
            result.Add(addList);
            elementsInRow++;
        }

        return result;

    }
}