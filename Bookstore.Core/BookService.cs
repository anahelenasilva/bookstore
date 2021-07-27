using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class BookService : IBookService
    {
        private readonly IDbClient _dbClient;
        private readonly IMongoCollection<Book> books;

        public BookService(IDbClient dbClient)
        {
            _dbClient = dbClient;
            books = _dbClient.GetBooksCollection();
        }

        public IEnumerable<Book> GetBooks() => books.Find(book => true).ToList();

        public Book GetBook(string id) => books.Find(b => b.Id == id).FirstOrDefault();

        public Book Add(Book book)
        {
            books.InsertOne(book);
            return book;
        }
    }
}