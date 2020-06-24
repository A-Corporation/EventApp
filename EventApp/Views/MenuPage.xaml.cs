using System.Diagnostics;
using Xamarin.Forms;
using EventApp.Views.Chat;
using EventApp.Services;
using EventApp.Models;

namespace EventApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Parallax.ParallaxView = HeaderView;
        }

        protected override async void OnAppearing()
        {
            var auth = DependencyService.Get<IFirebaseAuth>();
            App.ProfileUser = await auth.GetUser("Event 1");
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

