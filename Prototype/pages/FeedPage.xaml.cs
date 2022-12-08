using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.helpers;
using Prototype.models;

namespace Prototype.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        private List<Detail> details = new List<Detail>();
        public FeedPage()
        {
            InitializeComponent();

            int columns = 3;
            int rows = new Random().Next(3, 10);
            int index = 0;

            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < columns; col++)
                {
                    var image = new CustomImageControl() { Source = "https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder-1024x512.png", Aspect = Aspect.AspectFill };

                    var detail = new Detail()
                    {
                        _id = Guid.NewGuid(),
                        user = $"Username-{index}",
                        title = $"Detail title {index}",
                        subtitle = $"Detail subtitle {index}",
                        timestamp = DateTime.Now,
                        detailContent = TextGenerator.GenerateBlobOfText(),
                    };

                    details.Add(detail);
                    image.set("detail", detail);

                    index++;

                    var gestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };

                    gestureRecognizer.Tapped += (object sender, EventArgs e) =>
                    {
                        var det = ((CustomImageControl)sender).get("detail");

                        Navigation.PushAsync(new DetailPage((Detail)det));
                    };

                    image.GestureRecognizers.Add(gestureRecognizer);

                    FeedGrid.Children.Add(image, col, row);
                }
            }

            searchBar.SearchButtonPressed += (object sender, EventArgs e) =>
            {
                string filter = ((SearchBar)sender).Text;

                int resultCount = details.Where(d => d.detailContent.Contains(filter)).Count();

                this.DisplayAlert("Búsqueda", $"Hay {resultCount} resultados de búsqueda.", "Aceptar");
            };
        }

        private void LogoutClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void ProfileClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}