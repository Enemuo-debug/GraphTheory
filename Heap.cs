using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Heap
    {
        private List<Tuple<int, int>> priorityQueue;
        public Heap()
        {
            priorityQueue = [];
        }
        public void Add(Tuple<int, int> x)
        {
            priorityQueue.Add(x);
            FixHeapFromBottom(priorityQueue.Count - 1);
        }
        public Tuple<int, int>? Peek()
        {
            // Get the minimum element without removing it
            if (priorityQueue.Count == 0) return null;
            return priorityQueue[0];
        }
        public Tuple<int, int>? Pop()
        {
            if (priorityQueue.Count == 0) return null;
            Tuple<int, int> output = priorityQueue[0];
            priorityQueue[0] = priorityQueue[priorityQueue.Count - 1];
            priorityQueue.RemoveAt(priorityQueue.Count - 1);
            FixHeapFromTop();
            return output;
        }
        public void FixHeapFromTop(int index = 0)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallest = index;
            if (leftChildIndex < priorityQueue.Count && priorityQueue[leftChildIndex].Item2 < priorityQueue[smallest].Item2) smallest = leftChildIndex;
            if (rightChildIndex < priorityQueue.Count && priorityQueue[rightChildIndex].Item2 < priorityQueue[smallest].Item2) smallest = rightChildIndex;
            if (smallest != index)
            {
                Swap(index, smallest);
                FixHeapFromTop(smallest);
            }
        }
        public void Swap(int a, int b)
        {
            Tuple<int, int> temp = priorityQueue[a];
            priorityQueue[a] = priorityQueue[b];
            priorityQueue[b] = temp;
        }
        public void FixHeapFromBottom(int index)
        {
            if (index <= 0 || index >= priorityQueue.Count) return;
            int parentIndex = (index - 1) / 2;
            if (priorityQueue[index].Item2 < priorityQueue[parentIndex].Item2)
            {
                Swap(index, parentIndex);
                FixHeapFromBottom(parentIndex);
            }
        }
        public bool IsEmpty()
        {
            return priorityQueue.Count <= 0;
        }
    }
}