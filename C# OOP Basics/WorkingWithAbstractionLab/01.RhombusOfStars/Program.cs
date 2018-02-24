using System;

public class Program
{
    public static void Main()
    {
        var rhombusSize = int.Parse(Console.ReadLine());
        for (int rowSize = 1; rowSize <= rhombusSize; rowSize++)
        {
            PrintRow(rhombusSize, rowSize);
        }
        for (int rowSize = rhombusSize - 1; rowSize > 0; rowSize--)
        {
            PrintRow(rhombusSize, rowSize);
        }

    }

    static void PrintRow(int rhombusSize, int rowSize)
    {
        for (int cnt = 0; cnt < rhombusSize - rowSize; cnt++)
        {
            Console.Write(" ");
        }
        for (int cnt = 0; cnt < rowSize; cnt++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}
