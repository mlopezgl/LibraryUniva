using System;
using System.Collections.Generic;
using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface ILibraryService
    {
        List<Book> GetAll();
        Book? GetById(Guid id);
        void Add(Book book);
    }
}