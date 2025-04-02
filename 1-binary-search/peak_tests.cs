using System;
using System.Linq;

public class Solution
{
    public static int FindPeak(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] < arr[mid + 1])
            {
                // نحن في الجزء المتزايد من المصفوفة، لذا يجب أن تكون القمة على اليمين
                left = mid + 1;
            }
            else
            {
                // نحن في الجزء المتناقص من المصفوفة أو عند القمة، لذا يجب أن تكون القمة على اليسار أو في المنتصف
                right = mid;
            }
        }

        // في النهاية، سيشير left و right إلى نفس الفهرس، وهو فهرس القمة
        return left;
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int index = FindPeak(arr);
        Console.WriteLine(index);
    }
}