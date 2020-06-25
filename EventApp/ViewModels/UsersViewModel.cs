using System;
using System.Collections.ObjectModel;
using EventApp.Models;
using System.Linq;
using EventApp.Helpers;
using EventApp.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace EventApp.ViewModels
{

    public class UsersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }
        private ObservableCollection<Grouping<string, User>> usersGrouped;
        public ObservableCollection<Grouping<string, User>> UsersGrouped
        {
            set
            {
                usersGrouped = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("UsersGrouped"));
            }

            get
            {
                return usersGrouped;
            }
        }

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


        

        public string UsersCount => Users.Count.ToString() + " speakers";

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public event PropertyChangedEventHandler PropertyChanged;



        public UsersViewModel(string type_)
        {
            type = type_;
            UsersGrouped = new ObservableCollection<Grouping<string, User>>();
            UsersGrouped = App.LocalDB.ParceUsers();

        }


        


    }
}
