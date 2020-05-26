using System;
using System.Collections.Generic;
using System.ComponentModel;
using EventApp.Web;
using Xamarin.Forms;

namespace EventApp.Views
{
    [DesignTimeVisible(true)]
    public partial class AuthenticationPage : ContentPage
    {
        IAuth auth;

        public AuthenticationPage()
        {
            InitializeComponent();
            Card.BackgroundColor = Color.White.MultiplyAlpha(0.9);
            auth = DependencyService.Get<IAuth>();
        }



        async void LoginClicked(object sender, EventArgs e)
        {
            string Token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);

            if (Token != "")
            {
                await Navigation.PushAsync(new MyTabbedPage());
            }
            else
            {
                ShowError();
            }
            //EmailInput.Text = "";
            //PasswordInput.Text = "";
        }


        async private void ShowError()
        {
            await DisplayAlert("Ошибка авторизации", "Неверный логин или пароль. Попробуйте снова!", "ОК");
        }
    }
}
