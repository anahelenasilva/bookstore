using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IOptions<BookstoreDbConfig> _options;
        private readonly IMongoCollection<Book> books;

        public DbClient(IOptions<BookstoreDbConfig> options)
        {
            _options = options;

            var client = new MongoClient(options.Value.ConnectionString);
            var databse = client.GetDatabase(options.Value.DatabaseName);
            books = databse.GetCollection<Book>(options.Value.BooksCollectionName);
        }

        public IMongoCollection<Book> GetBooksCollection() => books;
    }
}