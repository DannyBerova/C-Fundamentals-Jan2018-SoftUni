using System;
using System.Linq;

namespace _08.CustomListSorter
{
    public class Sorter<T>
        where T : IComparable<T>
    {
        public static CustomList<T> Sort(CustomList<T> list)
        {
            var sortedList = list
                .GetList()
                .OrderBy(x => x)
                .ToList();

            return new CustomList<T>(sortedList);
        }
    }
}
