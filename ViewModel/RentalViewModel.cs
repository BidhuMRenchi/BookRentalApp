using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.ViewModel
{
    public class RentalViewModel
    {
        public int RentId { get; set; }
        public string CustomerName { get; set; }
        public List<string> BookName { get; set; }
        public int DaysKept { get; set; }
        public int? Fine { get; set; }
              
    }
}
