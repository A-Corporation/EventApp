using System;
using EventApp.Models;


namespace EventApp.ViewModels
{
    public class UsersDetaillsViewModel
    {
        public User User { get; set; }

        public UsersDetaillsViewModel(User user)
        {
            User = user;
        }

        
    }
}
