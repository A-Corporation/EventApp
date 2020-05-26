using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventApp.Views
{
    public partial class AttendeesPage : ContentPage
    {
        public AttendeesPage()
        {
            InitializeComponent();
        }


        void OnClicked_BackToMenu(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void OnSpeakersCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("speaker"));
        }

        void OnBuyersCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("buyer"));
        }

        void OnDisignersCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("disigner"));
        }

        void OnSponsorsCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("sponsor"));
        }

        void OnPressCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("press"));
        }

        void OnOrganizersCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("organizer"));
        }
    }
}
