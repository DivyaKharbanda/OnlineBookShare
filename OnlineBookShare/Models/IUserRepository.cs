using OnlineBookShare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public interface IUserRepository
    {
        bool IsValidUser(LoginViewModel user);
        int GetUserId(string Username);
        int AddUser(User user);
        int updateUserNameByUserId(int Userid, string Username);
        int ChangePassword(int userId, string password);
        User GetUser(int UserId);
    }
}
