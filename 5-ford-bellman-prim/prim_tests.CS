using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Edge
    {
        public int U, V, Weight;
        public Edge(int u, int v, int weight)
        {
            U = u; V = v; Weight = weight;
        }
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]), m = int.Parse(input[1]);

        List<List<Edge>> graph = new List<List<Edge>>();
        for (int i = 0; i <= n; i++) graph.Add(new List<Edge>());

        for (int i = 0; i < m; i++)
        {
            string[] edgeData = Console.ReadLine().Split();
            int u = int.Parse(edgeData[0]), v = int.Parse(edgeData[1]), w = int.Parse(edgeData[2]);
            graph[u].Add(new Edge(u, v, w));
            graph[v].Add(new Edge(v, u, w));
        }

        var result = PrimMST(n, graph);
        if (result.Item1 == -1)
            Console.WriteLine(-1);
        else
        {
            Console.WriteLine(result.Item1);
            Console.WriteLine(string.Join(" ", result.Item2.Select(e => $"{e.U} {e.V}")));
        }
    }

    static (int, List<Edge>) PrimMST(int n, List<List<Edge>> graph)
    {
        bool[] inMST = new bool[n + 1];
        SortedSet<(int Weight, int U, int V)> pq = new SortedSet<(int, int, int)>(Comparer<(int, int, int)>.Create((a, b) => a.Item1 == b.Item1 ? (a.Item2 == b.Item2 ? a.Item3.CompareTo(b.Item3) : a.Item2.CompareTo(b.Item2)) : a.Item1.CompareTo(b.Item1)));
        List<Edge> mstEdges = new List<Edge>();
        int totalWeight = 0, count = 0;

        void AddEdges(int node)
        {
            inMST[node] = true;
            foreach (var edge in graph[node])
                if (!inMST[edge.V])
                    pq.Add((edge.Weight, edge.U, edge.V));
        }

        AddEdges(1);
        while (pq.Count > 0 && count < n - 1)
        {
            var (weight, u, v) = pq.Min;
            pq.Remove(pq.Min);
            if (inMST[v]) continue;

            mstEdges.Add(new Edge(u, v, weight));
            totalWeight += weight;
            count++;
            AddEdges(v);
        }

        if (count != n - 1) return (-1, null);

        mstEdges.Sort((a, b) => a.U == b.U ? a.V.CompareTo(b.V) : a.U.CompareTo(b.U));
        return (totalWeight, mstEdges);
    }
}
