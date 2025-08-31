using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Heap
    {
        private List<int> _heap;
        public Heap()
        {
            _heap = [];
        }
        public void Add(int x)
        {
            
        }
        public void Swap(int a, int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}