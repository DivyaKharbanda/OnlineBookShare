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
    }
}
