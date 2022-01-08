using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repository;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Infra.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository BookRepository;
        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }
        public Book Create(Book Book)
        {
            BookRepository.Create(Book);
            return new Book();
        }

        public Book Update(Book Book)
        {
            BookRepository.Update(Book);
            return Book;
        }
        public Book GetAll()
        {
            BookRepository.GetAll();
            return new Book();
        }

        public Book Delete(int id)
        {
            BookRepository.Delete(id);
            return new Book();
        }
    }
}
