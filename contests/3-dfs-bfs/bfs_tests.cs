using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static List<int> BFS(List<List<int>> adj)
    {
        int n = adj.Count;
        List<int> result = new List<int>();
        bool[] visited = new bool[n]; // لتتبع الرؤوس التي تمت زيارتها

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0); // ابدأ من الرأس 1 (الفهرس 0)
        visited[0] = true;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            result.Add(u + 1); // نضيف الرأس إلى النتيجة (نضيف 1 لأن الرؤوس مرقمة من 1)

            foreach (int v in adj[u])
            {
                if (!visited[v - 1]) // نتحقق مما إذا كان الرأس المجاور قد تمت زيارته
                {
                    visited[v - 1] = true;
                    queue.Enqueue(v - 1);
                }
            }
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

        List<int> bfsResult = BFS(adj);
        Console.WriteLine(string.Join(" ", bfsResult));
    }
}