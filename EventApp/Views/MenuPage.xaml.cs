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

        /*
        protected override async void OnAppearing()
        {
            var auth = DependencyService.Get<IFirebaseAuth>();
            App.ProfileUser = await auth.GetUser(App.EventName);
        }
        */
        public void OnProfileCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }


        public void OnAgendaCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendaPage(true));
        }


        public void OnAttendeesCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UsersPage("speaker"));
        }

        public void OnSpeakersQuestionsCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SpeakersQuestionsPage());
        }

        public void OnPhotoGalleryCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PhotoGalleryPage(true));
        }

        public void OnChatCellTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChatMessagePage(true)); 
        }

        public void OnInfoCellTapped(object sender, System.EventArgs e)
        {
        }

    }
}

