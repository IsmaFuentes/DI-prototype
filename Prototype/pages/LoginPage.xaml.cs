using System;
using Xamarin.Forms;
using Prototype.models;

namespace Prototype.pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            password.Completed += LoginOnClick;
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            string user = username.Text?.Trim();
            string pass = password.Text?.Trim();

            if (CheckCredentials(user, pass))
            {
                ApplicationState.AddValue("user", new User(user, pass));

                Navigation.PushAsync(new FeedPage());
            }
            else
            {
                this.DisplayAlert("Credenciales incorrectas", "Credenciales de acceso incorrectas.", "Aceptar");
            }
        }

        private bool CheckCredentials(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}