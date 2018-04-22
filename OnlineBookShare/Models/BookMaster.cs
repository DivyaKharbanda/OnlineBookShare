using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class BookMaster
    {
        public int BookMasterId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int ImageNumber { get; set; }
        public int AvailableCount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
