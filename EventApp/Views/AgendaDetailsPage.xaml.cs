using System;
using System.Collections.Generic;
using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;

namespace EventApp.Views
{
    public partial class AgendaDetailsPage : ContentPage
    {
        public AgendaDetailsPage(AgendaItem agendaItem)
        {
            InitializeComponent();
            BindingContext = new AgendaDetailsViewModel(agendaItem);
        }

        protected override void OnAppearing()
        {
            App.CurPage = this;
            base.OnAppearing();
        }


        void BackButton_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
