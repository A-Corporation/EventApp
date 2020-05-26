using System;
using System.Collections.Generic;
using EventApp.Models;
using EventApp.ViewModels;
using Xamarin.Forms;

namespace EventApp.Views
{
    public partial class SpeakersQuestionsDetailsPage : ContentPage
    {
        SpeakersQuestionsDetailsViewModel SQDvm { get; set; }
        bool isLiked = false;

        public SpeakersQuestionsDetailsPage(AgendaItem agendaItem)
        {
            
            
            InitializeComponent();
            SQDvm = new SpeakersQuestionsDetailsViewModel(agendaItem);
            BindingContext = SQDvm;
        }



        public void SendQuestion_Clicked(object sender, EventArgs e)
        {
            SQDvm.AddQuestion();
            EntryText.Text = "";
            QuestionsList.ScrollTo(ScrollToPosition.End, true);

        }



    }
}
