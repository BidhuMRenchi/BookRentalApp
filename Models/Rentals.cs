using System;
using System.Collections.Generic;

namespace BookRentalApp.Models
{
    public partial class Rentals
    {
        public int RentId { get; set; }
        public int DaysKept { get; set; }
        public int? Fine { get; set; }
        public int? BId { get; set; }
        public int? CId { get; set; }

        public virtual Books B { get; set; }
        public virtual Customers C { get; set; }
    }
}
