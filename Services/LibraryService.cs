using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManager.Models;
using LibraryManager.Helpers;

namespace LibraryManager.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly List<Book> _books = new();

        public List<Book> GetAll() => _books.ToList();

        public Book? GetById(Guid id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            if (!BookValidator.Validate(book, out var error))
                throw new ArgumentException(error);

            book.Id = Guid.NewGuid();
            _books.Add(book);
        }
    }
}