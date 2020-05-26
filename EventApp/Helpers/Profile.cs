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
            //CurUser = App.ProfileUser;
            CurUser = new User{
                Name = "Игорь",
                SecondName = "Манн",
                JobPosition = "Самый известный маркетолог России, спикер, автор, издатель",
                imageUrl = "https://firebasestorage.googleapis.com/v0/b/randombass-4a605.appspot.com/o/speakers1%2F02_1%20%D0%98%D0%B3%D0%BE%D1%80%D1%8C%20%D0%9C%D0%B0%D0%BD%D0%BD%2C%20%D1%81%D0%B0%D0%BC%D1%8B%D0%B9%20%D0%B8%D0%B7%D0%B2%D0%B5%D1%81%D1%82%D0%BD%D1%8B%D0%B9%20%D0%BC%D0%B0%D1%80%D0%BA%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3%20%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B8%2C%20%D1%81%D0%BF%D0%B8%D0%BA%D0%B5%D1%80%2C%20%D0%B0%D0%B2%D1%82%D0%BE%D1%80%2C%20%D0%B8%D0%B7%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C.jpg?alt=media&token=2e59e54c-0043-41fe-a879-6600098a9573"
            };
            
        }
    }
}
