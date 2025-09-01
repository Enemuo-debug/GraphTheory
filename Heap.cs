using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Heap
    {
        public List<int> _heap;
        public Heap()
        {
            _heap = [];
        }
        public void Add(int x)
        {
            _heap.Add(x);
            FixHeapFromBottom(_heap.Count - 1);
        }
        public int? Peek()
        {
            // Get the minimum element without removing it
            if (_heap.Count == 0) return null;
            return _heap[0];
        }
        public int? Pop()
        {
            if (_heap.Count == 0) return null;
            int output = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            FixHeapFromTop();
            return output;
        }
        public void FixHeapFromTop(int index = 0)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallest = index;
            if (leftChildIndex < _heap.Count && _heap[leftChildIndex] < _heap[smallest]) smallest = leftChildIndex;
            if (rightChildIndex < _heap.Count && _heap[rightChildIndex] < _heap[smallest]) smallest = rightChildIndex;
            if (smallest != index)
            {
                Swap(index, smallest);
                FixHeapFromTop(smallest);
            }
        }
        public void Swap(int a, int b)
        {
            _heap[a] += _heap[b];
            _heap[b] = _heap[a] - _heap[b];
            _heap[a] -= _heap[b];
        }
        public void FixHeapFromBottom(int index)
        {
            if (index <= 0 || index >= _heap.Count) return;
            int parentIndex = (index - 1) / 2;
            if (_heap[index] < _heap[parentIndex])
            {
                Swap(index, parentIndex);
                FixHeapFromBottom(parentIndex);
            }
        }
    }
}