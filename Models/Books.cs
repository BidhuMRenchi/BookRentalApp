using System;
using System.Collections.Generic;

namespace BookRentalApp.Models
{
    public partial class Books
    {
        public Books()
        {
            Rentals = new HashSet<Rentals>();
        }

        public int BId { get; set; }
        public string BName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publication { get; set; }
        public int? GenreId { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
