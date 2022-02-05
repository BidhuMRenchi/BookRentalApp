using BookRentalApp.Models;
using BookRentalApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Repository
{
    public class BookRepository : IBook
    {
        private readonly BookRentalDBContext _context;

        public BookRepository(BookRentalDBContext context)
        {
            _context = context;
        }

        // ADD BOOK,GENRE and RENTALS
        #region ADD BOOK,GENRE and RENTALS
        public async Task<int> AddBook(Books book)
        {
            if (_context != null)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return book.BId;
            }
            return 0;
        }

        public async Task<int> AddGenre(Genres genre)
        {
            if (_context != null)
            {
                await _context.Genres.AddAsync(genre);
                await _context.SaveChangesAsync();
                return genre.GenreId;
            }
            return 0;
        }

        public async Task<int> AddRental(Rentals rent)
        {
            if (_context != null)
            {
                await _context.Rentals.AddAsync(rent);
                await _context.SaveChangesAsync();
                return rent.RentId;
            }
            return 0;
        }
        #endregion

        // DELETE BOOK and GENRE
        #region DELETE BOOK and GENRE
        public async Task<int> DeleteBook(int? bookId)
        {
            int result = 0;
            if (_context != null)
            {
                var books = await _context.Books.FirstOrDefaultAsync(book => book.BId == bookId);

                //check condition
                if (books != null)
                {
                    _context.Books.Remove(books);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }

        public async Task<int> DeleteGenre(int? genreId)
        {
            int result = 0;
            if (_context != null)
            {
                var genres = await _context.Genres.FirstOrDefaultAsync(genre => genre.GenreId == genreId);

                //check condition
                if (genres != null)
                {
                    _context.Genres.Remove(genres);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }        
        #endregion

        // GET ALL BOOKS,GENRES and RENTALS -- ViewModel
        #region GET ALL BOOKS,GENRES and RENTALS
        public async Task<List<BookViewModel>> GetAllBooks()
        {
            if (_context != null)
            {
                return await (
                    from b in _context.Books
                    from g in _context.Genres
                    where b.GenreId == g.GenreId
                    select new BookViewModel
                    {
                        BId=b.BId,
                        BName=b.Author,
                        Author=b.Author,
                        Genre=g.GName,
                        Publication=b.Publication,
                        Price=b.Price
                    }).ToListAsync();
            }
            return null;
        }

        public async Task<List<Genres>> GetAllGenres()
        {
            if (_context != null)
            {
                return await _context.Genres.ToListAsync();
            }
            return null;
        }

        public async Task<List<RentalViewModel>> GetAllRentals()
        {
            if (_context != null)
            {
                return await (
                    from r in _context.Rentals
                    from c in _context.Customers
                    where r.CId == c.CId
                    select new RentalViewModel
                    {
                        RentId=r.RentId,
                        CustomerName=c.CName,
                        BookName=(from b in _context.Books
                                  where b.BId==r.BId
                                  select b.BName).ToList(),
                        DaysKept=r.DaysKept,
                        Fine=r.Fine
                    }).ToListAsync();
            }
            return null;
        }
        #endregion

        // GET BOOK BY ID
        #region GET BOOK BY ID
        public async Task<Books> GetBook(int? bookId)
        {
            if (_context != null)
            {
                var book = await _context.Books.FindAsync(bookId);// concentrating on primary key
                return book;
            }
            return null;
        }
        #endregion

        // UPDATE BOOK,GENRE and RENTAL
        #region UPDATE BOOK,GENRE and RENTAL
        public async Task UpdateBook(Books book)
        {
            if (_context != null)
            {
                _context.Entry(book).State = EntityState.Modified;
                _context.Books.Update(book);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }

        public async Task UpdateGenre(Genres genre)
        {
            if (_context != null)
            {
                _context.Entry(genre).State = EntityState.Modified;
                _context.Genres.Update(genre);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }

        public async Task UpdateRental(Rentals rent)
        {
            if (_context != null)
            {
                _context.Entry(rent).State = EntityState.Modified;
                _context.Rentals.Update(rent);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }
        #endregion

    }
}
