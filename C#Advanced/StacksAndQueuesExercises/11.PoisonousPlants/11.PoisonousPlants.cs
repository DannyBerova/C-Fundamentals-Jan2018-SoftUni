using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    public class Program
    {
        public static void Main()
        {
            int plantsCount = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var daysToDie = new int[plantsCount];
            var plantsLeftSeq = new Stack<int>();

            plantsLeftSeq.Push(0);

            for (int i = 1; i < plantsCount; i++)
            {
                int maxDaysToDie = 0;

                while (plantsLeftSeq.Count != 0 && plants[plantsLeftSeq.Peek()] >= plants[i])
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, daysToDie[plantsLeftSeq.Pop()]);
                }

                if (plantsLeftSeq.Count != 0)
                {
                    daysToDie[i] = maxDaysToDie + 1;
                }
                plantsLeftSeq.Push(i);
            }

            Console.WriteLine(daysToDie.Max());
        }
    }
}