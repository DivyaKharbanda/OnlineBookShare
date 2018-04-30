using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.ViewModels
{
    public class UpdateBookView
    {
        public int BookId { get; set; }
        public bool InfoFetch { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
