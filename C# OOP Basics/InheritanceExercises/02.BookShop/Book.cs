using System;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {

        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            string[] fullName = value.Split();
            if (fullName.Length == 2)
            {
                char firstCh = fullName[1][0];
                if (Char.IsDigit(firstCh))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
        $"Title: {this.Title}" + Environment.NewLine +
        $"Author: {this.Author}" + Environment.NewLine +
        $"Price: {this.Price:F2}";
    }
}