using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public interface IUserDetailsRepository
    {
        int AddUserDetails(UserDetails User);
        UserDetails GetUserDetails(int UserId);
        int updateAddressByUserId(int Userid, string Address);
        int updateContactByUserId(int Userid, string ContactNumber);
        int updateEmailByUserId(int Userid, string Email);

    }
}
