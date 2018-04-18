using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort
{
    public class Bubble<T>
        where T : IComparable<T>
    {
        private List<T> data;

        private Bubble()
        {
            this.Data = new List<T>();
        }

        public Bubble(params T[] data) : this()
        {
            this.Data = data.ToList();
        }

        public List<T> Data
        {
            get => data;
            private set => this.data = value;
        }

        public List<T> BubbleSort()
        {
            //{
            //    var temp = this.data;
            //    for (int i = 0; i < temp.Count; i++)
            //    {
            //        for (int j = 0; j < temp.Count - i - 1; j++)
            //        {
            //            var first = temp[j];
            //            var second = temp[j + 1];

            //            if (first > second)
            //            {
            //                var tempValue = temp[j];
            //                temp[j] = temp[j + 1];
            //                temp[j + 1] = tempValue;
            //            }
            //        }
            //    }

            //    return temp;
            //}
            bool isSwapped = true;

            while (isSwapped)
            {
                isSwapped = false;

                for (int i = 0; i < this.data.Count - 1; i++)
                {
                    if (this.data[i].CompareTo(this.data[i + 1]) == 1)
                    {
                        T temp = this.data[i];
                        this.data[i] = this.data[i + 1];
                        this.data[i + 1] = temp;
                        isSwapped = true;
                    }
                }
            }

            return this.data;
        }
    }
}
