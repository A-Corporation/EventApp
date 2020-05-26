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

namespace EventApp.Views.Chat
{
    public partial class ChatMessagePage: ContentPage
    {
        ChatMessageViewModel CMvm;


        public ChatMessagePage(bool fromMenu)
        {
            InitializeComponent();
            CMvm = new ChatMessageViewModel();
            BindingContext = CMvm;
            BackMenuButton.IsVisible = fromMenu;
        }


        public ChatMessagePage()
        {
            InitializeComponent();
            CMvm = new ChatMessageViewModel();
            BindingContext = CMvm;
            BackMenuButton.IsVisible = false;
            
        }

        protected override void OnAppearing()
        {
            App.CurPage = this;
            base.OnAppearing();
        }


        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        

        public void BackToMenuClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

       

        public void SendClicked(object sender, EventArgs e)
        {

            notesEntry.Text = "";
        }



    }
}
