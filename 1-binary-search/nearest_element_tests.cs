using System;
using System.Linq;

public class Solution
{
    public static int FindClosest(int[] arr, int x)
    {
        int left = 0;
        int right = arr.Length - 1;

        if (arr.Length == 0)
        {
            return -1; // أو أي قيمة أخرى تشير إلى عدم وجود عناصر
        }

        while (left < right - 1) // البحث الثنائي حتى يتبقى عنصران أو أقل
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == x)
            {
                return mid; // وجدنا العنصر بالضبط
            }
            else if (arr[mid] < x)
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }

        // الآن نقارن العنصرين المتبقيين (أو العنصر الوحيد إذا كان left == right)
        if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x))
        {
            return left;
        }
        else
        {
            return right;
        }
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int x = int.Parse(line1[1]);

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int index = FindClosest(arr, x);
        Console.WriteLine(index);
    }
}