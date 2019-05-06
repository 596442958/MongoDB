using BooksApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        public BookService(IConfiguration configuration)
        {
            //获取操作实例 进行构造注入
            var client = new MongoClient(configuration.GetConnectionString("MongoDBConnString"));
            var database = client.GetDatabase("DB");
            _books = database.GetCollection<Book>("Books");
        }
        public async Task<Book> Create(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }
        public async Task<List<Book>> Get()
        {
           var result= await _books.FindAsync(book=> true);
           return result.ToList();
        }
        public async Task Update(string id, Book bookIn)
        {
          await  _books.ReplaceOneAsync(book => book.Id == id, bookIn);
        }

        public async Task Remove(Book bookIn)
        {
           await _books.DeleteOneAsync(book => book.Id == bookIn.Id);
        }

        public async Task Remove(string id)
        {
           await _books.DeleteOneAsync(book => book.Id == id);
        }
    }
}
