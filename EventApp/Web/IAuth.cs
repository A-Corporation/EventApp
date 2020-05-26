using System;
using System.Threading.Tasks;


namespace EventApp.Web
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);

    }
}
