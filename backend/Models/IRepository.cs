namespace BooklistBackend.Models;

interface IRepository
{
    User AddUser(string username);
    Book AddBook(string title, string[] authors, int pageCount);
    Book[] GetUserBooks(User user);
    UserBookData GetUserBook(User user, Book book);
}