using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventApp.Views;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EventApp.Models;
using EventApp.Helpers;
using EventApp.Services;
using SQLite;
using System.IO;

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
        public static LocalDatabase LocalDB;

        private IFirebaseAuth auth;

        private AppLoader appLoader;

        public static bool IsActive = true;

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);

            EventName = "Event1";
            ProfileUser = new User();

            
            appLoader = new AppLoader();
            /*
            auth = DependencyService.Get<IFirebaseAuth>();
            if (auth.IsSigned())
            {
                
                MainPage = new MyTabbedPage();
            }
            else
            {
                MainPage = new AuthenticationPage();
            }
            */
            MainPage = new MyTabbedPage();
        }


        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
        }

        protected override void OnStart()
        {

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
