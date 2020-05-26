using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventApp.Models
{
    public class VotingItem: INotifyPropertyChanged
    {

        public string Answer { get; set; }
        public int VotesNumber { get; set; }
        public double VotesPercent { get; set; }
        public bool IsVoted { get; set; }

        public ICommand VoteCommand { set; get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public VotingItem()
        {
            IsVoted = false;
            VoteCommand = new Command<int>(
                execute: (int allVotesNumber) =>
                {
                    if (!IsVoted)
                    {
                        VotesNumber++;
                        IsVoted = true;

                    }
                    else
                    {
                        VotesNumber--;
                        IsVoted = false;
                    }
                    VotesPercent = VotesNumber / allVotesNumber;
                    OnPropertyChanged("VotesNumber");
                }
            );
        }

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
