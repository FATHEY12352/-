using System;
using System.Linq;

public class Solution
{
    public static bool CanLoad(int[] weights, int k, int capacity)
    {
        int trucksUsed = 1;
        int currentCapacity = 0;

        foreach (int weight in weights)
        {
            if (weight > capacity)
            {
                return false; // لا يمكن تحميل هذه الحاوية
            }
            if (currentCapacity + weight <= capacity)
            {
                currentCapacity += weight;
            }
            else
            {
                trucksUsed++;
                currentCapacity = weight;
            }
        }

        return trucksUsed <= k;
    }

    public static int MinCapacity(int[] weights, int k)
    {
        int left = weights.Max(); // الحد الأدنى لقدرة التحميل هو وزن أثقل حاوية
        int right = weights.Sum(); // الحد الأقصى لقدرة التحميل هو مجموع جميع الأوزان
        int result = right; // القيمة الأولية للنتيجة

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (CanLoad(weights, k, mid))
            {
                result = mid; // يمكن تحميل جميع الحاويات بهذه القدرة أو أقل
                right = mid - 1; // نحاول تقليل القدرة
            }
            else
            {
                left = mid + 1; // نحتاج إلى زيادة القدرة
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int k = int.Parse(line1[1]);

        int[] weights = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int minCapacity = MinCapacity(weights, k);
        Console.WriteLine(minCapacity);
    }
}