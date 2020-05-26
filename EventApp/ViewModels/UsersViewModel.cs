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

    public class UsersViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Grouping<string, User>> UsersGrouped { get; set; }

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



        public UsersViewModel(string type_)
        {
            type = type_;
            
        }


        


    }
}
