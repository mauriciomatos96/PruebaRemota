using LibraryDB.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        static List<Book> books = new List<Book>
        {
            new Book {Id = 1, Title = "Jujutsu", Author = "Gege", Description = "Traumas por doquier", Year = "2016"},
            new Book {Id = 2, Title = "Hunter", Author = "Togashi", Description = "Hiatus eterno", Year = "1996"}
        };

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Book was not found");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            book.Id = books.Max(b => b.Id + 1);
            books.Add(book);

            return Ok(books);
        }
    }
}
