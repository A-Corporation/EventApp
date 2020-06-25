using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EventApp.Db;
using EventApp.Helpers;
using EventApp.Models;
using EventApp.Web;
using SQLite;
using Xamarin.Forms;

namespace EventApp.Services
{
    public class LocalDatabase
    {
        SQLiteConnection database;
        FirebaseHelper firebase;

        public LocalDatabase(string eventName)
        {
            var dbPath = "";
            string dbFile = "EventApp_" + eventName + ".db3";

#if ANDROID
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dbPath = Path.Combine(docPath, dbFile);
#elif IOS
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libPath = Path.Combine(docPath, dbFile)
            dbPath = Path.Combine(libPath, dbFile);
#endif

            database = new SQLiteConnection(dbPath);
            database.CreateTable<AgendaTable>();
            database.CreateTable<UsersTable>();
            database.CreateTable<AgendaUsersTable>();

            firebase = new FirebaseHelper();

            Device.BeginInvokeOnMainThread(async () =>
            {

                List<AgendaItem> agendaItems = await firebase.GetAgendaItems(App.EventName);
                List<AgendaTable> agenda = agendaItems.Select(
                item => new AgendaTable()
                {
                    Id = item.Id,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Location = item.Location,
                    Title = item.Title
                }).ToList();


                List<User> users = await firebase.GetUsers(App.EventName);
                List<UsersTable> usersT = users.Select(
                item => new UsersTable
                {
                    Uid = item.Uid,
                    Name = item.Name,
                    SecondName = item.SecondName,
                    JobPosition = item.JobPosition,
                    CompanyName = item.CompanyName,
                    ImageUrl = item.ImageUrl,
                }).ToList();



                foreach (var item in agendaItems)
                {
                    foreach (var uid in item.SpeakersId)
                    {
                        database.Insert(new AgendaUsersTable { Uid = uid, AgendaId = item.Id });
                    }
                }


                foreach (var item in agenda)
                    database.Insert(item);

                foreach (var item in usersT)
                    database.Insert(item);



        });
        }


      

        
        public ObservableCollection<Grouping<string, AgendaItem>> ParceAgenda()
        {
            List<AgendaItem> agendas = database.Query<AgendaItem>("Select * From [Agenda]");

            foreach (var item in agendas)
            {
                item.SpeakersId = new List<string>(from s in database.Table<AgendaUsersTable>()
                                  where s.AgendaId == item.Id
                                  select s.Uid);
            }


            ObservableCollection<AgendaItem> AgendaItems = new ObservableCollection<AgendaItem>(agendas);

            var sorted = from item in AgendaItems
                         orderby item.StartTime
                         group item by item.StartTime into itemGroup
                         select new Grouping<string, AgendaItem>(itemGroup.Key, itemGroup);

            return new ObservableCollection<Grouping<string, AgendaItem>>(sorted);
        }


        public ObservableCollection<Grouping<string, User>> ParceUsers()
        {
            List<User> users = database.Query<User>("Select * From [Users]");


            foreach (var user in users)
            {
                user.AgendaItemsId = new List<string>(from s in database.Table<AgendaUsersTable>()
                                                 where s.Uid == user.Uid
                                                 select s.AgendaId);
            }

            ObservableCollection<User> Users = new ObservableCollection<User>(users);
            var sorted = from user in Users
                         orderby user.SecondName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            return new ObservableCollection<Grouping<string, User>>(sorted);
        }



        public ObservableCollection<User> GetUsersByUIDList(List<string> usersId)
        {

            return new ObservableCollection<User>(database.Query<User>("Select * From [Users] Where Uid In ?", (from user in usersId select user)));
        }

    }
}
