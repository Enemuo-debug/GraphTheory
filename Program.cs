using System;
using GraphTheory;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        // Add nodes
        for (int i = 1; i <= 10; i++)
        {
            graph.AddNode(i);
        }

        // Add links (edges) with weights (costs)
        graph.AddLink(1, 2, 5);
        graph.AddLink(1, 3, 2);
        graph.AddLink(1, 4, 1);

        graph.AddLink(2, 5, 3);
        graph.AddLink(2, 6, 6);

        graph.AddLink(3, 7, 4);
        graph.AddLink(3, 8, 8);

        graph.AddLink(4, 9, 7);
        graph.AddLink(4, 10, 9);

        graph.AddLink(5, 6, 2);
        graph.AddLink(6, 7, 1);
        graph.AddLink(8, 9, 3);
        graph.AddLink(9, 10, 2);

        Console.WriteLine("DFS starting from node 1:");
        graph.BFS(1);
    }
}
