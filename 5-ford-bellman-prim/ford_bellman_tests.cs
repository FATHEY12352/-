using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static Tuple<int, List<int>> FordBellman(int n, int m, int start, int end, List<Tuple<int, int, int>> edges)
    {
        int[] distance = new int[n];
        int[] parent = new int[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            parent[i] = -1;
        }

        distance[start - 1] = 0;

        // تخفيف الحواف
        for (int i = 1; i <= n - 1; i++)
        {
            foreach (var edge in edges)
            {
                int u = edge.Item1;
                int v = edge.Item2;
                int w = edge.Item3;

                if (distance[u - 1] != int.MaxValue && distance[u - 1] + w < distance[v - 1])
                {
                    distance[v - 1] = distance[u - 1] + w;
                    parent[v - 1] = u - 1;
                }
            }
        }

        // التحقق من الدورات السلبية
        foreach (var edge in edges)
        {
            int u = edge.Item1;
            int v = edge.Item2;
            int w = edge.Item3;

            if (distance[u - 1] != int.MaxValue && distance[u - 1] + w < distance[v - 1])
            {
                return new Tuple<int, List<int>>(-1, null); // دورة سلبية
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
            path.Insert(0, current + 1);
            current = parent[current];
        }

        return new Tuple<int, List<int>>(distance[end - 1], path);
    }

    public static void Main(string[] args)
    {
        string[] line1 = Console.ReadLine().Split();
        int n = int.Parse(line1[0]);
        int m = int.Parse(line1[1]);
        int start = int.Parse(line1[2]);
        int end = int.Parse(line1[3]);

        List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            int w = int.Parse(line[2]);
            edges.Add(new Tuple<int, int, int>(u, v, w));
        }

        Tuple<int, List<int>> shortestPath = FordBellman(n, m, start, end, edges);

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