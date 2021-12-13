using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DoubleLinkedList
{
    public class Node
    {
        public int Value { get; set; }

        public Node Previous { get; set; }

        public Node Next { get; set; }
    }
}
