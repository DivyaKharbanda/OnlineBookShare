using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(100,ErrorMessage = "Title too big")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
