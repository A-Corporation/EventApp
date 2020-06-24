using System;
using System.Threading.Tasks;
using EventApp.Models;

namespace EventApp.Services
{
    public interface IFirebaseAuth
    {
        Task<User> GetUser(string eventName);
        Task<string> LoginWithEmailPassword(string email, string password, string eventName);
        bool SignOut();
        bool IsSigned();
        string GetUid();
    }
}
