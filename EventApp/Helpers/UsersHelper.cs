using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EventApp.Models;
using System.Linq;
using EventApp.Web;
using System.Threading.Tasks;

namespace EventApp.Helpers
{
    public class UsersHelper
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Grouping<string, User>> UsersGrouped { get; set; }


        public UsersHelper(string type)
        {
            //GetUsers(type);


            /*
            switch (type)
            {
                case "speakers":
                    //Загружаем инфу из базы данных
                    Users.Add(new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"));
                    Users.Add(new User("КОТОРЕВА МАРИНА", "Event manager", "JTB","ProfilePhoto"));
                    Users.Add(new User("Прокопьев Григорий", "Consulting manager", "BC", "ProfilePhoto"));
                    Users.Add(new User("Приходов Александр", "Programmist", "ACorp", "ProfilePhoto"));
                    Users.Add(new User("Петрищева Анна", "Sales manager", "Microsoft", "ProfilePhoto"));
                    break;
                case "buyers":
                    //Загружаем инфу из базы данных
                    break;
                case "disigners":
                    //Загружаем инфу из базы данных
                    break;
                case "sponsors":
                    //Загружаем инфу из базы данных
                    break;
                case "press":
                    //Загружаем инфу из базы данных
                    break;
                case "organizers":
                    //Загружаем инфу из базы данных
                    break;

            }
            */

        }

        
        /*
        public async Task GetUsers(string type)
        {
            FirebaseHelper Fh = new FirebaseHelper();
            List<User> users = await Fh.GetAllPersonsByAttendeeList(App.EventName, type);
            Users = new ObservableCollection<User>(users);
            var sorted = from user in Users
                         orderby user.FullName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            UsersGrouped = new ObservableCollection<Grouping<string, User>>(sorted);
            
        }
        */
    }
}
