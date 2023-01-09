using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.models;
using Prototype.pages;

namespace Prototype.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentView
    {
        private Detail detail;
        public int gridRow { get; set; }
        public int gridCol { get; set; }

        public DetailView(string title, string url)
        {
            InitializeComponent();

            this.Title.Text = title;
            this.Image.Source = url;
            this.Image.Aspect = Aspect.AspectFill;

            var gestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };

            gestureRecognizer.Tapped += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new DetailPage(detail));
            };

            this.Image.GestureRecognizers.Add(gestureRecognizer);
        }

        public void setDetail(Detail detail)
        {
            this.detail = detail;
        }

        public Detail getDetail()
        {
            return detail;
        }
    }
}