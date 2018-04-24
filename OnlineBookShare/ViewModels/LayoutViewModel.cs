using Microsoft.AspNetCore.Http;
using OnlineBookShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.ViewModels
{
    public class LayoutViewModel
    {
        private readonly User _user;
        public bool IsLoggedIn { get; set; }
        public LayoutViewModel(User user)
        {
            _user = user;
            if(_user != null)
            {
                IsLoggedIn = true;
            }
            else
            {
                IsLoggedIn = false;
            }
        }
        

        //private void IsUserLoggedIn()
        //{
        //    if(_user != null)
        //    {
        //        IsLoggedIn = true;
        //    }
        //    else
        //    {
        //        IsLoggedIn
        //    }
        //}
    }
}
