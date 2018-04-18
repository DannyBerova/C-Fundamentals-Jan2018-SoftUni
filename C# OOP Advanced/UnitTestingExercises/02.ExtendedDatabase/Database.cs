using System;
using System.Linq;

namespace _02.ExtendedDatabase
{
    public class Database : IDatabase<IPerson>
    {
        private const int MaxCapacity = 16;

        private readonly IPerson[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new IPerson[MaxCapacity];
            this.currentIndex = 0;
        }

        public Database(params IPerson[] inputElements) : this()
        {
            this.InitializeElements(inputElements);
        }

        private void InitializeElements(IPerson[] inputElements)
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

        public int CurrentIndex
        {
            get => currentIndex;
            private set
            {
                if (value <= 0 || value >= data.Length)
                    throw new ArgumentOutOfRangeException(nameof(value));
                currentIndex = value;
            }
        }

        public void Add(IPerson element)
        {
            if (currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }

            if (this.data.Take(this.currentIndex).Any(p => p.Equals(element)))
            {
                throw new InvalidOperationException("There is already person with with same Username and Id");
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
            this.data[currentIndex] = default(IPerson);
        }

        public IPerson FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (this.data.Take(this.currentIndex).All(p => p.Username != name))
            {
                throw new InvalidOperationException($"No person with Username{name}.");
            }

            var searchedPerson = this.data.FirstOrDefault(d => d.Username == name);
            if (searchedPerson == null)
            {
                throw new ArgumentNullException($"No person with this Username.");
            }

            

            return searchedPerson;
        }

        public IPerson FindById(long id)
        {
            var searchedPerson = this.data.Take(this.currentIndex).FirstOrDefault(d => d.Id == id);

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (searchedPerson == null)
            {
                throw new InvalidOperationException($"No person with this Id.");
            }

            return searchedPerson;
        }

        public IPerson[] Fetch()
        {
            IPerson[] newArray = new IPerson[currentIndex];
            Array.Copy(this.data, newArray, currentIndex);

            return newArray;
        }
    }
}
