using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.ViewModel
{
    public class BookViewModel
    {
        public string Genre { get; set; }
        public int BId { get; set; }
        public string BName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publication { get; set; }
    }
}
