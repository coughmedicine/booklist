namespace BooklistBackend.Models;

record User
{
    public int UserId { get; init; }
    public required string Username { get; init; }
}