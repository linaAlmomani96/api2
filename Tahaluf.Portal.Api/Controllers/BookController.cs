using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Services;
using Tahaluf.Portal.Infra.Services;

namespace Tahaluf.Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService BookService;
        public BookController(IBookService bookService)
        {
            BookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public Book GetAll()
        {
            return BookService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), StatusCodes.Status400BadRequest)]
        public Book Create([FromBody] Book book)
        {
            return BookService.Create(book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), StatusCodes.Status400BadRequest)]
        public Book Update([FromBody] Book book)
        {
            return BookService.Update(book);
        }

        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            return BookService.Delete(id);
        }
    }
}
