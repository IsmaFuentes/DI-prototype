using Prototype.pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnLogOutSuccess()
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void LogoutClick(object sender, EventArgs e)
        {
            OnLogOutSuccess();
        }
    }
}
