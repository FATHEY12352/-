using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static List<int> TopologicalSort(List<List<int>> adj)
    {
        int n = adj.Count;
        List<int> result = new List<int>();
        int[] inDegree = new int[n]; // لحساب درجة الدخول لكل رأس

        // حساب درجة الدخول لكل رأس
        for (int u = 0; u < n; u++)
        {
            foreach (int v in adj[u])
            {
                inDegree[v - 1]++;
            }
        }

        Queue<int> queue = new Queue<int>();
        // إضافة جميع الرؤوس التي درجة دخولها 0 إلى قائمة الانتظار
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        int count = 0;
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            result.Add(u + 1); // نضيف الرأس إلى النتيجة
            count++;

            foreach (int v in adj[u])
            {
                // تقليل درجة الدخول للرؤوس المجاورة
                inDegree[v - 1]--;
                // إذا أصبحت درجة الدخول للرأس المجاور 0، نضيفه إلى قائمة الانتظار
                if (inDegree[v - 1] == 0)
                {
                    queue.Enqueue(v - 1);
                }
            }
        }

        // إذا لم تتم زيارة جميع الرؤوس، فهذا يعني أن الرسم البياني يحتوي على دورة
        if (count != n)
        {
            return new List<int> { -1 }; // إرجاع قائمة تحتوي على -1 للإشارة إلى وجود دورة
        }

        return result;
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int k = int.Parse(line[0]);
            List<int> neighbors = new List<int>();
            for (int j = 1; j <= k; j++)
            {
                neighbors.Add(int.Parse(line[j]));
            }
            adj.Add(neighbors);
        }

        List<int> topologicalOrder = TopologicalSort(adj);
        Console.WriteLine(string.Join(" ", topologicalOrder));
    }
}