using System;
using EventApp.Models;

namespace EventApp.ViewModels
{
    public class AgendaDetailsViewModel
    {
        public AgendaItem AgendaItem { get; set; }

        public AgendaDetailsViewModel(AgendaItem agendaItem)
        {
            AgendaItem = agendaItem;
        }
    }
}
