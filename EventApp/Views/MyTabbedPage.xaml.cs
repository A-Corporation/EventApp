using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BottomBar.XamarinForms;
using EventApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : BottomBarPage
    {

        public MyTabbedPage()
        {
            InitializeComponent();
            //MenuNavigationPage.BarBackgroundColor = Color.Red.MultiplyAlpha(0);//Color.FromHex("#D50000");
            //Storage.MenuNavigationPage = MenuNavigationPage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            int height = App.TabHeight;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
