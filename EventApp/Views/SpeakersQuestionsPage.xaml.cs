using System;
using System.Collections.Generic;
using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;

namespace EventApp.Views
{
    public partial class SpeakersQuestionsPage : ContentPage
    {
        AgendaViewModel Avm;

        

        public SpeakersQuestionsPage()
        {

            InitializeComponent();
            Avm = new AgendaViewModel();
            BindingContext = Avm;
        }


        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;


        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as AgendaItem;

            if (item == null)
                return;
            await Navigation.PushAsync(new SpeakersQuestionsDetailsPage(item));
        }

        void OnClicked_BackToMenu(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        
    }
}
