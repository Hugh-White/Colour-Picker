﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core.Platform;

namespace ColourPicker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexValue;

        public MainPage()
        {
            InitializeComponent();

            

           
        }

        private void Slider_ValChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom) 
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);

                Title.TextColor = color;
                StatusBar.SetColor(color);

            }

        }

        private void SetColor(Color color)
        {
            btnRandom.Background = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = "Hex Value: " + hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;

            var random = new Random();

            var color = Color.FromRgb(random.Next(0, 256), 
                                      random.Next(0, 256), 
                                      random.Next(0, 256));
            SetColor(color);

            Title.TextColor = color;
            StatusBar.SetColor(color);


            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;

            isRandom = false;
        }

        private async void btnCopy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Colour Copied!",
                CommunityToolkit.Maui.Core.ToastDuration.Short, 
                12);
            await toast.Show();
        }
    }
}