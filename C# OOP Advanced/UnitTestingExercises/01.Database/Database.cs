using System;

namespace _01.Database
{
    public class Database : IDatabase
    {
        private const int MaxCapacity = 16;

        private readonly int[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new int[MaxCapacity];
            this.currentIndex = 0;
        }

        public Database(params int[] inputElements) : this()
        {
            this.InitializeElements(inputElements);
        }

        private void InitializeElements(int[] inputElements)
        {
            try
            {
                Array.Copy(inputElements, this.data, inputElements.Length);
                this.currentIndex = inputElements.Length;

            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("Array is full!", e); 
            }
        }

        //public int CurrentIndex
        //{
        //    get => currentIndex;
        //    private set
        //    {
        //        if (value <= 0 || value >= data.Length)
        //            throw new ArgumentOutOfRangeException(nameof(value));
        //        currentIndex = value;
        //    }
        //}

        public void Add(int element)
        {
            if (currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }

            this.data[currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }

            currentIndex--;
            this.data[currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] newArray = new int[currentIndex];
            Array.Copy(this.data, newArray, currentIndex);

            return newArray;
        }
    }
}
