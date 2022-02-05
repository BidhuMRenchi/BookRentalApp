using System;
using System.Collections.Generic;

namespace BookRentalApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Rentals = new HashSet<Rentals>();
        }

        public int CId { get; set; }
        public string CName { get; set; }

        public virtual ICollection<Rentals> Rentals { get; set; }
    }
}
