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

namespace EventApp.ViewModels.Chat
{
    public class ChatMessageViewModel : INotifyPropertyChanged
    {

        public string NewMessage { get; set; }

        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<ChatMessage> DelayedMessages { get; set; } = new Queue<ChatMessage>();
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        public string TextToSend { get; set; }

        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ObservableCollection<ChatMessage> ChatMessageInfo { get; set; }

       

        public ChatMessageViewModel()
        {
            ChatMessageInfo = new ObservableCollection<ChatMessage>();
            GenerateMessageInfo();
            MessageAppearingCommand = new Command<ChatMessage>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<ChatMessage>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    ChatMessageInfo.Add(new ChatMessage() { Message = TextToSend, User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"), Time = DateTime.Now });
                    TextToSend = string.Empty;
                    OnPropertyChanged("ChatMessageInfo");
                }

            });

            //Code to simulate reveing a new message procces
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (LastMessageVisible)
                {
                    Messages.Insert(0, new ChatMessage() { Message = "New message test", User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg") });
                }
                else
                {
                    DelayedMessages.Enqueue(new ChatMessage() { Message = "New message test", User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg") });
                    PendingMessageCount++;
                }
                return true;
            });
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

        #region Methods


        FirebaseClient firebase;

        private async void DisplayChatMessage()
        {
            Messages.Clear();
            var items = await firebase.Child("chats")
                .OnceAsync<ChatMessage>();
            foreach (var item in items)
            {
                Messages.Add(item.Object);
            }
        }



        private void GenerateMessageInfo()
        {
            var currentTime = DateTime.Now;
            this.ChatMessageInfo = new ObservableCollection<ChatMessage>
            {
                new ChatMessage
                {
                    Message = "Привет) как дела?",
                    User = new User
                    {
                        Name = "Игорь",
                        SecondName = "Манн",
                        imageUrl = "https://firebasestorage.googleapis.com/v0/b/randombass-4a605.appspot.com/o/speakers1%2F02_1%20%D0%98%D0%B3%D0%BE%D1%80%D1%8C%20%D0%9C%D0%B0%D0%BD%D0%BD%2C%20%D1%81%D0%B0%D0%BC%D1%8B%D0%B9%20%D0%B8%D0%B7%D0%B2%D0%B5%D1%81%D1%82%D0%BD%D1%8B%D0%B9%20%D0%BC%D0%B0%D1%80%D0%BA%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3%20%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B8%2C%20%D1%81%D0%BF%D0%B8%D0%BA%D0%B5%D1%80%2C%20%D0%B0%D0%B2%D1%82%D0%BE%D1%80%2C%20%D0%B8%D0%B7%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C.jpg?alt=media&token=2e59e54c-0043-41fe-a879-6600098a9573"
                    },
                    Time = currentTime.AddMinutes(-2517),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = "Всё нормально) а у тебя?",
                    User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    Message = "Что вчера делал?",
                    User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"),
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = "отлично) потом при встрече расскажу",
                    User = new User
                    {
                        Name = "Игорь",
                        SecondName = "Манн",
                        imageUrl = "https://firebasestorage.googleapis.com/v0/b/randombass-4a605.appspot.com/o/speakers1%2F02_1%20%D0%98%D0%B3%D0%BE%D1%80%D1%8C%20%D0%9C%D0%B0%D0%BD%D0%BD%2C%20%D1%81%D0%B0%D0%BC%D1%8B%D0%B9%20%D0%B8%D0%B7%D0%B2%D0%B5%D1%81%D1%82%D0%BD%D1%8B%D0%B9%20%D0%BC%D0%B0%D1%80%D0%BA%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3%20%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B8%2C%20%D1%81%D0%BF%D0%B8%D0%BA%D0%B5%D1%80%2C%20%D0%B0%D0%B2%D1%82%D0%BE%D1%80%2C%20%D0%B8%D0%B7%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C.jpg?alt=media&token=2e59e54c-0043-41fe-a879-6600098a9573"
                    },
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = "Когда можем встретиться?",
                    User = new User
                    {
                        Name = "Игорь",
                        SecondName = "Манн",
                        imageUrl = "https://firebasestorage.googleapis.com/v0/b/randombass-4a605.appspot.com/o/speakers1%2F02_1%20%D0%98%D0%B3%D0%BE%D1%80%D1%8C%20%D0%9C%D0%B0%D0%BD%D0%BD%2C%20%D1%81%D0%B0%D0%BC%D1%8B%D0%B9%20%D0%B8%D0%B7%D0%B2%D0%B5%D1%81%D1%82%D0%BD%D1%8B%D0%B9%20%D0%BC%D0%B0%D1%80%D0%BA%D0%B5%D1%82%D0%BE%D0%BB%D0%BE%D0%B3%20%D0%A0%D0%BE%D1%81%D1%81%D0%B8%D0%B8%2C%20%D1%81%D0%BF%D0%B8%D0%BA%D0%B5%D1%80%2C%20%D0%B0%D0%B2%D1%82%D0%BE%D1%80%2C%20%D0%B8%D0%B7%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C.jpg?alt=media&token=2e59e54c-0043-41fe-a879-6600098a9573"
                    },
                    Time = currentTime.AddMinutes(-1006),
                    IsReceived = true
                },
            };
        }



        void OnMessageAppearing(ChatMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(ChatMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }

        #endregion
    }
}