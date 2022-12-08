using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype.pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void OnLoginSuccess()
        {
            Navigation.PushAsync(new FeedPage());
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            OnLoginSuccess();
        }
    }
}