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
        public void BFS(int start)
        {
            if (!adjacencyList.ContainsKey(start)) return;

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
                        processQueue.Enqueue(neighbor.Item1);
                        visited.Add(neighbor.Item1);
                    }
                }
            }
        }
    }
}