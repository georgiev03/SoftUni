using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList(new int[] {5, 7, 12});

            myList.AddFirst(100);

            Console.WriteLine($"Removed: {myList.RemoveLast()}");

            myList.AddLast(22);

            int[] arr = myList.ToArray();
            myList.Foreach(Console.WriteLine);
        }
    }
}
