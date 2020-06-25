using System;
using System.Collections.Generic;
using SQLite;

namespace EventApp.Db
{
    [Table("Users")]
    public class UsersTable
    {
        public string Uid { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Info { get; set; }
        //public List<string> AgendaItemsId { get; set; }
    }
}
