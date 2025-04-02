using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static List<int> DFS(List<List<int>> adj)
    {
        int n = adj.Count;
        List<int> result = new List<int>();
        bool[] visited = new bool[n];
        Stack<int> stack = new Stack<int>();

        stack.Push(0); // ابدأ من الرأس 1 (الفهرس 0)

        while (stack.Count > 0)
        {
            int u = stack.Pop();

            if (!visited[u])
            {
                visited[u] = true;
                result.Add(u + 1); // نضيف الرأس إلى النتيجة

                // نضيف الجيران بترتيب عكسي حتى تتم معالجتهم بالترتيب الصحيح
                for (int i = adj[u].Count - 1; i >= 0; i--)
                {
                    int v = adj[u][i];
                    if (!visited[v - 1])
                    {
                        stack.Push(v - 1);
                    }
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

        List<int> dfsResult = DFS(adj);
        Console.WriteLine(string.Join(" ", dfsResult));
    }
}