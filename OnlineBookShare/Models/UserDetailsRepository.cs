using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserDetailsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int AddUserDetails(UserDetails User)
        {
            _appDbContext.Add(User);
            return _appDbContext.SaveChanges();
        }

        public UserDetails GetUserDetails(int UserId)
        {
            return _appDbContext.UserDeatils.FirstOrDefault(u => u.UserId == UserId);
        }
    }
}
