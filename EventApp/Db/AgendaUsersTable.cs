using System;
using SQLite;

namespace EventApp.Db
{
    [Table("AgendaUsers")]
    public class AgendaUsersTable
    {

        /*
        public AgendaUsersTable(string uid, string id)
        {
            Uid = uid;
            AgendaId = id;
        }
        */
        public string AgendaId { get; set; }
        public string Uid { get; set; }
    }
}
