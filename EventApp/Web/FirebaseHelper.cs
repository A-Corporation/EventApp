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
using EventApp.Db;

namespace EventApp.Web
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://randombass-4a605.firebaseio.com/");

        public async Task<ObservableCollection<Grouping<string, User>>> GetAllPersons(string eventName)
        {
            
            List<User> list = (await firebase.Child("Events").Child(eventName).Child("Users").OnceAsync<User>()).Select(
                item => new User
                {
                    Uid = item.Object.Uid,
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    ImageUrl = item.Object.ImageUrl
                }).ToList();

            

            ObservableCollection<User> Users = new ObservableCollection<User>(list);
            var sorted = from user in Users
                         orderby user.SecondName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            return new ObservableCollection<Grouping<string, User>>(sorted);
        }



        public async Task<AgendaParce> ParceEvent(string eventName)
        {
            List<Attendee> attendees = await GetAllAttendees(eventName);
            return await firebase.Child("Events").Child(eventName).Child("Attendees").OnceSingleAsync<AgendaParce>();
        }



        public async Task<List<Attendee>> GetAllAttendees(string eventName)
        {
            return (await firebase.Child("Events").Child(eventName).Child("Attendees").OnceAsync<Attendee>()).Select(
                item => new Attendee() { Key = item.Object.Key }).ToList();
        }



        public async Task<List<Attendee>> GetAllAttendeesWithType(string eventName, string type)
        {
            return (await firebase
                .Child("Events").Child(eventName).Child("Attendees")
                .OnceAsync<Attendee>()).Where(a => a.Object.Type == type).Select(
                item => new Attendee() { Key = item.Object.Key, Type = item.Object.Type }).ToList();
        }

        public async Task<ObservableCollection<Grouping<string, User>>> GetAllPersonsByAttendeeList(string eventName, string type)
        {

            List<Attendee> attendees = await GetAllAttendeesWithType(eventName, type);
            List<string> keys = attendees.Select(item => item.Key).ToList();
            List<User> list = (await firebase.Child("Events").Child(App.EventName).Child("Users").OnceAsync<User>()).Where(a => keys.Contains(a.Key) == true).Select(
                item => new User()
                {
                    //FullName = item.Object.FullName,
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    ImageUrl = item.Object.ImageUrl
                }).ToList();
            
            ObservableCollection<User> Users = new ObservableCollection<User>(list);
            Console.WriteLine(Users.Count);
            var sorted = from user in Users
                         orderby user.SecondName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            return new ObservableCollection<Grouping<string, User>>(sorted);
        }



        public async Task AddAttendee(string eventName, string key)
        {
            await firebase
              .Child("Events").Child(eventName).Child("Attendees")
              .PostAsync(new Attendee() { Key = key });
        }


        public async Task<User> GetUserByKey(string userKey)
        {
            return (await firebase.Child("Events").Child("Event1").Child("Users").OnceAsync<User>()).Where(a => a.Key == userKey).Select(item => new User()
            {
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                ImageUrl = item.Object.ImageUrl
            }).FirstOrDefault();
        }


        // AGENDA

        public async Task<ObservableCollection<Grouping<string, AgendaItem>>> ParceAgendaItems(string eventName)
        {
            List<AgendaItem> agendas = (await firebase.Child("Events").Child(eventName).Child("AgendaItems").OnceAsync<AgendaItem>()).Select(
                item => new AgendaItem()
                {
                    Id = item.Object.Id,
                    Date = item.Object.Date,
                    StartTime = item.Object.StartTime,
                    EndTime = item.Object.EndTime,
                    Location = item.Object.Location,
                    Title = item.Object.Title,
                    //SpeakersId = new List<string>(item.Object.SpeakersId)
                }).ToList();
            /*
            foreach (var a in agendas)
                Console.WriteLine(a.Title, a.Time);
            */
            /*
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
            */
            ObservableCollection<AgendaItem> AgendaItems = new ObservableCollection<AgendaItem>(agendas);

            var sorted = from item in AgendaItems
                         orderby item.StartTime
                         group item by item.StartTime into itemGroup
                         select new Grouping<string, AgendaItem>(itemGroup.Key, itemGroup);

            return new ObservableCollection<Grouping<string, AgendaItem>>(sorted);
        }


        public async Task<List<AgendaItem>> GetAgendaItems(string eventName)
        {
            return (await firebase.Child("Events").Child(eventName).Child("AgendaItems").OnceAsync<AgendaItem>()).Select(
                item => new AgendaItem()
                {
                    Id = item.Object.Id,
                    Date = item.Object.Date,
                    StartTime = item.Object.StartTime,
                    EndTime = item.Object.EndTime,
                    Location = item.Object.Location,
                    Title = item.Object.Title,
                    SpeakersId = new List<string>(item.Object.SpeakersId)
                }).ToList();


        }


        public async Task<List<AgendaTable>> GetAgenda(string eventName)
        {
            return (await firebase.Child("Events").Child(eventName).Child("AgendaItems").OnceAsync<AgendaTable>()).Select(
                item => new AgendaTable()
                {
                    Id = item.Object.Id,
                    Date = item.Object.Date,
                    StartTime = item.Object.StartTime,
                    EndTime = item.Object.EndTime,
                    Location = item.Object.Location,
                    Title = item.Object.Title,
                }).ToList();


        }


        public async Task<List<User>> GetUsers(string eventName)
        {

            return (await firebase.Child("Events").Child(eventName).Child("Users").OnceAsync<User>()).Select(
            item => new User
            {
                Uid = item.Object.Uid,
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                ImageUrl = item.Object.ImageUrl,
                AgendaItemsId = new List<string>(item.Object.AgendaItemsId)
            }).ToList();
        }

        public async Task<List<UsersTable>> GetUsersTable(string eventName)
        {

            return (await firebase.Child("Events").Child(eventName).Child("Users").OnceAsync<UsersTable>()).Select(
            item => new UsersTable
            {
                Uid = item.Object.Uid,
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                ImageUrl = item.Object.ImageUrl,
                //AgendaItemsId = new List<string>(item.Object.AgendaItemsId)
            }).ToList();
        }



        public async Task<List<SpeakerKey>> ParceSpeakersKeys(string EventName, string AgendaName)
        {
            return (await firebase.Child("Events").Child(EventName).Child("AgendaItems").Child(AgendaName).Child("SSpeakers").OnceAsync<SpeakerKey>()).Select(
                item => new SpeakerKey { Key = item.Object.Key }).ToList();
        }

        public async Task<ObservableCollection<User>> GetUsersByKeysList(List<SpeakerKey> keys)
        {
            List<string> lkeys = keys.Select(item => item.Key).ToList();
            List<User> users = (await firebase.Child("Events").Child(App.EventName).Child("Users").OnceAsync<User>()).Where(a => lkeys.Contains(a.Key)).Select(
                item => new User()
                {
                    //FullName = item.Object.FullName,
                    Name = item.Object.Name,
                    SecondName = item.Object.SecondName,
                    JobPosition = item.Object.JobPosition,
                    CompanyName = item.Object.CompanyName,
                    ImageUrl = item.Object.ImageUrl
                }).ToList();
            return new ObservableCollection<User>(users);
        }



        //Photo

        public async Task<ObservableCollection<Photo>> ParcePhotos(string eventName)
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
                ImageUrl = item.Object.ImageUrl
            }).FirstOrDefault();
        }

        public async Task<ObservableCollection<User>> GetUsersByUIDList(List<string> usersId, string eventName)
        {
            return new ObservableCollection<User>((await firebase.Child("Events").Child(eventName).Child("Users").OnceAsync<User>()).Where(a => usersId.Contains(a.Object.Uid)).Select(item => new User()
            {
                Uid = item.Object.Uid,
                Name = item.Object.Name,
                SecondName = item.Object.SecondName,
                JobPosition = item.Object.JobPosition,
                CompanyName = item.Object.CompanyName,
                ImageUrl = item.Object.ImageUrl
            }).ToList());
        }


        public async Task SaveMessage(ChatMessage message)
        {
            await firebase.Child("Events/" + "Event1" + "/Chats/" + "MainChat").PostAsync(message);
        }

        
        public ObservableCollection<ChatMessage> GetMessages()
        {
            return firebase.Child("Events/Event1/Chats/MainChat")
                .AsObservable<ChatMessage>()
                .AsObservableCollection();
        }
        


        

    }
}
