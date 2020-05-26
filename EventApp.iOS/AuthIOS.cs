using System;
using System.Threading.Tasks;
using EventApp.iOS;
using Xamarin.Forms;
using Firebase.Auth;
using EventApp.Web;

[assembly: Dependency(typeof(AuthIOS))]
namespace EventApp.iOS
{
    public class AuthIOS : IAuth
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                App.ProfileUser = await firebaseHelper.GetUserByUID(Auth.DefaultInstance.CurrentUser.Uid);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }

        /*
        public bool SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = Auth.DefaultInstance.CreateUserAsync(email, password);
                return signUpTask.Result != null;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        */
    }
}