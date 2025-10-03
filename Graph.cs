using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Graph
    {
        private Dictionary<int, List<Tuple<int, int>>> adjacencyList;
        private HashSet<int> visited;
        public Graph()
        {
            adjacencyList = [];
            visited = [];
        }

        public void AddNode(int vertex)
        {
            if (vertex < 0)
            {
                Console.WriteLine("Only positive integers allowed");
            }
            else if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = [];
            }
        }
        public void AddLink(int start, int end, int cost)
        {
            if (!adjacencyList.ContainsKey(start) || !adjacencyList.ContainsKey(end))
            {
                Console.WriteLine("Referenced nodes are not available");
            }
            else
            {
                var value = adjacencyList[start].Find((Tuple<int, int> val) => val.Item1 == end);
                if (value != null)
                {
                    Console.WriteLine("This link already exists");
                    Console.WriteLine("So I'll just update the cost");
                    Tuple<int, int> tuple = new Tuple<int, int>(value.Item1, cost);
                    adjacencyList[start].Remove(value);
                    adjacencyList[start].Add(tuple);
                    return;
                }
                adjacencyList[start].Add(new Tuple<int, int>(end, cost));
            }
        }
        private void DFS(int startNode, int end)
        {
            if (!adjacencyList.ContainsKey(startNode)) return;
            if (visited.Contains(startNode)) return;
            Console.WriteLine(startNode);
            visited.Add(startNode);
            if (startNode == end) return;
            foreach (Tuple<int, int> val in adjacencyList[startNode])
            {
                DFS(val.Item1, end);
            }
        }
        public void DFSHelper(int startNode, int endNode = -1)
        {
            visited.Clear();
            DFS(startNode, endNode);
        }
        public void BFS(int start, int end = -1)
        {
            if (!adjacencyList.ContainsKey(start) || !adjacencyList.ContainsKey(end)) return;

            Queue<int> processQueue = new Queue<int>();

            // Clear visited hash set
            visited.Clear();

            processQueue.Enqueue(start);
            visited.Add(start);

            while (processQueue.Count > 0)
            {
                int current = processQueue.Dequeue();
                Console.WriteLine(current);

                foreach (Tuple<int, int> neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor.Item1))
                    {
                        if (neighbor.Item1 == end)
                        {
                            return;
                        }
                        processQueue.Enqueue(neighbor.Item1);
                        visited.Add(neighbor.Item1);
                    }
                }
            }
        }

        // Single point shortest path algorithm
        public void DijkstraAlgorithm(int start = adjacencyList.Keys[0]) 
        {
            if (!adjacencyList.ContainsKey(start)) {
                Console.WriteLine("This starting point is not a part of this graph")
            }
            // Create a priority queue and a copy of the adjacency list 
            // linking the nodes to their costs and the previous nodes
            // And also clearing the visited List
            Heap priorityQueue = new Heap();
            Dictionary<int, Tuple<int, int>> localAdjacencyList = new Dictionary<int, Tuple<int, int>> ();
            Tuple<int, int> traversing = Tuple.Create(start, adjacencyList[start])
            priorityQueue.Add(traversing)

            while (!priorityQueue.IsEmpty())
            {
                traversing = priorityQueue.Pop();
                
            }
        }
    }
}