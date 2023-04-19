using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace MethodCards
{
    public partial class MainPage : ContentPage
    {
        List<string> engList = new List<string> { "apple", "table", "sun" };
        List<string> rusList = new List<string> { "õun", "laud", "päike" };
        StackLayout st;
        public MainPage()
        {
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
            await Navigation.PushAsync(new AddPage(engList, rusList));
        }

        private async void Cards_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardsPage(engList, rusList));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("engList"))
            {
                engList = (List<string>)Application.Current.Properties["engList"];
                rusList = (List<string>)Application.Current.Properties["rusList"];
            }
        }
    }
}
