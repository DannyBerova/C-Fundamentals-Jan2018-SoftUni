using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.DataStructures
{
    using Contracts;
    using System.Collections;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private int size;
        private readonly IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            this.comparison = comparison;
            this.InitializeInnerCollection(capacity);
        }
        
        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparison)
            : this(comparison, DefaultSize)
        {
        }

        public SimpleSortedList()
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        protected T[] InnerCollection { get; private set; }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.InnerCollection = new T[capacity];
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.InnerCollection[i].Equals(element) && this.Size > 0)
                {
                    indexOfRemovedElement = i;
                    this.InnerCollection[i] = default(T);
                    this.size--;
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.InnerCollection[i] = this.InnerCollection[i + 1];
                }

                if (this.Size > 0)
                {
                    this.InnerCollection[this.size - 1] = default(T);
                }
               
            }

            return hasBeenRemoved;
        }

        public int Capacity => this.InnerCollection.Length;

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.InnerCollection.Length == this.size)
            {
                this.Resize();
            }

            this.InnerCollection[size] = element;
            this.size++;
            Array.Sort(this.InnerCollection, 0, this.size, this.comparison);
        }

        private void Resize()
        {
            T[] newCollection = new T[this.size * 2];
            Array.Copy(this.InnerCollection, newCollection, Size);
            this.InnerCollection = newCollection;
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count >= this.InnerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                this.InnerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.InnerCollection, 0, this.size, this.comparison);
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.InnerCollection.Length * 2;
            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.InnerCollection, newCollection, this.size);
            this.InnerCollection = newCollection;
        }

        public int Size => this.size;

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            builder.Remove(builder.Length - joiner.Length, joiner.Length);
            return builder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.InnerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
