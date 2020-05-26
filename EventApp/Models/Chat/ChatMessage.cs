using System;
using System.Windows.Input;
using EventApp.Views;
using Xamarin.Forms;

namespace EventApp.Models.Chat
{
    public class ChatMessage
    {

        public string Message { get; set; }
        public DateTime Time { get; set; }
        public User User { get; set; }

        public bool IsReceived { get; set; }

        public ICommand UserDetailsPageTransitCommand { set; get; }

        public ChatMessage()
        {
            UserDetailsPageTransitCommand = new Command(
                execute: () =>
                {
                    App.CurPage.Navigation.PushAsync(new UsersDetailsPage(User));
                }
            );
        }
    }
}

