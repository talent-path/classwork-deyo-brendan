using System;
using System.Collections.Generic;
using LinkedList;

namespace GenericHeap
{


    //what is a heap?
    //heap property - each "node" has 2 children,
    //each child is (less for maxheap/greater for minheap) than the parent
    //  therefore top-most node is largest/smallest, respectively


    //parents & children in an array/list

    //                  0
    //       1                    2
    //    3     4              5    6
    //   7 8   9 X

    // LeftChildIndex( int parentIndex ) => parentIndex * 2 + 1;
    // RightChildIndex( int parentIndex ) => parentIndex * 2 + 2;
    // ParentIndex( int childIndex ) => (childIndex - 1) / 2;

    //https://en.wikipedia.org/wiki/Binary_heap
    public class MinHeap<T> where T : IComparable<T>
    {
        //every incoming object will implement IComparable<T>
        //CompareTo semantics:

        //this.CompareTo( that )
        //  -  this comes "before" that or this < that
        //  0  this == that
        //  +  this comes "after" that or this > that

        List<T> _allElements = new List<T>();

        public void Heapify()
        {
            //loop starting from the bottom, get parent index and compare to other elements in list

            int maxNode = _allElements.Count - 1;

            for(int i = maxNode; i > 0; i--)
            {
                int parentIndex = (i + 1) / 2 - 1;
                parentIndex = parentIndex >= 0 ? parentIndex : 0;

                if (_allElements[parentIndex].CompareTo(_allElements[i]) > 1)
                {
                    Swap(parentIndex, i);
                }
            }
        }

        public void Swap(int x, int y)
        {
            T temp = _allElements[x];
            _allElements[x] = _allElements[y];
            _allElements[y] = temp;
        }

        public void Swap(T x, T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public void Add( T toAdd)
        {
            _allElements.Add(toAdd);

            SiftUp();
        }

        public void Remove( T toRemove)
        {
            //we're looking for a CompareTo() == 0
            int index = _allElements.IndexOf(toRemove);

            int maxNode = _allElements.Count - 1;

            if (_allElements[index].CompareTo(toRemove) == 0)
            {
                _allElements.RemoveAt(maxNode);
            }

            Heapify();
        }

        public T Peek()
        {
            if (_allElements.Count > 0) return _allElements[0];
            return default(T);
        }

        public T Pop()
        {
            T toReturn = default(T);
            if (_allElements.Count > 0) toReturn = _allElements[0];

            //todo: actually remove the top node
            //swap with the last element
            //remove the last element
            //heapify()

            Remove(toReturn);

            Swap(toReturn, _allElements[_allElements.Count - 1]);

            Remove(_allElements[_allElements.Count - 1]);

            return toReturn;
        }

        private void SiftUp(int index)
        { 
            while(index > 0)
            {
                int parentIndex = (index - 1) / 2;
            }
        }
    }
}
