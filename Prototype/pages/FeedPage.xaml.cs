using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype.helpers;
using Prototype.views;

namespace Prototype.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        private List<DetailView> mockupData = new List<DetailView>();
        public FeedPage()
        {
            InitializeComponent();

            LoadInitialData();

            searchBar.SearchButtonPressed += (object sender, EventArgs e) =>
            {
                string filter = ((SearchBar)sender).Text.ToLower();

                var results = mockupData.Where(dtView =>
                {
                    var detail = dtView.getDetail();

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
        private int cols { get; set; } = 1;

        private void LoadInitialData()
        {
            rows = new Random().Next(3, 20);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var detail = MockupGenerator.GenerateDetail();

                    var detailView = new DetailView($"{detail.title} - {detail.user}", detail.imageUrl);

                    detailView.setDetail(detail);
                    detailView.gridCol = col;
                    detailView.gridRow = row;

                    mockupData.Add(detailView);

                    FeedGrid.Children.Add(detailView, col, row);
                }
            }
        }

        private void SetNewData(List<DetailView> details)
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

            mockupData.ForEach(detail => FeedGrid.Children.Add(detail, detail.gridCol, detail.gridRow));
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