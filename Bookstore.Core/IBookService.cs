using System.Collections.Generic;

namespace Bookstore.Core
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        Book GetBook(string id);

        Book Add(Book book);
    }
}