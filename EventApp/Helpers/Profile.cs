using System;
using EventApp.Models;
using EventApp.Web;
using Xamarin.Forms;

namespace EventApp.Helpers
{
    public static class Profile
    {
        public static User CurUser { get; set; }


        static Profile()
        {
            CurUser = App.ProfileUser;
        }
    }
}
