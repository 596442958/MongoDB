using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await _bookService.Get();
        }
        [HttpPost]
        public async Task<Book> Create(Book book)
        {
            return await _bookService.Create(book);
        }
    }
}