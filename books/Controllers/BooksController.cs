using books.Data;
using books.Models;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ApplicationContext.Books);
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public IActionResult GetBookById([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext.Books.Find(x => x.Id == id);

            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateBook([FromBody] BookModel book)
        {
            try
            {
                if (book is null) return BadRequest();
                book.Id = ApplicationContext.Books.Count + 1;
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookModel book)
        {
            var index = ApplicationContext.Books.FindIndex(x => x.Id == id);

            if (index == -1) return NotFound();

            book.Id = id;
            ApplicationContext.Books.RemoveAt(index);
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            var index = ApplicationContext.Books.FindIndex(x => x.Id == id);
            if (index == -1) return NotFound(new
            {
                StatusCode = 404,
                Message = $"Book with id:{id} could not found",
            });

            ApplicationContext.Books.RemoveAt(index);
            return NoContent();
        }
    }
}

