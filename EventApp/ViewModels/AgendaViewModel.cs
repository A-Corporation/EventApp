using System.Collections.ObjectModel;
using EventApp.Models;
using EventApp.Helpers;

namespace EventApp.ViewModels
{
    public class AgendaViewModel
    {
        public ObservableCollection<AgendaItem> AgendaItems { get; set; }
        public ObservableCollection<Grouping<string, AgendaItem>> AgendaItemsGrouped { get; set; }


        public AgendaViewModel()
        {
            Agenda Agenda = new Agenda();
            AgendaItems = Agenda.AgendaItems;
            AgendaItemsGrouped = Agenda.AgendaItemsGrouped;
        }
    }
}
