using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;

namespace MethodCards
{
    public class CardsPage : CarouselPage
    {
        List<Label> labels = new List<Label>();
        string filePath;
        string text;
        string[] words;
        string[] pair;
        public CardsPage(string fileP)
        {
            BackgroundColor = Color.White;
            filePath = fileP;
            //File.WriteAllText(filePath, "Car:Auto;Apple:Õun;Table:Laud;");
            text = File.ReadAllText(filePath);
            pair = text.Split(';');
            int length = pair.Length;

            for (int i = 0; i < length-1; i++)
            {
                string splitit = pair[i];
                words = splitit.Split(':');
                labels.Add(new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    HeightRequest = 200,
                    WidthRequest = 280,
                    FontSize = 35,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor = Color.DarkGray,
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = words[0]
            });
            }
            for (int i = 0; i < length-1; i++)
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
        bool tf = true;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (tf == true)
            {
                string splitit = pair[lbl.TabIndex];
                words = splitit.Split(':');
                lbl.Text = words[1];
                tf = false;
            }
            else
            {
                string splitit = pair[lbl.TabIndex];
                words = splitit.Split(':');
                lbl.Text = words[0];
                tf = true;
            }
        }
    }
}