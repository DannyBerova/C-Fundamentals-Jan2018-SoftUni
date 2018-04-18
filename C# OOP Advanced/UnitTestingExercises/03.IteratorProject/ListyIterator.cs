using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.IteratorProject
{
    public class ListyIterator
    {
        private List<string> data;
        private int currentIndex;

        public ListyIterator()
        {
            this.currentIndex = 0;
            this.Data = new List<string>();
        }

        public ListyIterator(params string[] data) : this()
        {
            InitializeElements(data);
        }

        public List<string> Data
        {
            get => this.data;
            private set
            {
                this.data = value ?? throw new ArgumentNullException("Cannot store null in ListyIterator!");
            }
        }

        private void InitializeElements(string[] inputElements)
        {
            if (inputElements.Any(s => s == null))
            {
                throw new ArgumentNullException("Cannot store null in ListyIterator!");
            }

            this.Data = inputElements.ToList();
        }

        public bool HasNext()
        {
            bool result = currentIndex < this.data.Count - 1;
            return result;
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }
            this.currentIndex++;

            return true;
        }

        public void Print()
        {
            if (!this.data.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[currentIndex]);
        }
    }
}
