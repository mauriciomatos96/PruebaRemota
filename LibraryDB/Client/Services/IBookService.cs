using LibraryDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDB.Client.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<List<Book>> CreateBook(Book book);
    }
}
