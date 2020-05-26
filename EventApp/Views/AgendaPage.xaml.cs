using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;
using EventApp.Views.Templates;
using EventApp.Web;

namespace EventApp.Views
{
    public partial class AgendaPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public AgendaPage(bool fromMenu)
        {
            InitializeComponent();
            agendaList.ItemsSource = App.LastAgendaList;

            Device.BeginInvokeOnMainThread(async () =>
            {
                App.LastAgendaList = await firebaseHelper.ParceAgendaItems(App.EventName);
                agendaList.ItemsSource = App.LastAgendaList;
            });
            BackMenuButton.IsVisible = fromMenu;
        }

        public AgendaPage()
        {
            InitializeComponent();
            agendaList.ItemsSource = App.LastAgendaList;

            Device.BeginInvokeOnMainThread(async () =>
            {
                App.LastAgendaList = await firebaseHelper.ParceAgendaItems(App.EventName);
                agendaList.ItemsSource = App.LastAgendaList;
            });
            BackMenuButton.IsVisible = false;
        }


        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;
        

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as AgendaItem;

            if (item == null)
                return;
            await Navigation.PushAsync(new AgendaDetailsPage(item));
        }

        void OnClicked_BackToMenu(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
