using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;


namespace EventApp.Views
{
    public partial class UsersDetailsPage : ContentPage
    {
        public UsersDetailsPage(User user)
        {
            InitializeComponent();
            Parallax.ParallaxView = HeaderView;
            BindingContext = new UsersDetaillsViewModel(user);
        }


        void BackButton_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
