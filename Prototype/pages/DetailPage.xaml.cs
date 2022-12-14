using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.models;

namespace Prototype.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        public DetailPage(Detail detail, bool allowEditing = false)
        {
            InitializeComponent();

            this.detail = detail;

            this.Title = "Post";
            this.subtitleLabel.Text = $"{detail.title}";
            this.timestampLabel.Text = $"{detail.user} - {detail.timestamp.ToShortDateString()}";
            this.contentLabel.Text = detail.detailContent;

            if (allowEditing)
            {
                dislike.IsVisible = false;
                like.IsVisible = false;
                edit.IsVisible = true;
            }
        }

        private Detail detail { get; set; }

        public void onDetailEdit(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailEditPage(detail));
        }
    }
}