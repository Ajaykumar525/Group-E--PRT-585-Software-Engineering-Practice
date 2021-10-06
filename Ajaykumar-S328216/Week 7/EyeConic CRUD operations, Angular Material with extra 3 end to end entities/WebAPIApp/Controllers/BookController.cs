using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Book;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook_Service _Book_Service;

        public BookController(IBook_Service Book_Service)
        {
            _Book_Service = Book_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddBook(String name, String category, Int32 code)
        {
            var result = await _Book_Service.AddBook(name, category, code);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _Book_Service.GetAllBooks();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateBook(Book_Pass_Object book)
        {
            var result = await _Book_Service.UpdateBook(book.BookId, book.Name, book.Category, book.Code);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteBook(Book_Pass_Object book)
        {
            var result = await _Book_Service.DeleteBook(book.BookId);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
