using System;
using System.Collections.Generic;
using System.Windows.Input;
using EventApp.Views;
using Xamarin.Forms;

namespace EventApp.Models
{
    public class User
    {
        // Идентификатор пользолвателя в Firebase
        public string Uid { get; set; }

        // Фото участника
        public string ImageUrl { get; set; }

        //ФИО
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FullName => Name + " " + SecondName;

        // Место работы и должность
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }

        // Контактные данные
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

        // Доп информация
        public string Info { get; set; }

        public string DetailInfo {
            get {
                return JobPosition + ", " + CompanyName;
            }
        }

        public List<string> AgendaItemsId { get; set; }

        // Лекции
        public List<AgendaItem> Lectures { get; set; }
        

        public string NameSort => SecondName[0].ToString().ToUpper();


        public ICommand UserDetailsPageTransitCommand { set; get; }


        public User() {
            UserDetailsPageTransitCommand = new Command(
                execute: () =>
                {
                    App.CurPage.Navigation.PushAsync(new UsersDetailsPage(this));
                }
            );
        }

        public User(string fullName_, string jobPosition_, string componyName_, string imageUrl)
        {
            JobPosition = jobPosition_;
            CompanyName = componyName_;
            this.ImageUrl = imageUrl;
            UserDetailsPageTransitCommand = new Command(
                execute: () =>
                {
                    App.CurPage.Navigation.PushAsync(new UsersDetailsPage(this));
                }
            );
        }
    }


    public class Attendee
    {
        public string Key { get; set; }
        public string Type { get; set; }
    }



    public class SpeakerKey
    {
        public string Key { get; set; }
        public SpeakerKey() { }
        public SpeakerKey(string str) { Key = str; }
    }




}
