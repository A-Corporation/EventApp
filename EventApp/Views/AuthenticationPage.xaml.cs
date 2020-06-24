using System;
using System.Collections.Generic;
using System.ComponentModel;
using EventApp.Helpers;
using EventApp.Services;
using EventApp.Web;
using Xamarin.Forms;

namespace EventApp.Views
{
    [DesignTimeVisible(true)]
    public partial class AuthenticationPage : ContentPage
    {
        private IFirebaseAuth auth;
        private FirebaseHelper firebaseHelper;

        private string eventName = "";
        private string login = "123@posos.ru";
        private string password = "000000";
        

        public AuthenticationPage()
        {
            InitializeComponent();
            Card.BackgroundColor = Color.White.MultiplyAlpha(0.9);
            auth = DependencyService.Get<IFirebaseAuth>();
            firebaseHelper = new FirebaseHelper();

            EventNameInput.Completed += (sender, args) => { EmailInput.Focus(); };
            EmailInput.Completed += (sender, args) => { PasswordInput.Focus(); };
            
        }



        async void LoginClicked(object sender, EventArgs e)
        {
            if (EventNameInput.Text != null)
                eventName = EventNameInput.Text;
            if (EmailInput.Text != null)
                login = EmailInput.Text;
            if (PasswordInput.Text != null)
                password = PasswordInput.Text;

            
            string token = await auth.LoginWithEmailPassword(login, password, eventName);

            if (token != string.Empty)
            {
                Application.Current.MainPage = new MyTabbedPage();
            }
            else
            {
                ShowError();
            }
        }


        async private void ShowError()
        {
            await DisplayAlert("Ошибка авторизации", "Неверный логин, пароль или название мероприятия. Попробуйте снова!", "ОК");
        }

        
    }
}
