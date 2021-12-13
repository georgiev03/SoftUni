using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Box<T> : IComparable<T> where T : IComparable
    {
        public List<T> Elements { get; }

        public T Element { get; }

        public Box(T element)
        {
            Element = element;
        }
        public Box(List<T> elements)
        {
            Elements = elements;
        }

        public void Swap(List<T> elements, int firstIdx, int secondIdx)
        {
            T temp = elements[firstIdx];
            elements[firstIdx] = elements[secondIdx];
            elements[secondIdx] = temp;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString();
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int GreaterElements<T>(List<T> list, T readLine) where T : IComparable
        {
            return list.Count(w => w.CompareTo(readLine) > 0);
        }
    }
}
