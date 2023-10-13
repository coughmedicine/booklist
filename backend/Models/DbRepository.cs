using Npgsql;
using Dapper;

namespace BooklistBackend.Models;

class DbRepository : IRepository, IDisposable
{
    NpgsqlDataSource _dataSource;
    NpgsqlConnection _connection;

    DbRepository()
    {
        _dataSource = NpgsqlDataSource.Create("TODO");
        _connection = _dataSource.CreateConnection();
    }

    public Book AddBook(string title, string[] authors, int pageCount)
    {
        var sql = @"
            INSERT INTO books (title, authors, pageCount) VALUES (@Title, @Authors, @PageCount)
            RETURNING book_id
        ";
        // Dapper methods:
        //  Query - executes an SQL string and returns the queried data for *every* row, meaning it returns a list
        //  QuerySingle - same as the last one except it only returns the first row, convenient here
        //  Execute - just does the command without caring about the return value
        var id = _connection.QuerySingle<int>(
            sql,
            new
            {
                Title = title,
                Authors = authors,
                PageCount = pageCount
            }
        );
        return new Book
        {
            BookId = id,
            Title = title,
            Authors = authors,
            PageCount = pageCount,
        };
    }

    public User AddUser(string username)
    {
        var sql = @"
            INSERT INTO users (username) VALUES (@Username)
            RETURNING user_id
        ";
        var id = _connection.QuerySingle<int>(sql, new { Username = username });
        return new User
        {
            UserId = id,
            Username = username,
        };
    }

    public UserBookData GetUserBook(User user, Book book)
    {
        throw new NotImplementedException();
    }

    public Book[] GetUserBooks(User user)
    {
        throw new NotImplementedException();
    }

    void IDisposable.Dispose()
    {
        _dataSource.Dispose();
        _connection.Dispose();
    }
}