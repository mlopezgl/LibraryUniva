using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models;
using LibraryManager.Services;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _service;

        public BooksController(ILibraryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() => _service.GetAll();

        [HttpGet("{id:guid}")]
        public ActionResult<Book> GetById(Guid id)
        {
            var book = _service.GetById(id);
            return book is not null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _service.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
    }
}