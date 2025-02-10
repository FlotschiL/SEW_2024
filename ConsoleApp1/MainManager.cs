using System.Data;
using System.Runtime.InteropServices;

namespace ConsoleApp1;

public class MainManager
{
    List<int> AllValues = new List<int>();

    List<Pair> OPList = new List<Pair>();
    
    private int length;
    public void Load(string input)
    {
        var split = input.Split(" ");
        length = Convert.ToInt32(split[0]);
        for (var index = 1; index <= length; index++)
        {
            var value = split[index];
            AllValues.Add(Convert.ToInt32(value));
        }

    }

    public void Evaluate()
    {
        List<int> tmp = Sort(AllValues);
        for (int i = 0; i < length; i++)
        {
            if (tmp[i] > 0)
            {
                if (i!=length-1 && tmp[i+1] < 0)
                {
                    OPList.Add(new Pair(tmp[i], tmp[i+1]));
                }

                if (i!=0 && tmp[i-1] < 0)
                {
                    OPList.Add(new Pair(tmp[i], tmp[i-1]));
                }
            }
        }
    }

    public string OutputPairs()
    {
        OPList.Sort();
        string output = OPList.Count.ToString();
        foreach (var item in OPList)
        {
            output += " " + item.ToString();
        }
        return output;
    }

    private List<int> Sort(List<int> values)
    {
        int temp = 0;
        List<int> arr = values;
        for (int write = 0; write < arr.Count; write++) {
            for (int sort = 0; sort < arr.Count - 1 - write; sort++) {
                if (Math.Abs(arr[sort]) > Math.Abs(arr[sort + 1])) {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }
        return arr;
    }
}