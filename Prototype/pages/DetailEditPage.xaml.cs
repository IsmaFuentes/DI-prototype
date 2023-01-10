using Prototype.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailEditPage : ContentPage
    {
        public DetailEditPage()
        {
            InitializeComponent();
        }

        public DetailEditPage(Detail detail)
        {
            InitializeComponent();

            title.Text = "Post";
            subtitle.Text = detail.title;
            timestamp.Date = detail.timestamp;
            detailContent.Text = detail.detailContent;
        }

        private void onSave(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}