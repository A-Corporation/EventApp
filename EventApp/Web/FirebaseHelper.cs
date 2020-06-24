using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Firebase.Database;
using Firebase.Database.Query;
using EventApp.Models;
using System.Collections.ObjectModel;
using EventApp.Helpers;
using System.Threading.Tasks;
using EventApp.Models.Chat;

namespace EventApp.Web
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://randombass-4a605.firebaseio.com/");

        public async System.Threading.Tasks.Task<ObservableCollection<Grouping<string, User>>> GetAllPersons()
        {
            
            List<User> list = (await firebase.Child("Users").OnceAsync<User>()).Select(
                item => new User
                {
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    imageUrl = item.Object.imageUrl
                }).ToList();
            ObservableCollection<User> Users = new ObservableCollection<User>(list);
            var sorted = from user in Users
                         orderby user.SecondName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            return new ObservableCollection<Grouping<string, User>>(sorted);
        }



        public async System.Threading.Tasks.Task<AgendaParce> ParceEvent(string eventName)
        {
            List<Attendee> attendees = await GetAllAttendees(eventName);
            return await firebase.Child("Event").Child(eventName).Child("Attendees").OnceSingleAsync<AgendaParce>();
        }



        public async System.Threading.Tasks.Task<List<Attendee>> GetAllAttendees(string eventName)
        {
            return (await firebase.Child("Event").Child(eventName).Child("Attendees").OnceAsync<Attendee>()).Select(
                item => new Attendee() { Key = item.Object.Key }).ToList();
        }



        public async System.Threading.Tasks.Task<List<Attendee>> GetAllAttendeesWithType(string eventName, string type)
        {
            return (await firebase
                .Child("Events").Child(eventName).Child("Attendees")
                .OnceAsync<Attendee>()).Where(a => a.Object.Type == type).Select(
                item => new Attendee() { Key = item.Object.Key, Type = item.Object.Type }).ToList();
        }

        public async System.Threading.Tasks.Task<ObservableCollection<Grouping<string, User>>> GetAllPersonsByAttendeeList(string eventName, string type)
        {

            List<Attendee> attendees = await GetAllAttendeesWithType(eventName, type);
            List<string> keys = attendees.Select(item => item.Key).ToList();
            List<User> list = (await firebase.Child("Users").OnceAsync<User>()).Where(a => keys.Contains(a.Key) == true).Select(
                item => new User()
                {
                    //FullName = item.Object.FullName,
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    imageUrl = item.Object.imageUrl
                }).ToList();
            
            ObservableCollection<User> Users = new ObservableCollection<User>(list);
            Console.WriteLine(Users.Count);
            var sorted = from user in Users
                         orderby user.SecondName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            return new ObservableCollection<Grouping<string, User>>(sorted);
        }



        public async System.Threading.Tasks.Task AddAttendee(string eventName, string key)
        {
            await firebase
              .Child("Event").Child(eventName).Child("Attendees")
              .PostAsync(new Attendee() { Key = key });
        }


        public async System.Threading.Tasks.Task<User> GetUserByKey(string userKey)
        {
            return (await firebase.Child("Events").Child("Event 1").Child("Users").OnceAsync<User>()).Where(a => a.Key == userKey).Select(item => new User()
            {
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                imageUrl = item.Object.imageUrl
            }).FirstOrDefault();
        }


        // AGENDA

        public async System.Threading.Tasks.Task<ObservableCollection<Grouping<string, AgendaItem>>> ParceAgendaItems(string eventName)
        {
            List<AgendaItem> agendas = (await firebase.Child("Events").Child(eventName).Child("AgendaItems").OnceAsync<AgendaItem>()).Select(
                item => new AgendaItem()
                {
                    Date = item.Object.Date,
                    StartTime = item.Object.StartTime,
                    EndTime = item.Object.EndTime,
                    Location = item.Object.Location,
                    Title = item.Object.Title,
                    Key = item.Key
                }).ToList();

            List<List<string>> keysLList = new List<List<string>>();
            List<string> bufstr = new List<string>();

            foreach (var item in agendas)
            {
                item.Sspeaker = await ParceSpeakersKeys(eventName, item.Key);
            }

            foreach (var item in agendas)
            {
                item.Speakers = await GetUsersByKeysList(item.Sspeaker);
            }

            ObservableCollection<AgendaItem> AgendaItems = new ObservableCollection<AgendaItem>(agendas);

            var sorted = from item in AgendaItems
                         orderby item.StartTime
                         group item by item.StartTime into itemGroup
                         select new Grouping<string, AgendaItem>(itemGroup.Key, itemGroup);

            return new ObservableCollection<Grouping<string, AgendaItem>>(sorted);
        }

        



        public async System.Threading.Tasks.Task<List<SpeakerKey>> ParceSpeakersKeys(string EventName, string AgendaName)
        {
            return (await firebase.Child("Events").Child(EventName).Child("AgendaItems").Child(AgendaName).Child("SSpeakers").OnceAsync<SpeakerKey>()).Select(
                item => new SpeakerKey { Key = item.Object.Key }).ToList();
        }

        public async System.Threading.Tasks.Task<ObservableCollection<User>> GetUsersByKeysList(List<SpeakerKey> keys)
        {
            List<string> lkeys = keys.Select(item => item.Key).ToList();
            List<User> users = (await firebase.Child("Users").OnceAsync<User>()).Where(a => lkeys.Contains(a.Key)).Select(
                item => new User()
                {
                    //FullName = item.Object.FullName,
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    imageUrl = item.Object.imageUrl
                }).ToList();
            return new ObservableCollection<User>(users);
        }



        //Photo

        public async System.Threading.Tasks.Task<ObservableCollection<Photo>> ParcePhotos(string eventName)
        {
            List<SPhoto> sphotos = (await firebase.Child("Events").Child(eventName).Child("Photos").OnceAsync<SPhoto>()).Select(
                item => new SPhoto() { PhotoUrl = item.Object.PhotoUrl, User = item.Object.User, LikesNumber = item.Object.LikesNumber }).ToList();
            List<Photo> photos = new List<Photo>();
            foreach (var ph in sphotos)
            {
                photos.Add(new Photo() { LikesNumber = ph.LikesNumber, PhotoUrl = ph.PhotoUrl, User = await GetUserByKey(ph.User) });
            }
            return new ObservableCollection<Photo>(photos);
        }


        //SPEAKERS QUESTIONS

        public async System.Threading.Tasks.Task<ObservableCollection<SpeakersQuestion>> ParseSpeakersQuestion(string eventName)
        {
            List<SSpeakersQuestion> ssq = (await firebase.Child("Events").Child(eventName).Child("Attendees").OnceAsync<SSpeakersQuestion>()).Select(
                item => new SSpeakersQuestion() { Question = item.Object.Question, User = item.Object.User, LikesNumber = item.Object.LikesNumber }).ToList();
            List<SpeakersQuestion> questions = new List<SpeakersQuestion>();
            foreach (var sq in ssq)
            {
                questions.Add(new SpeakersQuestion() { Question = sq.Question, User = await GetUserByKey(sq.User), LikesNumber = sq.LikesNumber });
            }
            return new ObservableCollection<SpeakersQuestion>(questions);
        }




        public async Task<User> GetUserByUID(string uid, string eventName)
        {
            return (await firebase.Child("Events").Child(eventName).Child("Users").OnceAsync<User>()).Where(a => a.Object.Uid == uid).Select(item => new User()
            {
                Uid = item.Object.Uid,
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                imageUrl = item.Object.imageUrl
            }).FirstOrDefault();
        }


        public async Task SaveMessage(ChatMessage message)
        {
            await firebase.Child("Events/" + "Event 1" + "/Chats/" + "MainChat").PostAsync(message);
        }

        
        public ObservableCollection<ChatMessage> GetMessages2()
        {
            return firebase.Child("Events/Event 1/Chats/MainChat")
                .AsObservable<ChatMessage>()
                .AsObservableCollection();
        }
        

        
        public async Task<ObservableCollection<ChatMessage>> GetMessages()
        {
            List<ChatMessage> chatMessages = (await firebase.Child("Events/" + "Event 1" + "/Chats/ " + "MainChat").OnceAsync<ChatMessage>()).Select(
                item => new ChatMessage() { Id = item.Object.Id, UserId = item.Object.UserId, UserName = item.Object.UserName, Text = item.Object.Text, ImageUrl = item.Object.ImageUrl, Time = item.Object.Time }).ToList();
            return new ObservableCollection<ChatMessage>(chatMessages);
        }
        

    }
}
