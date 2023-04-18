using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MethodCards
{
    public class AddPage : ContentPage
    {
        StackLayout st;
        List<string> engList, rusList;
        Label engLabel, rusLabel;
        Editor engEditor, rusEditor;
        Button btn;
        public AddPage(List<string> engList, List<string> rusList)
        {
            this.engList = engList;
            this.rusList = rusList;
            BackgroundColor = Color.White;
            engLabel = new Label
            {
                FontSize = 18,
                Text = "Kirjutage ingliskeelne sõna",
            };
            rusLabel = new Label
            {
                FontSize = 18,
                Text = "Kirjutage venekeelne sõna",
            };
            engEditor = new Editor
            {
                Placeholder = ". . .",
                PlaceholderColor = Color.DarkGray,
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                AutoSize = EditorAutoSizeOption.TextChanges
            };
            rusEditor = new Editor
            {
                Placeholder = ". . .",
                PlaceholderColor = Color.DarkGray,
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                AutoSize = EditorAutoSizeOption.TextChanges
            };
            btn = new Button
            {
                Text = "OK",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White
            };
            btn.Clicked += Btn_Clicked;

            st = new StackLayout
            {
                Children = { engLabel, engEditor, rusLabel, rusEditor, btn }
            };
            Content = st;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            engList.Add(engEditor.Text);
            rusList.Add(rusEditor.Text);
            await Navigation.PopAsync();
        }
    }
}