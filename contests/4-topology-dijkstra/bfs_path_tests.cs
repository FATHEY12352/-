using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static Tuple<int, List<int>> ShortestPathBFS(List<List<int>> adj, int start, int end)
    {
        int n = adj.Count;
        int[] distance = new int[n]; // لتخزين المسافة من الرأس البداية
        int[] parent = new int[n]; // لتخزين الرأس الأب في أقصر مسار
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = -1; // قيمة أولية للمسافة غير معروفة
            parent[i] = -1; // قيمة أولية للرأس الأب غير موجود
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start - 1); // ابدأ من الرأس البداية (الفهرس start - 1)
        visited[start - 1] = true;
        distance[start - 1] = 0; // المسافة إلى الرأس البداية هي 0

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            foreach (int v in adj[u])
            {
                if (!visited[v - 1])
                {
                    visited[v - 1] = true;
                    distance[v - 1] = distance[u] + 1; // تحديث المسافة
                    parent[v - 1] = u; // تعيين الرأس الأب
                    queue.Enqueue(v - 1);

                    // إذا وصلنا إلى الرأس النهائي، يمكننا التوقف
                    if (v == end)
                    {
                        break;
                    }
                }
            }
        }

        // إذا لم يتم العثور على مسار
        if (distance[end - 1] == -1)
        {
            return new Tuple<int, List<int>>(-1, null);
        }

        // استعادة المسار
        List<int> path = new List<int>();
        int current = end - 1;
        while (current != -1)
        {
            path.Insert(0, current + 1); // نضيف الرأس إلى بداية المسار
            current = parent[current];
        }

        return new Tuple<int, List<int>>(distance[end - 1], path);
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int start = int.Parse(line1[1]);
        int end = int.Parse(line1[2]);

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

        Tuple<int, List<int>> shortestPath = ShortestPathBFS(adj, start, end);

        if (shortestPath.Item1 == -1)
        {
            Console.WriteLine("-1");
        }
        else
        {
            Console.WriteLine(shortestPath.Item1);
            Console.WriteLine(string.Join(" ", shortestPath.Item2));
        }
    }
}