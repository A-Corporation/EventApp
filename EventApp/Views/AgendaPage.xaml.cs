using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;
using EventApp.Views.Templates;
using EventApp.Web;
using EventApp.Helpers;
using System;
using System.Collections.ObjectModel;

namespace EventApp.Views
{
    public partial class AgendaPage : ContentPage
    {
        public AgendaViewModel Avm;


        protected override void OnAppearing()
        {
            Avm.AgendaItemsGrouped = App.LocalDB.ParceAgenda();
        }

        public AgendaPage(bool fromMenu)
        {
            InitializeComponent();
            Avm = new AgendaViewModel();
            BindingContext = Avm;

            BackMenuButton.IsVisible = fromMenu;
            
        }

        public AgendaPage()
        {
            InitializeComponent();
            Avm = new AgendaViewModel();
            BindingContext = Avm;

            
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
