using System;
using System.Collections.Generic;
using SQLite;

namespace EventApp.Db
{

    [Table("Agenda")]
    public class AgendaTable
    {
        public string Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        //public IEnumerable<string> SpeakersId { get; set; }
    }
}
