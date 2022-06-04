namespace DataStructuresAndAlgos.StringsAndArrays;

public class ComputePlusOne
{
    private int[] PlusOne(int[] digits)
    {
        var result = new LinkedList<int>();

        int i = digits.Length - 1;
        int carryOver = 0;
        int toAdd = 1;
        while(i >= 0)
        {
            if(toAdd == 0 && carryOver == 0)
            {
                return digits;
            }
            var currDigit = digits[i] + toAdd + carryOver;
            toAdd = 0;
            if(currDigit <= 9)
            {
                digits[i] = currDigit;
                result.AddFirst(currDigit);
                carryOver = 0;
            }
            else
            {
                digits[i] = 0;
                carryOver = 1;
                result.AddFirst(0);
            }

            i--;
        }

        int[] resultArray;

        if(carryOver == 1) 
        {
            result.AddFirst(1);
            resultArray = new int[digits.Length + 1];
            result.CopyTo(resultArray, 0);
            return resultArray;
        }


        resultArray = new int[digits.Length];
        result.CopyTo(resultArray, 0);
        return resultArray;

    }
}