using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using EventApp.Models;
using Xamarin.Forms;

namespace EventApp.ViewModels
{
    public class VotingViewModel : INotifyPropertyChanged
    {
        public string Tittle { get; set; }
        public ObservableCollection<VotingItem> VotingItems { get; set; }
        public int AllVotesNumber => CountVotes();
        public bool IsDetailsVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DetailsVisibleCommand { set; get; }

        public VotingViewModel()
        {
            IsDetailsVisible = false;
            VotingItems = new ObservableCollection<VotingItem>();
            CreateVoting();
            DetailsVisibleCommand = new Command(
                execute: () =>
                {
                    if (!IsDetailsVisible)
                    {
                        IsDetailsVisible = true;
                    }
                    else
                    {
                        IsDetailsVisible = false;
                    }
                    OnPropertyChanged("IsDetailsVisible");
                }
            );
            
        }


        public int CountVotes()
        {
            int result = 0;
            foreach (VotingItem item in VotingItems)
            {
                result += item.VotesNumber;
            }
            return result;
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        void CreateVoting()
        {
            Tittle = "Лучший игрок";
            VotingItems.Add(new VotingItem
            {
                Answer = "Артём Никитин"
            });
            VotingItems.Add(new VotingItem
            {
                Answer = "Криштьяну Рональду"
            });
            VotingItems.Add(new VotingItem
            {
                Answer = "Лионель Месси"
            });

            VotingItems.Add(new VotingItem
            {
                Answer = "Артём Дзюба"
            });
        }
    }
}
