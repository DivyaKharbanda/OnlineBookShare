using OnlineBookShare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetUserId(string Username)
        {
            return _appDbContext.User.FirstOrDefault(u => u.UserName == Username).UserId;
        }

        public bool IsValidUser(LoginViewModel user)
        {
            if (ValidateUserName(user.UserName))
            {
                if(ValidatePassword(user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidatePassword(string Password)
        {
            return _appDbContext.User.Any(u => u.Password == Password);
        }

        public bool ValidateUserName(string Username)
        {
            return _appDbContext.User.Any(u => u.UserName == Username);
        }

        public int AddUser(User user)
        {
            _appDbContext.User.Add(user);
            return _appDbContext.SaveChanges();
        }
        public User GetUser(int UserId)
        {
            return _appDbContext.User.FirstOrDefault(u => u.UserId == UserId);
            
        }

        public int updateUserNameByUserId(int Userid,string Username)
        {
            int returnValue = 0;
            User user = _appDbContext.User.SingleOrDefault(u => u.UserId == Userid);
            if(user!= null)
            {
                user.UserName = Username;
                returnValue = _appDbContext.SaveChanges();
            }
            return returnValue;
        }


        public int ChangePassword(int userId, string password)
        {
            int returnValue = 0;
            User user = _appDbContext.User.SingleOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.Password = password;
                returnValue = _appDbContext.SaveChanges();
            }
            return returnValue;
        }
    }
}
