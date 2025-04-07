using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void DFS(List<List<int>> adj, int u, bool[] visited)
    {
        visited[u] = true;
        foreach (int v in adj[u])
        {
            if (!visited[v - 1])
            {
                DFS(adj, v - 1, visited);
            }
        }
    }

    public static int CountConnectedComponents(List<List<int>> adj)
    {
        int n = adj.Count;
        bool[] visited = new bool[n];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(adj, i, visited);
                count++;
            }
        }

        return count;
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

        int components = CountConnectedComponents(adj);
        Console.WriteLine(components);
    }
}