using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EventApp.Models.Chat;
using EventApp.Helpers;
using EventApp.Models;
using System.Windows.Input;
using System.Collections.Generic;
using Firebase.Database;
using EventApp.Web;

namespace EventApp.ViewModels.Chat
{
    public class ChatMessageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ChatMessage> Messages { get; set; }

        public ObservableCollection<ChatMessage> ChatMessageInfo { get; set; }
        FirebaseHelper firebase;


        public ChatMessageViewModel()
        {
            firebase = new FirebaseHelper();
            ChatMessageInfo = new ObservableCollection<ChatMessage>();
            Messages = new ObservableCollection<ChatMessage>();
  
            
            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}