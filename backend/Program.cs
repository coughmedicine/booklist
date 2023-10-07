using System.Net.Http.Headers;
using Flurl;

using HttpClient client = new();

var b = new Book("Frankenstein", new[] { "Mary Shelley" }, 352);

async Task<Book> getFromID(string id)
{
    var url = "https://www.googleapis.com/books/v1/volumes".AppendPathSegment(id, true);
    var response = await client.GetAsync(url);

    // TODO finish
    return null;
}

class Book
{
    public string Title { get; }
    public string[] Authors { get; }
    public int PageCount { get; set; }
    public int ReadPages { get; set; }

    public Book(string title, string[] authors, int pageCount)
    {
        Title = title;
        Authors = authors;
        PageCount = pageCount;
        ReadPages = 0;
    }
}