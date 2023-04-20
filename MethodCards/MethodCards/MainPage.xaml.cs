using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;
using System.IO;

namespace MethodCards
{
    public partial class MainPage : ContentPage
    {
        StackLayout st;
        string fileName = "myFile.txt";
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string filePath;
        public MainPage()
        {
            filePath = Path.Combine(folderPath, fileName);
            BackgroundColor = Color.White;
            Button cards = new Button
            {
                Text = "Õppekaardid",
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
            };
            cards.Clicked += Cards_Clicked;
            Button add = new Button
            {
                Text = "Lisa uus õppekaart",
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
            };
            add.Clicked += Add_Clicked;

            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { cards, add }
            };
            Content = st;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage(filePath));
        }

        private async void Cards_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardsPage(filePath));
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (Application.Current.Properties.ContainsKey("engList"))
        //    {
        //        engList = (List<string>)Application.Current.Properties["engList"];
        //        rusList = (List<string>)Application.Current.Properties["rusList"];
        //    }
        //}
    }
}
