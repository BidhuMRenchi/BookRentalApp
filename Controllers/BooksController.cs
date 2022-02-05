using BookRentalApp.Models;
using BookRentalApp.Repository;
using BookRentalApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //Data fields
        private readonly IBook _book;

        //Constructor injection
        public BooksController(IBook book)
        {
            _book = book;
        }

        //GET ALL BOOKS,GENRES and RENTALS -- ViewModel
        #region GET ALL BOOKS,GENRES and RENTALS
        [HttpGet] // /api/books
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAllBooks()
        {
            return await _book.GetAllBooks();
        }

        [HttpGet] // /api/books/genres
        [Route("Genres")]
        public async Task<ActionResult<IEnumerable<Genres>>> GetAllGenres()
        {
            return await _book.GetAllGenres();
        }

        [HttpGet] // /api/books/rentals
        [Route("Rentals")]
        public async Task<ActionResult<IEnumerable<RentalViewModel>>> GetAllRentals()
        {
            return await _book.GetAllRentals();
        }
        #endregion

        //ADD BOOKS,GENRES and RENTALS
        #region ADD BOOKS,GENRES and RENTALS
        [HttpPost] // /api/books
        public async Task<IActionResult> AddBook([FromBody] Books book)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var bookId = await _book.AddBook(book);
                    if (bookId > 0)
                    {
                        return Ok(bookId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost] // /api/books/genre
        [Route("Genre")]
        public async Task<IActionResult> AddGenre([FromBody] Genres genre)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var genreId = await _book.AddGenre(genre);
                    if (genreId > 0)
                    {
                        return Ok(genreId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpGet] // /api/books/rental
        [Route("Rental")]
        public async Task<IActionResult> AddRental([FromBody] Rentals rent)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var rentId = await _book.AddRental(rent);
                    if (rentId > 0)
                    {
                        return Ok(rentId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //DELETE BOOKS and GENRES
        #region DELETE BOOKS and GENRES
        [HttpDelete("{id}")] // /api/books/{id}
        public async Task<IActionResult> DeleteBook(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _book.DeleteBook(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Genre/{id}")] // /api/books/genre/{id}
        public async Task<IActionResult> DeleteGenre(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _book.DeleteGenre(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //UPDATE BOOKS,GENRES and RENTALS
        #region UPDATE BOOKS,GENRES and RENTALS
        [HttpPut]  // /api/books
        public async Task<IActionResult> UpdateBook([FromBody] Books book)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _book.UpdateBook(book);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Genre")]// /api/books/genre
        public async Task<IActionResult> UpdateGenre([FromBody] Genres genre)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _book.UpdateGenre(genre);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Rental")]// /api/books/rental
        public async Task<IActionResult> UpdateRental([FromBody] Rentals rent)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _book.UpdateRental(rent);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //GET BOOKS by ID
        #region GET BOOKS by ID
        [HttpGet("book/{id}")] // /api/books/book/{id}
        public async Task<ActionResult<Books>> GetBookId(int id)
        {
            try
            {
                var book = await _book.GetBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                return book;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
