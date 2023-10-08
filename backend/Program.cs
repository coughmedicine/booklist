using System.Net.Http.Json;
using Flurl;

using HttpClient client = new();

//var b = new Book("Frankenstein", new[] { "Mary Shelley" }, 352);
Console.WriteLine(await getFromID("zyTCAlFPjgYC"));

async Task<Book> getFromID(string id)
{
    var url = "https://www.googleapis.com/books/v1/volumes".AppendPathSegment(id, true);
    var response = await client.GetFromJsonAsync<VolumeResponse>(url);

    return new Book(response!.volumeInfo.title, response!.volumeInfo.authors, response!.volumeInfo.pageCount);
}

record VolumeInfo
{
    public required string title { get; set; }
    public required string[] authors { get; set; }
    public required int pageCount { get; set; }
}
record VolumeResponse
{
    public required VolumeInfo volumeInfo { get; set; }
}

record Book
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