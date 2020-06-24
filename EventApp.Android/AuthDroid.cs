using System;
using System.Threading.Tasks;
using EventApp.Droid;
using EventApp.Models;
using EventApp.Services;
using EventApp.Web;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace EventApp.Droid
{
    public class AuthDroid : IFirebaseAuth
    {
        public bool IsSigned()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailPassword(string email, string password, string eventName)
        {

            FirebaseHelper firebaseHelper = new FirebaseHelper();
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                App.ProfileUser = await firebaseHelper.GetUserByUID(FirebaseAuth.Instance.CurrentUser.Uid, eventName);
                if (App.ProfileUser == null)
                    return "";
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }

        public async Task<User> GetUser(string eventName)
        {
            FirebaseHelper firebaseHelper = new FirebaseHelper();
            return await firebaseHelper.GetUserByUID(FirebaseAuth.Instance.CurrentUser.Uid, eventName);
        }

        public string GetUid()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

    }
}