using System;
using System.Collections.Generic;
using Plugin.Media;
using EventApp.Models;
using EventApp.ViewModels;

using Xamarin.Forms;
using EventApp.Helpers;
using System.Diagnostics;

namespace EventApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            Parallax.ParallaxView = HeaderView;
            BindingContext = new UsersDetaillsViewModel(Profile.CurUser);
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
