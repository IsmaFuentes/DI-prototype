using Prototype.helpers;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            int columns = 3;
            int rows = new Random().Next(3, 5);
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var image = new CustomImageControl() { Source = "https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder-1024x512.png", Aspect = Aspect.AspectFill };

                    image.set("detail", new Detail()
                    {
                        _id = Guid.NewGuid(),
                        user = $"Username-{index}",
                        title = $"Detail title {index}",
                        subtitle = $"Detail subtitle {index}",
                        timestamp = DateTime.Now,
                        detailContent = TextGenerator.GenerateBlobOfText(),
                    });

                    index++;

                    var gestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };

                    gestureRecognizer.Tapped += (object sender, EventArgs e) =>
                    {
                        var det = ((CustomImageControl)sender).get("detail");

                        Navigation.PushAsync(new DetailPage((Detail)det, true));
                    };

                    image.GestureRecognizers.Add(gestureRecognizer);

                    ProfileGrid.Children.Add(image, col, row);
                }
            }
        }
    }
}