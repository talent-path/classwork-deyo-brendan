using System;
using System.Collections.Generic;

namespace GenericHeap
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        List<T> _allElements = new List<T>();

        //TODO: finish refactoring for MaxHeap implementation

        public void Swap(T x, T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public void Heapify()
        {
            //loop starting from the bottom, get parent index and compare to other elements in list

            int maxNode = _allElements.Count - 1;

            for (int i = maxNode; i > 0; i--)
            {
                int parentIndex = (i + 1) / 2 - 1;
                parentIndex = parentIndex >= 0 ? parentIndex : 0;

                if (_allElements[parentIndex].CompareTo(_allElements[i]) > 1)
                {
                    Swap(parentIndex, i);
                }
            }
        }

        public void Add(T toAdd)
        {
            _allElements.Add(toAdd);
            int index = _allElements.IndexOf(toAdd);
            SiftUp(index);
        }

        public void Remove(T toRemove)
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
            while (index > 0)
            {
                int parentIndex = index / 2;
                int currIndex = index;

                while (currIndex > 0 && _allElements[parentIndex].CompareTo(_allElements[currIndex]) > 0)
                {
                    Swap(currIndex, parentIndex);
                    currIndex = parentIndex;
                    parentIndex /= 2;
                }
            }
        }
    }
}
