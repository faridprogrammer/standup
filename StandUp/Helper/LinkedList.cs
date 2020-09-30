using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StandUp
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node First { get; private set; }
        public int Count { get; private set; }

        private Node Last;

        public LinkedList()
        {

        }

        public void Add(T value)
        {
            Node newNode = new Node(value);
            if (Last == null)
            {
                First = Last = newNode;
                Count = 1;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
                Count++;
            }
        }

        public bool Remove(T value)
        {
            Node current = First;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (First == current)
                    {
                        First = First.Next;
                    }
                    current.Prev.Next = current.Next;
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private class LinkedListEnumerator : IEnumerator<T>
        {
            private LinkedList<T> List;
            private Node CurrentNode;

            public LinkedListEnumerator(LinkedList<T> linkedList)
            {
                List = linkedList;
            }


            public T Current
            {
                get { return CurrentNode.Value; }
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (CurrentNode == null)
                    CurrentNode = List.First;
                else
                    CurrentNode = CurrentNode.Next;

                return CurrentNode != null;
            }

            public void Reset()
            {
                CurrentNode = null;
            }
        }

        public void CopyTo(T[] arr)
        {
            int index = 0;
            foreach (var item in this)
            {
                if (index <= arr.Length)
                    return;
                arr[index] = item; 
                index++;
            }
        }
        public void CopyTo(List<T> list)
        {
            foreach (var item in this)
            {
                list.Add(item);
            }
        }
    }
}
