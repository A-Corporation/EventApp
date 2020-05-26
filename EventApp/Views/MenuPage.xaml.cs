using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using EventApp.Views;
using EventApp.Models;
using EventApp.Helpers;
using EventApp.Views.Chat;

namespace EventApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Parallax.ParallaxView = HeaderView;
        }

         

        void OnProfileCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }


        void OnAgendaCellTapped(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Agenda");
            Navigation.PushAsync(new AgendaPage(true));
        }


        void OnAttendeesCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("speaker"));
        }

        void OnSpeakersQuestionsCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SpeakersQuestionsPage());
        }

        void OnPhotoGalleryCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PhotoGalleryPage(true));
        }

        void OnChatCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChatMessagePage(true)); // кнопка назад в меню видна
        }

        void OnInfoCellTapped(object sender, System.EventArgs e)
        {
        }

    }
}

