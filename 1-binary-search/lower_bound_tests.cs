using System;
using System.Linq;

public class Solution
{
    public static int LowerBound(int[] arr, int x)
    {
        int left = 0;
        int right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // لمنع تجاوز النطاق

            if (arr[mid] >= x)
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int x = int.Parse(line1[1]);

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int index = LowerBound(arr, x);
        Console.WriteLine(index);
    }
}