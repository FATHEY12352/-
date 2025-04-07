using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static Tuple<int, List<int>> Dijkstra(List<List<Tuple<int, int>>> adj, int start, int end)
    {
        int n = adj.Count;
        int[] distance = new int[n]; // لتخزين المسافة من الرأس البداية
        int[] parent = new int[n]; // لتخزين الرأس الأب في أقصر مسار
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue; // قيمة أولية للمسافة لا نهائية
            parent[i] = -1; // قيمة أولية للرأس الأب غير موجود
        }

        distance[start - 1] = 0; // المسافة إلى الرأس البداية هي 0

        for (int count = 0; count < n - 1; count++)
        {
            // اختيار الرأس الذي لديه أقصر مسافة ولم تتم زيارته بعد
            int u = MinDistance(distance, visited);

            // وضع علامة على الرأس الذي تم اختياره كـ "تمت زيارته"
            visited[u] = true;

            // تحديث المسافة إلى الرؤوس المجاورة
            for (int v = 0; v < adj[u].Count; v++)
            {
                int neighbor = adj[u][v].Item1; // الرأس المجاور
                int weight = adj[u][v].Item2; // وزن الحافة

                if (!visited[neighbor - 1] && distance[u] != int.MaxValue && distance[u] + weight <= distance[neighbor - 1])
                {
                    if (distance[u] + weight < distance[neighbor - 1] || (distance[u] + weight == distance[neighbor - 1] && u < parent[neighbor - 1]))
                    {
                        distance[neighbor - 1] = distance[u] + weight; // تحديث المسافة
                        parent[neighbor - 1] = u; // تعيين الرأس الأب
                    }
                }
            }
        }

        // إذا لم يتم العثور على مسار
        if (distance[end - 1] == int.MaxValue)
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

    // دالة مساعدة للعثور على الرأس الذي لديه أقصر مسافة
    private static int MinDistance(int[] dist, bool[] visited)
    {
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < dist.Length; v++)
        {
            if (visited[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }
        }

        return min_index;
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int start = int.Parse(line1[1]);
        int end = int.Parse(line1[2]);

        List<List<Tuple<int, int>>> adj = new List<List<Tuple<int, int>>>();
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int k = int.Parse(line[0]);
            List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();
            for (int j = 1; j <= k * 2; j += 2)
            {
                int v = int.Parse(line[j]);
                int w = int.Parse(line[j + 1]);
                neighbors.Add(new Tuple<int, int>(v, w));
            }
            adj.Add(neighbors);
        }

        Tuple<int, List<int>> shortestPath = Dijkstra(adj, start, end);

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