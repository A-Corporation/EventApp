﻿using Xamarin.Forms;
using EventApp.ViewModels;
using EventApp.Models;
using System;
using Xamarin.Forms.Xaml;
using EventApp.Web;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EventApp.Helpers;
using System.Threading.Tasks;

namespace EventApp.Views
{
    public partial class UsersPage : ContentPage
    {

        public UsersViewModel Uvm;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string type { get; set; }
        public string Type
        {
            get
            {
                switch (type)
                {
                    case "speaker":
                        return "СПИКЕРЫ";
                    case "buyer":
                        return "БАЙЕРЫ";
                    case "disigner":
                        return "ДИЗАЙНЕРЫ";
                    case "sponsor":
                        return "СПОНСОРЫ";
                    case "press":
                        return "ПРЕССА";
                    case "organizer":
                        return "ОРГАНИЗАТОРЫ";
                }
                return "";
            }
        }

        public UsersPage(string attendeesType)
        {
            InitializeComponent();
            type = attendeesType;

            Uvm = new UsersViewModel(attendeesType);
            BindingContext = Uvm;
            

            
        }

        

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = ((ListView)sender).SelectedItem as User;
            if (user == null)
                return;

            await Navigation.PushAsync(new UsersDetailsPage(user));
        }
    }
}