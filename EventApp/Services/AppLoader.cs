using System;
using System.Collections.Generic;
using System.IO;
using EventApp.Db;
using EventApp.Models;
using EventApp.Web;
using SQLite;
using Xamarin.Forms;

namespace EventApp.Services
{
    public class AppLoader
    {
        
        private FirebaseHelper firebase;


        public AppLoader()
        {
            App.LocalDB = new LocalDatabase(App.EventName);

            
            
            

        }


        



    }
}
