using System;
using System.Threading.Tasks;
using EventApp.iOS;
using Xamarin.Forms;
using Firebase.Auth;
using EventApp.Web;
using Foundation;
using EventApp.Services;

[assembly: Dependency(typeof(AuthIOS))]
namespace EventApp.iOS
{
    public class AuthIOS : IFirebaseAuth
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public string GetUid()
        {
            throw new NotImplementedException();
        }


        public Task<Models.User> GetUser(string eventName)
        {
            throw new NotImplementedException();
        }

        public bool IsSigned()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailPassword(string email, string password, string eventName)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                App.ProfileUser = await firebaseHelper.GetUserByUID(Auth.DefaultInstance.CurrentUser.Uid, eventName);
                if (App.ProfileUser == null)
                    return "";
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public bool SignOut()
        {
            try
            {
                _ = Auth.DefaultInstance.SignOut(out NSError error);
                return error == null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}