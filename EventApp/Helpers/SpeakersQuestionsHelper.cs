using System;
using System.Collections.ObjectModel;
using EventApp.Models;

namespace EventApp.Helpers
{
    public class SpeakersQuestionsHelper
    {

        public ObservableCollection<SpeakersQuestion> SpeakersQuestions { get; set; }

        public SpeakersQuestionsHelper()
        {
            SpeakersQuestions = new ObservableCollection<SpeakersQuestion>();
            CreateSpeakersQuestionsCollection();
        }


        private void CreateSpeakersQuestionsCollection()
        {
            SpeakersQuestions.Add(new SpeakersQuestion
            {
                Question = "Как вас зовут?",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                LikesNumber = 10
            });

            SpeakersQuestions.Add(new SpeakersQuestion
            {
                Question = "Как у вас дела?",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                LikesNumber = 3
            });

            SpeakersQuestions.Add(new SpeakersQuestion
            {
                Question = "Как долго вы этим занимались?",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                LikesNumber = 5
            });

            SpeakersQuestions.Add(new SpeakersQuestion
            {
                Question = "Что с вами случилось?",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                LikesNumber = 1
            });
        }
    }
}
