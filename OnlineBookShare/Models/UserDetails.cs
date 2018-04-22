using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class UserDetails
    {
        
        public int Id { get; set; }
        public User LoginDetails { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
