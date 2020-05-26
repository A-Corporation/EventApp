using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using EventApp.Helpers;
using EventApp.Models;

namespace EventApp.ViewModels
{
    public class SpeakersQuestionsDetailsViewModel
    {
        public ObservableCollection<SpeakersQuestion> SpeakersQuestions { get; set; }
        public AgendaItem AgendaItem { get; set; }
        public string NewQuestion { get; set; }

        public SpeakersQuestionsDetailsViewModel(AgendaItem agendaItem)
        {
            AgendaItem = agendaItem;
            SpeakersQuestions = agendaItem.SpeakersQuestions;
            Sort();
        }

        public void Sort()
        {
            SpeakersQuestions.OrderBy(x=>x.LikesNumber).ToList();
        }




        public void AddQuestion()
        {
            SpeakersQuestions.Add(new SpeakersQuestion {
                Question = NewQuestion,
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                LikesNumber = 0
            });
        }




        

    }
}
