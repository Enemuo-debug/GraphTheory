using System;
using GraphTheory;
using static GraphTheory.Heap;

class Program
{
    static void Main(string[] args)
    {
        // Create a new MinHeap
        Heap heap = new Heap();

        // Insert some elements (priority, value)
        heap.Add(Tuple.Create(5, 50));
        heap.Add(Tuple.Create(3, 30));
        heap.Add(Tuple.Create(8, 80));
        heap.Add(Tuple.Create(1, 10));
        heap.Add(Tuple.Create(6, 60));


        Console.WriteLine("\nRemoving elements in order:");
        while (!heap.IsEmpty())
        {
            var removed = heap.Pop();
            Console.WriteLine((removed != null) ? $"Removed: Priority={removed.Item1}, Value={removed.Item2}": "This is null");;
        }
    }
}
