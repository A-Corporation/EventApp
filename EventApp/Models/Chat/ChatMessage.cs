using System;
using System.Windows.Input;
using EventApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EventApp.Models.Chat
{
    public class ChatMessage
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Time { get; set; }

       
  
        private ICommand userDetailsPageTransitCommand;

        public ChatMessage()
        {
            userDetailsPageTransitCommand = new Command(
                execute: () =>
                {
                    App.CurPage.Navigation.PushAsync(new UsersDetailsPage(App.ProfileUser));
                }
            );
        }
        
        public bool IsMine()
        {
            return UserId == App.ProfileUser.Uid;
        }
            

    }
}

