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

        public int updateAddressByUserId(int Userid, string Address)
        {
            int returnValue = 0;
            UserDetails user = _appDbContext.UserDeatils.SingleOrDefault(u => u.UserId == Userid);
            if (user != null)
            {
                user.Address = Address;
                returnValue = _appDbContext.SaveChanges();
            }
            return returnValue;
        }

        public int updateContactByUserId(int Userid, string ContactNumber)
        {
            int returnValue = 0;
            UserDetails user = _appDbContext.UserDeatils.SingleOrDefault(u => u.UserId == Userid);
            if (user != null)
            {
                user.ContactNumber = ContactNumber;
                returnValue = _appDbContext.SaveChanges();
            }
            return returnValue;
        }

        public int updateEmailByUserId(int Userid, string Email)
        {
            int returnValue = 0;
            UserDetails user = _appDbContext.UserDeatils.SingleOrDefault(u => u.UserId == Userid);
            if (user != null)
            {
                user.Email = Email;
                returnValue = _appDbContext.SaveChanges();
            }
            return returnValue;
        }
    }
}
