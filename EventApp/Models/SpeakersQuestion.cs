using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventApp.Models
{
    public class SpeakersQuestion: INotifyPropertyChanged
    {
        //
        public string Question { get; set; }
        public User User { get; set; }
        public int LikesNumber { get; set; }
        //

        public bool isLiked { get; set; }

        public ImageSource LikeImage { get; set; }

        public ICommand LikeCommand { set; get; }
        public event PropertyChangedEventHandler PropertyChanged;



        public SpeakersQuestion()
        {
            isLiked = false;
            LikeImage = "Like";
            LikeCommand = new Command(
                execute: () =>
                {
                    if (!isLiked)
                    {
                        LikesNumber++;
                        LikeImage = "Liked";
                        isLiked = true;

                    }
                    else
                    {
                        LikesNumber--;
                        LikeImage = "Like";
                        isLiked = false;
                    }
                    OnPropertyChanged("LikesNumber");
                    OnPropertyChanged("LikeImage");
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

    public class SSpeakersQuestion
    {
        public string Question { get; set; }
        public string User { get; set; }
        public int LikesNumber { get; set; }

        public SSpeakersQuestion()
        {

        }
    }
}
