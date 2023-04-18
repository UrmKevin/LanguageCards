using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MethodCards
{
    public class CardsPage : CarouselPage
    {
        List<Label> labels = new List<Label>();
        List<string> rusList, engList;
        public CardsPage(List<string> list1, List<string> list2)
        {
            BackgroundColor = Color.White;
            engList = list1;
            rusList = list2;
            foreach (var item in engList)
            {
                labels.Add(new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    FontSize = 35,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor = Color.DarkGray,
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = item
                });
            }
            for (int i = 0; i < engList.Count; i++)
            {
                var page = new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            labels[i]
                        }
                    }
                };
                labels[i].TabIndex = i;
                var tap = new TapGestureRecognizer();
                labels[i].GestureRecognizers.Add(tap);
                tap.Tapped += Tap_Tapped;
                Children.Add(page);
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl.Text == engList[lbl.TabIndex])
            {
                lbl.Text = rusList[lbl.TabIndex];
            }
            else
            {
                lbl.Text = engList[lbl.TabIndex];
            }
        }
    }
}