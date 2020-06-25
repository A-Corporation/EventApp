using System.Collections.ObjectModel;
using EventApp.Models;
using EventApp.Helpers;
using Xamarin.Forms;
using EventApp.Web;
using System.ComponentModel;

namespace EventApp.ViewModels
{
    public class AgendaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AgendaItem> AgendaItems { get; set; }

        public ObservableCollection<Grouping<string, AgendaItem>> agendaItemsGrouped;
        public ObservableCollection<Grouping<string, AgendaItem>> AgendaItemsGrouped
        {
            set
            {
                if (agendaItemsGrouped != value)
                {
                    agendaItemsGrouped = value;

                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("AgendaItemsGrouped"));
                }
                
            }
            get
            {
                return agendaItemsGrouped;
            }
        }
        private FirebaseHelper firebase;

        public event PropertyChangedEventHandler PropertyChanged;

        public AgendaViewModel()
        {

            AgendaItemsGrouped = new ObservableCollection<Grouping<string, AgendaItem>>();
           
            AgendaItemsGrouped = App.LocalDB.ParceAgenda();


        }


    }
}
