using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    
    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }
    public IEnumerator<Book> GetEnumerator()
    {
        for (int i = 0; i < this.books.Count; i++)
        {
            yield return this.books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

