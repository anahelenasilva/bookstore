using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("books")]
    // ReSharper disable once HollowTypeName
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_service.GetBooks());
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(_service.GetBook(id));
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _service.Add(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }
    }
}