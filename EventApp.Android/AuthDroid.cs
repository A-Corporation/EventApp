using System;
using System.Threading.Tasks;
using EventApp.Droid;
using EventApp.Web;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace EventApp.Droid
{
    public class AuthDroid : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {

            FirebaseHelper firebaseHelper = new FirebaseHelper();
            try
            {
                email = "artjom-niki@mail.ru";
                password = "123456";
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                App.ProfileUser = await firebaseHelper.GetUserByUID(FirebaseAuth.Instance.CurrentUser.Uid);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        /*
        public bool SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);

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