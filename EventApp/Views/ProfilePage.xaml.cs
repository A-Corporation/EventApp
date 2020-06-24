using System;
using System.Collections.Generic;
using Plugin.Media;
using EventApp.Models;
using EventApp.ViewModels;

using Xamarin.Forms;
using EventApp.Helpers;
using System.Diagnostics;
using EventApp.Web;
using EventApp.Services;

namespace EventApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        private IFirebaseAuth auth;
        private UsersDetaillsViewModel Udvm;
        public ProfilePage()
        {
            InitializeComponent();
            Parallax.ParallaxView = HeaderView;
            auth = DependencyService.Get<IFirebaseAuth>();
        }

        protected override void OnAppearing()
        {
            Udvm = new UsersDetaillsViewModel(App.ProfileUser);
            BindingContext = Udvm;
        }

        private void SignOutButton_Clicked(object sender, EventArgs e)
        {
            auth.SignOut();
            App.Current.MainPage = new AuthenticationPage();
        }

        private async void UploadPictureButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No upload", "Picking photo is not supported", "Ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            
            if (file == null)
                return;
            
            /*
            ProfilePhotoButton.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            */
        }


    }
}
