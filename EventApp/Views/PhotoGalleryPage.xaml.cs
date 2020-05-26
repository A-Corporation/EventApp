using System;
using System.Collections.Generic;
using Plugin.Media;
using EventApp.Models;
using EventApp.ViewModels;

using Xamarin.Forms;
using System.Collections;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using System.Threading;
using EventApp.Web;

namespace EventApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoGalleryPage : ContentPage
    {
        PhotoGalleryViewModel PGvm;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        
        public PhotoGalleryPage()
        {
            InitializeComponent();
            PGvm = new PhotoGalleryViewModel();
            
            BindingContext = PGvm;
            BackMenuButton.IsVisible = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                //Uvm = new UsersViewModel(attendeesType);
                //BindingContext = await Uvm.GetUsers();
                PhotoCollection.ItemsSource = await firebaseHelper.ParcePhotos(App.EventName);
            });
        }
        
        public PhotoGalleryPage(bool fromMenu = false)
        {
            //PGvm = new PhotoGalleryViewModel();
            InitializeComponent();
            //BindingContext = PGvm;
            BackMenuButton.IsVisible = fromMenu;

            Device.BeginInvokeOnMainThread(async () =>
            {
                //Uvm = new UsersViewModel(attendeesType);
                //BindingContext = await Uvm.GetUsers();
                PhotoCollection.ItemsSource = await firebaseHelper.ParcePhotos(App.EventName);
            });
        }


        


        public void BackToMenuClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


        void OnScrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollX >= App.ScreenWidth / 2)
            {
                PhotoReportButton.BackgroundColor = Color.FromHex("#ffe54c");
                PhotoCollectionButton.BackgroundColor = Color.White;
                FAB.IsVisible = false;
            }
            else if(e.ScrollX <= App.ScreenWidth / 2)
            {
                PhotoCollectionButton.BackgroundColor = Color.FromHex("#ffe54c");
                PhotoReportButton.BackgroundColor = Color.White;
                FAB.IsVisible = true;
            }
            
        }

        

        void OnPhotoReportButton_Clicked(object sender, EventArgs e)
        {
            GoToReportPage();
        }

        void OnPhotoGalleryButton_Clicked(object sender, EventArgs e)
        {
            GoToGalleryPageAsync();
        }


        void ReportPageChanging()
        {
            PhotoReportButton.BorderColor = Color.FromHex("#ffe54c");
            PhotoCollectionButton.BorderColor = Color.White;
            FAB.IsVisible = false;
        }

        void GalleryPageChanging()
        {
            PhotoReportButton.BorderColor = Color.White;
            PhotoCollectionButton.BorderColor = Color.FromHex("#ffe54c");
            FAB.IsVisible = true;
        }

        async void GoToReportPage()
        {
            await PhotoScrollView.ScrollToAsync(PhotoReport, ScrollToPosition.Center, true);
            ReportPageChanging();
        }

        async void GoToGalleryPageAsync()
        {
            await PhotoScrollView.ScrollToAsync(PhotoCollection, ScrollToPosition.Center, true);
            GalleryPageChanging();

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


            PGvm.AddPhoto(new Photo
            {
                PhotoUrl = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                })

            });

        }

    }
}
