using OnlineBookShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.ViewModels
{
    public class BooksViewModel
    {
        public string Title { get; set; }
        public List<BookMaster> books { get; set; }
    }
}
