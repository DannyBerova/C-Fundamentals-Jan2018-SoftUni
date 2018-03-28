﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.CustomListIterator
{ 
    public class CustomList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private IList<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public CustomList(IList<T> collection)
        {
            this.data = new List<T>(collection);
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove(int index)
        {
            T element = this.data[index];

            this.data.RemoveAt(index);
            return element;
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var firstElement = this.data[index1];
            var secondElement = this.data[index2];

            this.data[index1] = secondElement;
            this.data[index2] = firstElement;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            for (int index = 0; index < this.data.Count; index++)
            {
                if (this.data[index].CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public IList<T> GetList()
        {
            return this.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Print()
        {
            var sb = new StringBuilder();

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}