using EventApp.Models.Chat;
using Xamarin.Forms;
using EventApp.ViewModels.Chat;
using EventApp.Controls;
using System;
using System.Linq;
using Plugin.AudioRecorder;
using System.Threading.Tasks;
using Plugin.Media;
using EventApp.Models;
using Plugin.Media.Abstractions;
using EventApp.Web;

namespace EventApp.Views.Chat
{
    public partial class ChatMessagePage: ContentPage
    {
        private ChatMessageViewModel CMvm;
        private FirebaseHelper firebase;

        public ChatMessagePage(bool fromMenu)
        {
            InitializeComponent();
            CMvm = new ChatMessageViewModel();
            BindingContext = CMvm;
            firebase = new FirebaseHelper();
            MessagesList.BindingContext = firebase.GetMessages();
            BackMenuButton.IsVisible = fromMenu;
        }


        public ChatMessagePage()
        {
            InitializeComponent();
            CMvm = new ChatMessageViewModel();
            //BindingContext = CMvm;
            firebase = new FirebaseHelper();
            MessagesList.BindingContext = firebase.GetMessages();

            BackMenuButton.IsVisible = false;
            
        }

        protected override void OnAppearing()
        {
            App.CurPage = this;
            ScrollToLastMessage();
            base.OnAppearing();
        }


        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        public void MessagesList_SizeChanged(object sender, EventArgs e)
        {
            ScrollToLastMessage();
        }

        public void BackToMenuClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void ScrollToLastMessage()
        {
            var v = MessagesList.ItemsSource.Cast<object>().LastOrDefault();
            MessagesList.ScrollTo(v, ScrollToPosition.End, true);
        }

        public async void SendClicked(object sender, EventArgs e)
        {
            var newMessage = new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                UserId = App.ProfileUser.Uid,
                UserName = App.ProfileUser.FullName,
                ImageUrl = App.ProfileUser.ImageUrl,
                Text = notesEntry.Text,
                Time = DateTime.Now
            };

            notesEntry.Text = "";
            await firebase.SaveMessage(newMessage);
        }



    }
}
