using LibraryDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LibraryDB.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> CreateBook(Book book)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/book", book);
            var books = await result.Content.ReadFromJsonAsync<List<Book>>();
            return books;
        }

        public async Task<Book> GetBook(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/book/{id}");
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _httpClient.GetFromJsonAsync<List<Book>>("api/book");
        }
    }
}
