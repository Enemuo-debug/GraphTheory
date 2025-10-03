using System;
using GraphTheory;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        // Add nodes
        for (int i = 1; i <= 8; i++)
        {
            graph.AddNode(i);
        }

        // Add links (edges with costs)
        graph.AddLink(1, 2, 2);
        graph.AddLink(1, 3, 5);
        graph.AddLink(2, 3, 1);
        graph.AddLink(2, 4, 2);
        graph.AddLink(3, 5, 3);
        graph.AddLink(4, 5, 2);
        graph.AddLink(4, 6, 4);
        graph.AddLink(5, 6, 1);
        graph.AddLink(5, 7, 7);
        graph.AddLink(6, 8, 2);
        graph.AddLink(7, 8, 3);

        Console.WriteLine("========== Sophisticated Test ==========");

        Console.WriteLine("\nCase 1: Path from 1 to 8");
        graph.DijkstraAlgorithm(1, 8);

        Console.WriteLine("\nCase 2: Path from 2 to 7");
        graph.DijkstraAlgorithm(2, 7);

        Console.WriteLine("\nCase 3: Explore from 1 to all nodes");
        graph.DijkstraAlgorithm(1);
    }
}
