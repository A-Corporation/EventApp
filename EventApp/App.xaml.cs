using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventApp.Views;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EventApp.Models;
using EventApp.Helpers;
using EventApp.Web;

namespace EventApp
{
    public partial class App : Application
    {

        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static int TabHeight { get; set; }
        public static string EventName { get; set; }

        public static ObservableCollection<Grouping<string, User>> LastSpeakersList { get; set; }
        public static ObservableCollection<Grouping<string, AgendaItem>> LastAgendaList { get; set; }
        public static User ProfileUser { get; set; }
        public static ContentPage CurPage { get; set; }

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public App()
        {
            InitializeComponent();
            EventName = "Event 1";
            XF.Material.Forms.Material.Init(this);
            //MainPage = new AuthenticationPage();
            //MainPage = new VotingPage();
            MainPage = new MyTabbedPage();
            //MainPage = new AgendaPage();
            
        }

        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            /*
            Device.BeginInvokeOnMainThread(async () =>
            {
                LastSpeakersList = await firebaseHelper.GetAllPersons();
            });
            */
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
