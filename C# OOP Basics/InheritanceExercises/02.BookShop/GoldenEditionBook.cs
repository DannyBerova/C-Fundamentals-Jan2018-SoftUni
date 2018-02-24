using System;

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price)
    : base(author, title, price)
    {
        //this.Price *= 1.3m;
    }

    public override decimal Price { get => base.Price * 1.3m; }

}