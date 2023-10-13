namespace BooklistBackend.Models;

record Book
{
    public int BookId { get; init; }
    public required string Title { get; init; }
    public required string[] Authors { get; init; }
    public int PageCount { get; init; }
}