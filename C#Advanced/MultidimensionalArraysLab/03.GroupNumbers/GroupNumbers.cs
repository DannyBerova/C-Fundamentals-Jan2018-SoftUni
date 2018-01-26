using System;
using System.Linq;

namespace _03.GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                     .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            var sizes = new int[3];

            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            int[][] jagged = new int[3][];

            for (int cnt = 0; cnt < sizes.Length; cnt++)
            {
                jagged[cnt] = new int[sizes[cnt]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                jagged[remainder][index[remainder]] = number;
                index[remainder]++;
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
    }
}
