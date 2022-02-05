using BookRentalApp.Models;
using BookRentalApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Repository
{
    public interface IBook
    {

        //GET ALL BOOKS,GENRE and RENTALS -- viewModel
        Task<List<BookViewModel>> GetAllBooks();
        Task<List<RentalViewModel>> GetAllRentals();
        Task<List<Genres>> GetAllGenres();

        //GET BOOK by id  -- viewModel
        Task<Books> GetBook(int? bookId);

        //ADD BOOK,GENRE and RENTAL
        Task<int> AddBook(Books book);
        Task<int> AddRental(Rentals rent);
        Task<int> AddGenre(Genres genre);

        //UPDATE BOOK,GENRE and RENTAL
        Task UpdateBook(Books book);
        Task UpdateRental(Rentals rent);
        Task UpdateGenre(Genres genre);

        //DELETE BOOK and GENRE
        Task<int> DeleteBook(int? bookId);
        Task<int> DeleteGenre(int? genreId);

    }
}
