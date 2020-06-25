using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EventApp.Web;
using Xamarin.Forms;

namespace EventApp.Models
{
    
    public class AgendaItem
    {
        public string Id { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string Time {
            get {
                if (EndTime != null)
                {
                    return StartTime + " - " + EndTime;
                }
                else {
                    return StartTime;
                }
                
            }
        }

        public string Date { get; set; }

        public string Title { get; set; }
        public string Location { get; set; }

        public List<string> SpeakersId { get; set; }

        /*
        public string LectureType
        {
            set
            {
                LectureType = value;
            }
            
            get
            {
                return (Speakers.Count > 1 ? "ОБСУЖДЕНИЕ" : "ЛЕКЦИЯ");
            }
            
        }



        
        //public User Speaker { get; set; }
        public ObservableCollection<SpeakersQuestion> SpeakersQuestions { get; set; }
        
        public User Speaker => Speakers[0];
        public string Key { get; set; }
        public List<SpeakerKey> Sspeaker { get; set; }
        

        public ObservableCollection<User> Speakers => App.LocalDB.GetUsersByUIDList(SpeakersId);

        public bool Questions => Speakers.Count > 0;
        public bool AdditionInfo => Speakers.Count > 0;
        public bool OneSpeaker => Speakers.Count == 1;
        public bool SpeakersList => Speakers.Count > 1;
        public string Orientation => (Speakers.Count > 1 ? "Horizontal" : "Vertical");
        public string SpeakerType => (Speakers.Count > 1 ? "СПИКЕРЫ" : "СПИКЕР");
        public bool NameInfo => Speakers.Count <= 1;
        
        */


        public AgendaItem()
        {
            //FirebaseHelper firebase = new FirebaseHelper();
            /*
            Device.BeginInvokeOnMainThread(async () =>
            {
                Speakers = await firebase.GetUsersByUIDList(SpeakersId, App.EventName);
            });
            */


            //CreateSpeakersQuestionsCollection();

        }
        


        /*
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
        */
    }




    public class AgendaParce : AgendaItem
    {
        public List<Attendee> Attendees { get; set; }
    }

}
