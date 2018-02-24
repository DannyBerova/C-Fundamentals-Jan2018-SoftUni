﻿using System;

public class StartUp2
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book);
            Console.WriteLine();
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}