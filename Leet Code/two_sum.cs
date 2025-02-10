using System.Text;

namespace Leet_Code;

public class Solution {
    
    public int MyAtoi(string s) {
        int length = s.Length;
        string res = "";
        bool isNeg = false;
        for(int i = 0; i<length; i++){
            if (!(s[i] <= 57 && s[i] >= 48))
            {
                if(s[i]!=' '){
                    if(s[i]=='-'){
                        isNeg=true;
                    }
                    else{ 
                        res += s[i];
                    }
                }
            }

            
        }
        return isNeg ? Int32.Parse(("-"+res)) : Int32.Parse(res);
    }


    public int MaxArea(int[] height)
    {
        int max = 0;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i; j < height.Length; j++)
            {
                int temp = (height[i] < height[j]) ? height[i] : height[j]; // returns the smaller column heigth
                if (((j - i) * temp)>max){
                    max = temp * (j - i);
                }
            }
        }
        return max;
    }

    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }//((int)(s.Length / (int)(numRows * Math.Sqrt(2)-1)))+10
        char[,] grid = new char[numRows,s.Length];
        int x = 0;
        int y = 0;
        int pos = 0;
        bool diag = false;
        while(pos < s.Length){
            
            if (diag)
            {
                grid[y,x] = s[pos];
                x++;
                y--;
            }
            else
            {
                grid[y,x] = s[pos];
                y++;
            }

            if (y == numRows-1)
            {
                diag = true;
            }

            if (y == 0)
            {
                diag = false;
            }

            pos++;
        }

        StringBuilder sb = new StringBuilder();
        
        for (var index0 = 0; index0 < grid.GetLength(0); index0++)
        for (var index1 = 0; index1 < grid.GetLength(1); index1++)
        {
            var letter = grid[index0, index1];
                if (letter != '\u0000')
                {
                    sb.Append(letter.ToString());
                }
        }

        return sb.ToString();
    } 

    
    public string LongestPalindrome(string s)
    {
        int max = 0;
        string longest = s[0].ToString();
        for (int i = 0; i < s.Length-1; i++)
        {
            int current = 0;
            string currentString = "";
            if (s[i] == s[i+1])
            {
                for (int j = 1; ; j++)
                {
                    if ((i-j < 0 || i+j > s.Length)||s[i - j] != s[j + i +1])//stops beeing palindrom or out of bounds
                    {
                        currentString = s.Substring(i - j+1, (j - 1)* 2 +1 +1);
                        current = (j-1)*2+1+1;
                        break;
                    }
                }
                
            }
            if (current > max)
            {
                longest = currentString;
                max = current;
            }
            if (i != 0)
            {
                for (int j = 1; ; j++)
                {
                    if ((i-j < 0 || i+j > s.Length)||s[i - j] != s[j + i])//stops beeing palindrom or out of bounds
                    {
                        currentString = s.Substring(i - j+1, (j - 1)* 2 +1);
                        current = (j-1)*2+1;
                        break;
                    }
                }
            }

            if (current > max)
            {
                longest = currentString;
                max = current;
            }
        }
        return longest;
    }
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        List<int> numbers1 = nums1.ToList();
        List<int> numbers2 = nums2.ToList();
        List<int> res = new List<int>();
        for (int i = 0; i < m+n; i++)
        {
            if (numbers1.Count > 0 && numbers2.Count > 0)
            {
                if (numbers1[0] < numbers2[0])
                {
                    res.Add(numbers1[0]);
                    numbers1.RemoveAt(0);
                }
                else
                {
                    res.Add(numbers2[0]);
                    numbers2.RemoveAt(0);
                }
            }
            else
            {
                if (numbers1.Count > 0)
                {
                    res.Add(numbers1[0]);
                    numbers1.RemoveAt(0);
                }
                else
                {
                    res.Add(numbers2[0]);
                    numbers2.RemoveAt(0);
                }
            }
        }
        return (m+n)%2==0?
            (res[(m+n)/2-1]+res[(m+n)/2])
            /2.0f:
            res[(m+n)/2];
    }
    public int LengthOfLongestSubstring(string s)
    {
        if (s != "")
        {
            s += s[^1];
        };
        int max = 0;
        for(int i = 0; i<s.Length; i++){
            int currentLen = 0;
            List<char> containedChars = new List<char>();
            for(int j = i; j<s.Length; j++){
                if (containedChars.Contains(s[j]))
                {
                    currentLen = j-i;
                    break;
                }
                containedChars.Add(s[j]);
            }
            if(currentLen>max){
                max = currentLen;
            }
        }
        return max;
    }
    /*public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2, bool carryFlag = false)
    {
        if (l1.next == null && l2.next == null)
        {
            if (l1.val + l2.val + Convert.ToInt32(carryFlag) > 9)
            {
                return new ListNode(l1.val + l2.val + Convert.ToInt32(carryFlag)-10, 
                    new ListNode(1));
            }
            return new ListNode(l1.val + l2.val + Convert.ToInt32(carryFlag));
        }

        l1.next ??= new ListNode(0);
        l2.next ??= new ListNode(0);

        if (l1.val + l2.val + Convert.ToInt32(carryFlag) > 9)
        {
            return new ListNode((l1.val + l2.val)-10 + Convert.ToInt32(carryFlag),
                AddTwoNumbers(l1.next, l2.next, true));
        }
        
        return new ListNode(l1.val + l2.val + Convert.ToInt32(carryFlag),
            AddTwoNumbers(l1.next, l2.next));
    }*/
    public bool IsPalindrome(int x)
    {
        string temp = x.ToString();
        for (var index = 0; index < temp.Length; index++)
        {
            if (temp[index] != temp[temp.Length - index - 1])
            {
                return false;
            }
        }
        return true;
    }
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++){
            try
            {
                dict.Add(nums[i], new List<int>(){i});
            }
            catch (Exception e1)
            {
                dict[nums[i]].Add(i);
            }
        }
        for (int i = 0; i < nums.Length; i++){
            if (dict[target - nums[i]].Count > 1)
            {
                return dict[target - nums[i]].ToArray();
            }
            if(dict[target-nums[i]][0]!=0){
                
                return new int[2]{dict[target-nums[i]][0], i};
            }
        }
        return null;
    }
}

public class ListNode { 
    public int val; 
    public ListNode? next; 
    public ListNode(int val=0, ListNode? next=null) 
    { 
        this.val = val; 
        this.next = next; 
    }
}