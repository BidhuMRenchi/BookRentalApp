using System;
using System.Collections.Generic;

namespace BookRentalApp.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }

        public int GenreId { get; set; }
        public string GName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
