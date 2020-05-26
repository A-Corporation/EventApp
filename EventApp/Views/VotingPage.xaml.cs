using System;
using System.Collections.Generic;
using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;

namespace EventApp.Views
{
    public partial class VotingPage : ContentPage
    {
        VotingViewModel Vvm { get; set; }

        public VotingPage()
        {
            
            InitializeComponent();
            Vvm = new VotingViewModel();
            BindingContext = Vvm;
        }
    }
}
