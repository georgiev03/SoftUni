using System;
using System.Collections.Generic;
using System.Linq;

namespace DoubleLinkedList
{
    public class CustomLinkedList
    {
        public int Count { get; set; }

        public Node Head { get; set; }

        public Node Tail { get; set; }


        public CustomLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public CustomLinkedList(int value)
        : this()
        {
            Node newNode = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = Tail = newNode;
        }

        public CustomLinkedList(IEnumerable<int> list)
            : this(list.First())
        {
            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Node newNode = new Node()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Tail.Next = newNode;
                    Tail = newNode;
                    Count++;
                }

            }
        }

        public void AddFirst(int element)
        {
            Node newNode = new Node
            {
                Value = element
            };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            Node newNode = new Node { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }

            int result = Head.Value;
            Node second = Head.Next;

            if (second == null)
            {
                Tail = null;
            }
            else
            {
                second.Previous = null;
            }

            Head = second;
            Count--;

            return result;
        }


        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }

            int result = Tail.Value;
            Node previous = Tail.Previous;

            if (previous == null)
            {
                Head = null;
            }
            else
            {
                previous.Next = null;
            }

            Tail = previous;
            Count--;

            return result;
        }

        public void Foreach(Action<int> action)
        {
            Node currNode = Head;

            while (currNode != null)
            {
                action(currNode.Value);

                currNode = currNode.Next;
            }
        }

        public int[] ToArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }

            int[] result = new int[Count];
            int idx = 0;

            Node currNode = Head;

            while (currNode != null)
            {
                result[idx] = currNode.Value;
                idx++;
                currNode = currNode.Next;
            }

            return result;
        }
    }
}
