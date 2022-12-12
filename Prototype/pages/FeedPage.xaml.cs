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
        private List<CustomImageControl> clickableImages = new List<CustomImageControl>();
        public FeedPage()
        {
            InitializeComponent();

            LoadInitialData();

            searchBar.SearchButtonPressed += (object sender, EventArgs e) =>
            {
                string filter = ((SearchBar)sender).Text.ToLower();

                var results = clickableImages.Where(image =>
                {
                    var detail = image.get("detail") as Detail;

                    return detail.detailContent.ToLower().Contains(filter) || 
                           detail.title.ToLower().Contains(filter) || 
                           detail.user.ToLower().Contains(filter);
                    
                }).ToList();

                SetNewData(results);

                if(results.Count == 0)
                {
                    this.DisplayAlert("Búsqueda", $"Hay 0 resultados de búsqueda.", "Aceptar");
                }
            };
        }

        private int rows { get; set; }
        private int cols { get; set; } = 3;

        private void LoadInitialData()
        {
            rows = new Random().Next(3, 10);
            int index = 0;

            string imageSource = "https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder-1024x512.png";

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var image = new CustomImageControl() { Source = imageSource, Aspect = Aspect.AspectFill };

                    var detail = new Detail()
                    {
                        _id = Guid.NewGuid(),
                        user = $"Username-{index}",
                        title = $"Detail title {index}",
                        subtitle = $"Detail subtitle {index}",
                        timestamp = DateTime.Now,
                        detailContent = TextGenerator.GenerateBlobOfText(),
                    };

                    image.set("detail", detail);
                    index++;

                    var gestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };

                    gestureRecognizer.Tapped += (object sender, EventArgs e) =>
                    {
                        var det = ((CustomImageControl)sender).get("detail");

                        Navigation.PushAsync(new DetailPage((Detail)det));
                    };

                    image.GestureRecognizers.Add(gestureRecognizer);
                    image.gridCol = col;
                    image.gridRow = row;

                    clickableImages.Add(image);

                    FeedGrid.Children.Add(image, col, row);
                }
            }
        }

        private void SetNewData(List<CustomImageControl> details)
        {
            FeedGrid.Children.Clear();

            if(details.Count > 0)
            {
                int colCount = 0;
                int rowCount = 0;

                details.ForEach(detail =>
                {
                    FeedGrid.Children.Add(detail, colCount, rowCount);

                    colCount++;

                    if (colCount == 3)
                    {
                        rowCount++;
                        colCount = 0;
                    }
                });
            }
            else
            {
                RefreshData();
            }
        }

        private void RefreshData()
        {
            FeedGrid.Children.Clear();

            clickableImages.ForEach(detail => FeedGrid.Children.Add(detail, detail.gridCol, detail.gridRow));
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